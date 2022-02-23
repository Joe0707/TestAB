using System.Collections.Generic;
namespace Msg {
    /**大地图信息 */
    public class MapInfo {
        /**大地图唯一ID */
        public string mapGid = "";
        /**大地图ID */
        public int mapId = 0;
        /**大地图路点ID */
        public int mapPointId = 0;
        /**地图点ID列表(已开启的) */
        public List<MapPointInfo> mapPointInfos = new List<MapPointInfo>();
    }
}