using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//对话管理器
public class DialogMgr : MonoSingleton<DialogMgr>
{
    public Image AvatarA;//角色A头像
    public Image AvatarB;//角色B头像
    public Text Dialog;//对话内容
    private uint aAvatar;//角色A的ID
    private uint bAvatar;//角色B的ID
    public void RefreshDialog(uint aAvatarId, uint bAvatarId, string dialog)
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }
        if (this.aAvatar != aAvatarId)
        {
            var paintA = new PaintConfig();
            var aTexture = PaintingMgr.Instance.GenerateBodyPaint(paintA);
            var aSprite = Sprite.Create(aTexture, new Rect(0, 0, aTexture.width, aTexture.height), new Vector2(0.5f, 0.5f), 100f);
            AvatarA.overrideSprite = aSprite;
        }
        if (this.bAvatar == bAvatarId)
        {
            var paintB = new PaintConfig();
            var bTexture = PaintingMgr.Instance.GenerateBodyPaint(paintB);
            var bSprite = Sprite.Create(bTexture, new Rect(0, 0, bTexture.width, bTexture.height), new Vector2(0.5f, 0.5f), 100f);
            AvatarB.overrideSprite = bSprite;
        }
        Dialog.text = dialog;
    }
}
