
namespace Helper
{
    public class MD5
    {
        //转换明文到MD5
        public static string ConvertToMD5(string plainTxt)
        {
            //获取加密服务  
            System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
            //获取要加密的字段，并转化为Byte[]数组  
            byte[] plainBytes = System.Text.Encoding.Unicode.GetBytes(plainTxt);
            //加密Byte[]数组  
            byte[] resultBytes = md5CSP.ComputeHash(plainBytes);
            //将加密后的数组转化为字段(普通加密)  
            return System.Text.Encoding.Unicode.GetString(resultBytes);
        }
    }
}