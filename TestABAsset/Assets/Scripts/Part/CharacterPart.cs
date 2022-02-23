using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalDefine;
using System.IO;
using Newtonsoft.Json;
public class PartPositionDelta
{
    public float X { get; set; } = 0;
    public float Y { get; set; } = 0;
}
public class CharacterPart : MonoBehaviour
{
    // Start is called before the first frame update
    public EPart m_Type;//部件类型
    public SpriteRenderer m_Renderer;
    public GameObject m_ChildPart;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    //加载部件Sprite
    public void LoadPartSprite(string fileName)
    {
        if (fileName == "")
            return;
        m_Renderer.sprite = H.GetResourceSprite(fileName, "Part");//加载部件图片
        if (File.Exists(fileName + ".json"))
        {//判断是否有配置文件，如果有就读取配置文件
            FileStream fs = new FileStream(fileName + ".json", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string json = sr.ReadToEnd();
            sr.Close();
            try
            {
                var positionDelta = JsonConvert.DeserializeObject<PartPositionDelta>(json);
                var pos = m_ChildPart.transform.localPosition;
                pos.x = positionDelta.X;
                pos.y = positionDelta.Y;
                pos.z = -0.001f * (int)m_Type;
                m_ChildPart.transform.localPosition = pos;

            }
            catch (System.Exception e)
            {
                Debug.Log(e.ToString());
            }
        }
        else
        {//如果没有部件位置配置文件就用默认坐标
            var partPos = InitPartPosition.GetPartPosition((int)m_Type);
            var pos = m_ChildPart.transform.localPosition;
            pos.x = partPos.x;
            pos.y = partPos.y;
            pos.z = -0.001f * (int)m_Type;
            m_ChildPart.transform.localPosition = pos;
        }
    }
}
