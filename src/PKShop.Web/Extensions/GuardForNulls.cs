using System;

namespace PKShop.Web.Extensions
{
    public static class GuardForNulls
    {
        public static void CheckForNulls(this object obj, string name)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
