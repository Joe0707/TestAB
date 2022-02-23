using System.Collections.Generic;
namespace Msg {
    /**功能npc对话信息 */
    public class FuncNpcDialogInfo {
        public int funcIdNpcId = 0;//功能ID和NPC的ID组合值
        public List<DialogInfo> dialogIdList = new List<DialogInfo>();//对话信息列表
    }
}