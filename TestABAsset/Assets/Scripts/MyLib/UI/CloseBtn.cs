using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseBtn : MonoBehaviour {
	public GameObject m_PanelToClose; //要呗关闭的对象
	void Start () {
		Button button = GetComponent<Button>();
		if(button != null && m_PanelToClose != null)
		{
			button.onClick.AddListener(()=>{m_PanelToClose.SetActive(false);});
		}
	}
}
