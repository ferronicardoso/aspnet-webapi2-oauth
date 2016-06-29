namespace System
{
    using Security.Cryptography;
    using Text;

    public static class SystemExtensions
    {
        public static string ToMD5(this string value)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(value);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            string newValue = sb.ToString();
            return newValue.ToLower();
        }
    }
}