using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigBridge
{
    public class Web4Config
    {
        public static List<string> specialRole = new List<string>() { "站点_", "地图_" };

        public static bool IsSpecialRole(string role)
        {
            for (int i = 0; i < specialRole.Count; i++)
            {
                if (role.StartsWith(specialRole[i]))
                    return true;
            }

            return false;
        }
    }
}
