using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : MonoBehaviour {

    public enum EDirKey { Left, Right, Up, Down }
    //按键信息
    class KeyInfo
    {
        public string mKeyName = ""; //key名称
        public bool mTriggered = false;//是否被触发了
        public int mUpdateCount = 0;//触发后经过Update的次数
    }

    //轴信息
    [System.Serializable]
    public class AxisInfo
    {
        public string mAxisName = "";//轴名称
        [HideInInspector]
        public float mValue = 0f;//当前值
        public EDirKey mPositiveKey;//正向按键
        public EDirKey mNagativeKey;//负向按键
        [Tooltip("灵敏度，按键时值的变化速度")]
        public float mSensitivity = 2f;//灵敏度
        [Tooltip("按键抬起后，恢复0的速度")]
        public float mRecovery = 2f;//恢复灵敏度
    }

    public AxisInfo[] axis;//预定义的轴信息

    public static InputMgr mInstance = null;
    private Dictionary<string, KeyInfo> mHoldKeyDic = new Dictionary<string, KeyInfo>();//保持按下的按键
    private Dictionary<string, KeyInfo> mKeyDownDic = new Dictionary<string, KeyInfo>();//此帧按下的按键
    private Dictionary<string, KeyInfo> mKeyUpDic = new Dictionary<string, KeyInfo>();//此帧抬起的按键

    private Dictionary<EDirKey, KeyInfo> mHoldDirKeyDic = new Dictionary<EDirKey, KeyInfo>();//保持按下方向键

    #region MonoBehavior
    void Awake()
    {
        mInstance = this;
    }

    void Update()
    {
        //保持按下的按键
        foreach(var pair in mHoldKeyDic)
        {
            if (pair.Value.mTriggered)
                pair.Value.mUpdateCount++;
        }
        //此帧按下的按键
        foreach (var pair in mKeyDownDic)
        {
            if (pair.Value.mTriggered)
            {
                if (pair.Value.mUpdateCount == 0)
                    pair.Value.mUpdateCount++;
                else
                    pair.Value.mTriggered = false;
            }
        }
        //此帧抬起的按键
        foreach (var pair in mKeyUpDic)
        {
            if (pair.Value.mTriggered)
            {
                if (pair.Value.mUpdateCount == 0)
                    pair.Value.mUpdateCount++;
                else
                    pair.Value.mTriggered = false;
            }
        }
        //方向键
        foreach(var ax in axis)
        {
            if(mHoldDirKeyDic.ContainsKey(ax.mPositiveKey) && mHoldDirKeyDic[ax.mPositiveKey].mTriggered)
            {//正向的按钮被按下了
                ax.mValue = Mathf.Min(1f, ax.mValue + ax.mSensitivity * Time.deltaTime);
            }
            else if(mHoldDirKeyDic.ContainsKey(ax.mNagativeKey) && mHoldDirKeyDic[ax.mNagativeKey].mTriggered)
            {//负向按钮被触发
                ax.mValue = Mathf.Max(-1f, ax.mValue - ax.mSensitivity * Time.deltaTime);
            }
            else
            {//按钮都没按下,向0回复
                if(ax.mValue > 0)
                {
                    ax.mValue = Mathf.Max(0, ax.mValue - ax.mRecovery * Time.deltaTime);
                }
                else if(ax.mValue < 0)
                {
                    ax.mValue = Mathf.Min(0, ax.mValue + ax.mRecovery * Time.deltaTime);
                }
            }
        }
    }
    #endregion

    //实现Input的接口
    #region InputInterface
    //查询轴的值
    public static float GetAxis(string axisName)
    {
        float retValue = 0;
        var ax = mInstance.GetAxisInfo(axisName);
        if (ax != null)
        {
            retValue = ax.mValue;
        }
        else
            Debug.LogError("No axis named : " + axisName);
        if (retValue == 0)
            retValue = Input.GetAxis(axisName);
        return retValue;
    }

    private AxisInfo GetAxisInfo(string axisName)
    {
        foreach (var ax in mInstance.axis)
        {
            if (ax.mAxisName == axisName)
                return ax;
        }
        return null;
    }

    //查询某按键是否被持续按下
    public static bool GetButton(string keyName)
    {
        if (mInstance == null)
            return false;
        if (mInstance.mHoldKeyDic.ContainsKey(keyName))
            return mInstance.mHoldKeyDic[keyName].mTriggered || Input.GetButton(keyName);
        else
            return Input.GetButton(keyName);
    }

    //查询某按键是否
    public static bool GetButtonDown(string keyName)
    {
        if (mInstance == null)
            return false;
        if (mInstance.mKeyDownDic.ContainsKey(keyName))
            return mInstance.mKeyDownDic[keyName].mTriggered || Input.GetButtonDown(keyName);
        else
            return Input.GetButtonDown(keyName);
    }

    public static bool GetButtonUp(string keyName)
    {
        if (mInstance == null)
            return false;
        if (mInstance.mKeyUpDic.ContainsKey(keyName))
            return mInstance.mKeyUpDic[keyName].mTriggered || Input.GetButtonUp(keyName);
        else
            return Input.GetButtonUp(keyName);
    }
    #endregion

    //由外部操作的方法
    #region SetMethods
    //按键按下
    public void SetButtonDown(string keyName)
    {
        if (mHoldKeyDic.ContainsKey(keyName) == false)
            mHoldKeyDic.Add(keyName, new KeyInfo());
        if (mKeyDownDic.ContainsKey(keyName) == false)
            mKeyDownDic.Add(keyName, new KeyInfo());
        mHoldKeyDic[keyName].mTriggered = true;
        mHoldKeyDic[keyName].mUpdateCount = 0;
        mKeyDownDic[keyName].mTriggered = true;
        mKeyDownDic[keyName].mUpdateCount = 0;
    }

    //按键抬起
    public void SetButtonUp(string keyName)
    {
        if (mKeyUpDic.ContainsKey(keyName) == false)
            mKeyUpDic.Add(keyName, new KeyInfo());
        mKeyUpDic[keyName].mTriggered = true;
        mKeyUpDic[keyName].mUpdateCount = 0;

        if (mHoldKeyDic.ContainsKey(keyName))
            mHoldKeyDic[keyName].mTriggered = false;
    }

    //方向键按下
    public void SetDirButtonDown(EDirKey dir)
    {
        if (mHoldDirKeyDic.ContainsKey(dir) == false)
            mHoldDirKeyDic.Add(dir, new KeyInfo());
        mHoldDirKeyDic[dir].mTriggered = true;
        mHoldDirKeyDic[dir].mUpdateCount = 0;
    }
    public void SetDirButtonDown_Up() { SetDirButtonDown(EDirKey.Up); }
    public void SetDirButtonDown_Down() { SetDirButtonDown(EDirKey.Down); }
    public void SetDirButtonDown_Left() { SetDirButtonDown(EDirKey.Left); }
    public void SetDirButtonDown_Right() { SetDirButtonDown(EDirKey.Right); }
    //方向键抬起
    public void SetDirButtonUp(EDirKey dir)
    {
        if (mHoldDirKeyDic.ContainsKey(dir))
            mHoldDirKeyDic[dir].mTriggered = false;
    }
    public void SetDirButtonUp_Up() { SetDirButtonUp(EDirKey.Up); }
    public void SetDirButtonUp_Down() { SetDirButtonUp(EDirKey.Down); }
    public void SetDirButtonUp_Left() { SetDirButtonUp(EDirKey.Left); }
    public void SetDirButtonUp_Right() { SetDirButtonUp(EDirKey.Right); }
    #endregion

}
