using UnityEngine;
using UnityEngine.UI;
public class ShowFPS : MonoBehaviour
{
    int m_FrameCount = 0;//帧数;
    double m_AddupFrameTime; //累计时间

    private float m_FPS = 0;

    public Text showtext;//显示fps的文本
                         // Update is called once per frame
    void Update()
    {
        m_FrameCount++;
        m_AddupFrameTime += Time.deltaTime;

        if (m_FrameCount >= 30)
        {
            m_FPS = (float)(1 / (m_AddupFrameTime / 30f));
            m_AddupFrameTime = 0;
            m_FrameCount -= 30;
        }
        ShowFpsByText();
    }

    //显示fps
    private void ShowFpsByText()
    {
        if (showtext != null)
        {
            showtext.text = string.Format("FPS: {0}", m_FPS + 5);//和unity报出来的差了5帧，不知原因
        }
    }

    // void OnGUI()
    // {
    //     GUI.Label(new Rect(Screen.width / 2, 0, 100, 100), "FPS: " + (m_FPS + 5)); //和unity报出来的差了5帧，不知原因
    // }

}
