using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Levels.Trigger
{
    //角色移动到角色
    public class RoleMove2RoleEventResultConfig : ResultConfig
    {
        public const string Name = "角色到角色";
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>移动角色ID</UText><URoleSelect id='1'>$property$</URoleSelect></UContainer>")]
        public string RoleId;//移动角色ID
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>目标角色ID</UText><URoleSelect id='2'>$property$</URoleSelect></UContainer>")]
        public string TargetId;//目标角色ID
        [ConfigAttribute("<UContainer style='layout:horizontal'><UText>间隔格子数</UText><UInputField valuetype='int'>$property$</UInputField></UContainer>")]
        public int RolesSlotInterval;//角色和目标角色之间的间隔格子数.
        public override string GetName { get { return RoleMove2RoleEventResultConfig.Name; } }//结果事件名
    }
}