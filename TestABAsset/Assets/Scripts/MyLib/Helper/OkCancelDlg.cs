using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OkCancelDlg : MonoBehaviour
{
    static OkCancelDlg mInstance = null;
    public GameObject m_UIRoot; //根节点
    public GameObject m_DlgPanel; //面板
    public Text m_DlgText; //文字
    
    System.Action mOkAction = null; //确认的回调
    System.Action mCancelAction = null; // 取消的回调
    void Start()
    {
        mInstance = this;
        m_UIRoot.SetActive(false);
    }

    //显示
    public static void Show(string text, System.Action okAction, System.Action cancelAction)
    {
        if(mInstance == null)
            return;
        mInstance.StopAllCoroutines();
        mInstance.StartCoroutine(mInstance._ShowProcess());
        mInstance.m_DlgText.text = text;
        mInstance.mOkAction = okAction;
        mInstance.mCancelAction = cancelAction;
    }

    IEnumerator _ShowProcess()
    {
        m_UIRoot.SetActive(true);
        m_DlgPanel.transform.localScale = Vector3.zero;
        iTween.ScaleTo(m_DlgPanel, iTween.Hash("scale", Vector3.one, "time", 0.2f, "easetype", iTween.EaseType.easeOutBack));
        yield return new WaitForSeconds(0.3f);
    }

    public static void Hide()
    {
        if(mInstance == null)
            return;
        if(mInstance.m_UIRoot.activeInHierarchy == false)
            return;
        mInstance.StopAllCoroutines();
        mInstance.StartCoroutine(mInstance._HideProcess());
    }

    IEnumerator _HideProcess()
    {
        iTween.ScaleTo(m_DlgPanel, iTween.Hash("scale", Vector3.zero, "time", 0.2f, "easetype", iTween.EaseType.easeOutQuad));
        yield return new WaitForSeconds(0.2f);
        m_UIRoot.SetActive(false);
    }
    
    //点击确认按钮
    public void OnOkBtn()
    {
        Hide();
        if(mOkAction != null)
            mOkAction();
    }

    //点击取消按钮
    public void OnCancelBtn()
    {
        Hide();
        if(mCancelAction != null)
            mCancelAction();
    }
}

