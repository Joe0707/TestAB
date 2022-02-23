using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityItem : MonoBehaviour {
	public float m_Force = 10;
	public float m_RandDelta = 2f; //随机量
	public Vector3 m_ForcePointDelta; 
	Rigidbody2D mRigidBody2D = null;
	Rigidbody mRigidBody = null;
	void Start () {
		mRigidBody = GetComponent<Rigidbody>();	
		mRigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if(mRigidBody2D == null && mRigidBody == null)
			return;
		float random = Random.Range(-m_RandDelta, m_RandDelta);
		if(mRigidBody != null)
		{
			Vector3 force = (m_Force + random) * (Input.acceleration).normalized;
			Vector3 randomForce = new Vector3(Random.Range(-1, 1), Random.Range(-1,1), Random.Range(-1,1));
			force += randomForce.normalized * 0.3f;
			mRigidBody.AddForceAtPosition(force, transform.position + m_ForcePointDelta);
		}
		else if(mRigidBody2D != null)
		{
			Vector2 force = Vector2.zero;
            force.x = Input.acceleration.x;
            force.y = Input.acceleration.y;
            force = (m_Force + random) * force.normalized;
			Vector2 randomForce = new Vector2(Random.Range(-1, 1), Random.Range(-1,1));
			force += randomForce.normalized * 0.3f;
			mRigidBody2D.AddForceAtPosition(force, transform.position + m_ForcePointDelta);
        }
    }

}
