using System.Collections.Generic;
namespace Msg {
    public class MailInfo {
        public string mailGid = "";   //邮件唯一GID
        public int mailId = 0;  //邮件模板id
        public int state = 0;//邮件状态
        public string sendTime = "";//发送时间
        public Dictionary<string, string> replaceContent = new Dictionary<string, string>(); // 模板替换内容字典
        public List<string> append = new List<string>();   //邮件附件
    }
}