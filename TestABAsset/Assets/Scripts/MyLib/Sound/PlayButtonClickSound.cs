using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonClickSound : MonoBehaviour {
	[Tooltip("在SoundMgr设定的音效名称")]
	public string m_SoundName = "ButtonClick";
	void Start () {
		var button = GetComponent<Button>();
		if(button != null)
		{
			button.onClick.AddListener(()=>{
				if(m_SoundName != "")
					SoundMgr.PlaySoundEffect(m_SoundName);
					SoundMgr.PlayTouchFeedBack();
			});
		}
	}
	
}
