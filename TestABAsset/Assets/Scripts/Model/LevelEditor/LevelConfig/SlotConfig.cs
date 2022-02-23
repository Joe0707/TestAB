using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalDefine;
namespace Levels
{
    public class SlotConfig
    {
        public ESlotType Type = ESlotType.PuTong; //格子类型
        public EDirection Direction = EDirection.Up;//朝向
        public string AttachmentName = ""; //格子上的附着物预制体名称
        public int Index = 0; //格子索引
        public int RowNumber = 0;//行号
        public int ColumnNumber = 0;//列号
        public bool CanDeployUnit = false;//可以部署单位
        public ETeamType DeployTeam = ETeamType.Enemy;//部署单位的阵营
        public bool CanEscape = false;//可以撤离
        public ETeamType EscapeTeam = ETeamType.Enemy;//撤离的阵营
        public EPassType PassType = EPassType.AllPass;//全部通过
        public string PartPassJob = "";//部分通过职业
        public uint TopographyBuffId = 0;//地形BuffId
        public EDirection TopographyBuffDirection = EDirection.Up;//地形Buff朝向
        public bool IsShow = true;//是否显示
        //克隆
        public SlotConfig Clone()
        {
            var cloneconfig = new SlotConfig();
            cloneconfig.Direction = Direction;
            cloneconfig.AttachmentName = AttachmentName;
            cloneconfig.Index = Index;
            cloneconfig.RowNumber = RowNumber;
            cloneconfig.ColumnNumber = ColumnNumber;
            cloneconfig.CanDeployUnit = CanDeployUnit;
            cloneconfig.DeployTeam = DeployTeam;
            cloneconfig.CanEscape = CanEscape;
            cloneconfig.EscapeTeam = EscapeTeam;
            cloneconfig.PassType = PassType;
            cloneconfig.PartPassJob = PartPassJob;
            cloneconfig.TopographyBuffId = TopographyBuffId;
            cloneconfig.TopographyBuffDirection = TopographyBuffDirection;
            cloneconfig.IsShow = IsShow;
            return cloneconfig;
        }
        //拷贝值
        public void CopyValue(SlotConfig value)
        {
            this.Direction = value.Direction;
            this.AttachmentName = value.AttachmentName;
            this.Index = value.Index;
            this.RowNumber = value.RowNumber;
            this.ColumnNumber = value.ColumnNumber;
            this.CanDeployUnit = value.CanDeployUnit;
            this.DeployTeam = value.DeployTeam;
            this.CanEscape = value.CanEscape;
            this.EscapeTeam = value.EscapeTeam;
            this.PassType = value.PassType;
            this.PartPassJob = value.PartPassJob;
            this.TopographyBuffId = value.TopographyBuffId;
            this.TopographyBuffDirection = value.TopographyBuffDirection;
            this.IsShow = value.IsShow;
        }
    }
}
