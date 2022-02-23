using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AutoLanguageTexture : MonoBehaviour {
	public Sprite spriteCN;//图片，或按钮Normal状态的图片
	public Sprite spriteEN;
	public Sprite spriteCNTR;
	public Sprite spritePressedCN;//按钮被按下的图片
	public Sprite spritePressedEN;
	public Sprite spritePressedCNTR;

	public Sprite spriteHilightedCN;//按钮高亮状态的图片
	public Sprite spriteHilightedEN;
	public Sprite spriteHilightedCNTR;

	public Sprite spriteDisabledCN;//按钮被禁用状态的图片
	public Sprite spriteDisabledEN;
	public Sprite spriteDisabledCNTR;

	void Start () 
	{
		//Sprite
		SpriteRenderer sprRenderer = gameObject.GetComponent<SpriteRenderer>();
		if(sprRenderer != null)
		{
			if(Application.systemLanguage == SystemLanguage.ChineseSimplified || Application.systemLanguage == SystemLanguage.Chinese)
				sprRenderer.sprite = spriteCN;
			else if(Application.systemLanguage == SystemLanguage.ChineseTraditional)
				sprRenderer.sprite = spriteCNTR;
			else
				sprRenderer.sprite = spriteEN;
			SpriteButton sprBtn = gameObject.GetComponent<SpriteButton>();
			if(sprBtn != null)
			{
				if(Application.systemLanguage == SystemLanguage.ChineseSimplified || Application.systemLanguage == SystemLanguage.Chinese)
				{
					sprBtn.normalSprite = spriteCN;
					sprBtn.downSprite = spritePressedCN;
				}
				else if(Application.systemLanguage == SystemLanguage.ChineseTraditional)
				{
					sprBtn.normalSprite = spriteCNTR;
					sprBtn.downSprite = spritePressedCNTR;
				}
				else
				{
					sprBtn.normalSprite = spriteEN;
					sprBtn.downSprite = spritePressedEN;
				}
			}
		}
		else
		{
			//UI.Image or UI.Button
			Image image = gameObject.GetComponent<Image>();
			if(image != null)
			{
				Button button = gameObject.GetComponent<Button>();
				if(button != null && button.transition == Selectable.Transition.SpriteSwap)
				{
					SpriteState tmpSprState = button.spriteState;
					if(Application.systemLanguage == SystemLanguage.ChineseSimplified || Application.systemLanguage == SystemLanguage.Chinese)
					{
						image.sprite = spriteCN;
						tmpSprState.pressedSprite = spritePressedCN;
						tmpSprState.highlightedSprite = spriteHilightedCN;
						tmpSprState.disabledSprite = spriteDisabledCN;
					}
					else if(Application.systemLanguage == SystemLanguage.ChineseTraditional)
					{
						image.sprite = spriteCNTR;
						tmpSprState.pressedSprite = spritePressedCNTR;
						tmpSprState.highlightedSprite = spriteHilightedCNTR;
						tmpSprState.disabledSprite = spriteDisabledCNTR;
					}
					else
					{
						image.sprite = spriteEN;
						tmpSprState.pressedSprite = spritePressedEN;
						tmpSprState.highlightedSprite = spriteHilightedEN;
						tmpSprState.disabledSprite = spriteDisabledEN;
					}
					button.spriteState = tmpSprState;
				}
				else
				{//Image 或者不是 SpriteSwap的按钮，只换1张图就可以
					if(Application.systemLanguage == SystemLanguage.ChineseSimplified || Application.systemLanguage == SystemLanguage.Chinese)
						image.sprite = spriteCN;
					else if(Application.systemLanguage == SystemLanguage.ChineseTraditional)
						image.sprite = spriteCNTR;
					else
						image.sprite = spriteEN;
				}
				image.SetNativeSize();
			}

		}
	}
}
