using System.Collections.Generic;
namespace Msg {
    public class MailExpirationInfo {
        public string mailGid = "";   //邮件唯一GID
        public List<int> appendIds = new List<int>(); // 过期的附件信息
    }
}