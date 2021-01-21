using System;
using System.Collections.Generic;
using System.Text;

namespace OMS.ApplicationCore
{
    public class Util
    {

        public static bool UserPasswordValid(string password,string userPasswordSolution)
        {
            if (userPasswordSolution == "0")
            {
                return true;
            }
            else if (userPasswordSolution == "1")
            {
                //登陆密码要求至少8位，且包含大写字母、小写字母、数字或特殊符号中的三个
                if (password.Length < 8)
                    return false;

                int iNum = 0, iLttU = 0, iLttL = 0, iSym = 0;
                foreach (char c in password)
                {
                    if (c >= '0' && c <= '9') iNum = 1;
                    else if (c >= 'a' && c <= 'z') iLttL = 1;
                    else if (c >= 'A' && c <= 'Z') iLttU = 1;
                    else iSym = 1;
                }

                if (iNum + iLttU + iLttL + iSym >= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
