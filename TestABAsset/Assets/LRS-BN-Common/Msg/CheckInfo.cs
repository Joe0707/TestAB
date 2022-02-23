using System.Collections.Generic;
namespace Msg {
    //检查器信息
    public class CheckInfo {
        public string checkGid = "";                                    //检查器的唯一ID，检查器有可能同时存在多个同类型的
        public string checkType = "";                                   //检查器的类型，用来匹配检查器的检查条件描述和检查逻辑
        public int state = 0;                                           //检查结果 0.成功 1.失败 
        public string param = "[]";                                     //检查器的参数，JSON字符串
        public string valueHash = "[]";                                 //检查器的持久化数据，JSON字符串
    }
}