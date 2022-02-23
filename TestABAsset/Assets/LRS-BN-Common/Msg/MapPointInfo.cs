using System.Collections.Generic;
namespace Msg {
    /**大地图上的点(城市点)信息 */
    public class MapPointInfo {
		/** 城市点唯一ID */
		public string pointGid = "";
        /**大地图唯一ID */
        public string mapGid = "";
        /**大地图ID */
        public int mapId = 0;
        /**大地图路点ID */
        public int mapPointId = 0;
        /**路点类型 */
        public int pointType = 0;
        /**路点功能ID串,该路点有几个功能 */
        public List<string> pointFunctionIds = new List<string>();
		/**路点随机任务ID列表 */
		public List<int> taskIds = new List<int>();
        /**功能点中npc的对话信息列表 */
        public List<FuncNpcDialogInfo> funcNpcDialogInfo = new List<FuncNpcDialogInfo>();
    }
}