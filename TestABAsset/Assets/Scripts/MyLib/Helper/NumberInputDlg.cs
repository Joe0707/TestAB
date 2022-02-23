using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberInputDlg : MonoBehaviour
{
    static NumberInputDlg mInstance = null;
    public Text m_Caption; //提示文字
    public InputField m_InputField; //输入框
    public Slider m_Slider; //滑动块
    public Text m_SliderCurValue; //当前值 
    public Button m_OkBtn; //确认按钮
    public Button m_CancelBtn; //取消按钮
    public Button m_AddBtn; //增加按钮 
    public Button m_MinusBtn; //减少按钮 

    System.Action<int> mOkAction = null; //确认的操作
    System.Action mCancelAction = null; //取消的操作
    int mMaxValue = 1;
    int mMinValue = 0;
    public NumberInputDlg()
    {
        mInstance = this;
    }
    void Awake()
    {
    }
    void Start()
    {
        //设定按钮
        m_OkBtn.onClick.AddListener(()=>{OnOkBtn();});
        if(m_CancelBtn != null)
            m_CancelBtn.onClick.AddListener(() => { OnCancelBtn(); });
        if(m_InputField != null)
            m_InputField.onValueChanged.AddListener((value) => { OnInputFieldValueChanged(value); });
        if(m_Slider != null)
            m_Slider.onValueChanged.AddListener((value)=>{OnSliderValueChanged(value);});
        if(m_AddBtn != null)
            m_AddBtn.onClick.AddListener(() => { OnAddBtn(); });
        if(m_MinusBtn != null)
            m_MinusBtn.onClick.AddListener(() => { OnMinusBtn(); });
    }

    //显示输入框
    public static void ShowInputField(string caption, int minValue, int maxValue, System.Action<int> okAction, System.Action cancelAction = null)
    {
        if(mInstance == null)
            return;
        if(mInstance.m_InputField == null) 
            return;
        mInstance.gameObject.SetActive(true);
        //显示组件
        mInstance.m_InputField.gameObject.SetActive(true);
        mInstance.mMinValue = minValue;
        mInstance.mMaxValue = maxValue;
        mInstance.mOkAction = okAction;
        mInstance.mCancelAction = cancelAction;
        mInstance.m_InputField.text = "1";
        //文字 
        mInstance.m_Caption.text = caption;
        //隐藏滑动块模式的组件
        if(mInstance.m_Slider != null)
            mInstance.m_Slider.gameObject.SetActive(false);
        if(mInstance.m_SliderCurValue != null)
            mInstance.m_SliderCurValue.gameObject.SetActive(false);
    }

    //显示滑动块
    public static void ShowSlider(string caption, int minValue, int maxValue, System.Action<int> okAction, System.Action cancelAction = null)
    {
        if(mInstance == null)
            return;
        if(mInstance.m_Slider == null) 
            return;
        mInstance.gameObject.SetActive(true);
        mInstance.mMinValue = minValue;
        mInstance.mMaxValue = maxValue;
        mInstance.mOkAction = okAction;
        //显示组件
        mInstance.m_Slider.gameObject.SetActive(true);
        mInstance.SetValue(1);
        
        if(mInstance.m_SliderCurValue != null)
        {
            mInstance.m_SliderCurValue.gameObject.SetActive(true);
            mInstance.m_SliderCurValue.text = mInstance.Value.ToString();
        }
        mInstance.mCancelAction = cancelAction;
        //文字 
        mInstance.m_Caption.text = caption;
        //隐藏输入组件
        if(mInstance.m_InputField != null)
            mInstance.m_InputField.gameObject.SetActive(false);
    }

    public static void Hide()
    {
        if(mInstance != null)
            mInstance.OnCancelBtn();
    }

    public void OnOkBtn()
    {
        if(mOkAction != null)
            mOkAction(Value);
        gameObject.SetActive(false);
    }

    public void OnCancelBtn()
    {
        if(mCancelAction != null)
            mCancelAction();
        gameObject.SetActive(false);
    }

    //输入框文字变化 
    public void OnInputFieldValueChanged(string value)
    {
        try{
            if(m_InputField == null)
                return;
            int intValue = System.Int32.Parse(m_InputField.text);
            if(intValue > mMaxValue)
                m_InputField.text = mMaxValue.ToString();
            else if(intValue < mMinValue)
                m_InputField.text = mMinValue.ToString();
        }
        catch
        {
            m_InputField.text = mMinValue.ToString();
        }
    }

    //滑动块位置变化
    public void OnSliderValueChanged(float value)
    {
        m_SliderCurValue.text = Value.ToString();
    }

    //增加按钮
    void OnAddBtn()
    {
        SetValue(Value + 1);
    }

    //减少按钮
    void OnMinusBtn()
    {
        SetValue(Value - 1);
    } 
    
    int Value
    {
        get
        {
            try
            {
                if(m_InputField != null && m_InputField.gameObject.activeInHierarchy)
                {
                    int intValue = System.Int32.Parse(m_InputField.text);
                    return intValue;
                }
                else if(m_Slider != null && m_Slider.gameObject.activeInHierarchy)
                {
                    float percent = m_Slider.value;
                    int intValue = (int)Mathf.Round(mMinValue + (mMaxValue - mMinValue) * percent);
                    return intValue;
                }
                else
                    return mMinValue;
            }
            catch (System.Exception e)
            {
                Debug.LogError("NumberInputDlg.Value" + e.ToString());
                return mMinValue;
            }
        }
    }

    //设定值
    void SetValue(int value)
    {
        if (m_InputField != null && m_InputField.gameObject.activeInHierarchy)
        {
            if(value >= mMinValue && value <= mMaxValue)
                m_InputField.text = value.ToString();
        }
        else if (m_Slider != null && m_Slider.gameObject.activeInHierarchy)
        {
            if(value >= mMinValue && value <= mMaxValue)
            {
                float percent = (value - mMinValue) / (float)(mMaxValue - mMinValue);
                m_Slider.value = percent;
            }
        }
    }
}
