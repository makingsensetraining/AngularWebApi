namespace Hiperion.Infrastructure.Security
{
    #region References

    using System.Security.Cryptography;
    using System.Text;

    #endregion

    public class SecurityHelper
    {
        public static string CalculateMD5Hash(string value)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}