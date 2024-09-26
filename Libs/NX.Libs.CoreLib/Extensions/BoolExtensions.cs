namespace NX.Libs.CoreLib.Extensions
{
    public static class BoolExtensions
    {
        public static bool isTrue(this string str)
        {
            string strTrimed = str.Trim();
            if (strTrimed != string.Empty && strTrimed != null && strTrimed.ToLower().Equals("true")) return true;
            else return false;
        }
    }
}
