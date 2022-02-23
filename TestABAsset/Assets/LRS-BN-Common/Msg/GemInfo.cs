namespace Msg {
    public class GemInfo {
        public string gemGid = "";   //宝石唯一ID
        public int mGemId = 0;  //宝石编号1红色,2橙色,3绿色,4蓝色,5紫色,6黄色,7彩色
        public int level = 0;     //宝石等级
        public string addNatureConfig = "";//增加属性
        public int upGradeNeedNum = 0;   //升级需要的低级宝石个数
        public int bagItemId = 0;//背包id
        public string text = "";//描述 
        public int count = 0;//数量
        public int isInlay = 0; // 是否可以镶嵌 1可镶嵌，0不可以镶嵌
    }
}