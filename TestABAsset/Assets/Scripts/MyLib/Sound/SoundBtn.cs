using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBtn : MonoBehaviour {
	
	public Sprite m_ImageSoundOn;
	public Sprite m_ImageSoundOff;
	public ESoundType m_SoundType;

	private Image mImage;
	void Start () {
		mImage = GetComponent<Image>();	
		UpdateImage();
		var button = GetComponent<Button>();
		if(button != null)
		{
			button.onClick.AddListener(()=>OnButtonClicked());
		}
	}
	public void OnButtonClicked()
	{
		if(m_SoundType == ESoundType.EST_Music)
            SoundMgr.SetMusic(!SoundMgr.mMusicOn);
        else if(m_SoundType == ESoundType.EST_Sound)
            SoundMgr.SetSndEffect(!SoundMgr.mSndEffectOn);
		else if(m_SoundType == ESoundType.EST_Vibrate)
			SoundMgr.SetVibrateFeedback(!SoundMgr.mVibrateTouchFeedBackOn);
		UpdateImage();
	}	

	//根据状态更新图片
	void UpdateImage()
	{
		if(mImage != null)
		{
            bool isOn = false;
            if (m_SoundType == ESoundType.EST_Music)
                isOn = SoundMgr.mMusicOn;
            else if (m_SoundType == ESoundType.EST_Sound)
                isOn = SoundMgr.mSndEffectOn;
            else if (m_SoundType == ESoundType.EST_Vibrate)
                isOn = SoundMgr.mVibrateTouchFeedBackOn;
            if (isOn)
                mImage.sprite = m_ImageSoundOn;
            else
                mImage.sprite = m_ImageSoundOff;
            mImage.SetNativeSize();
        }
    }
}
