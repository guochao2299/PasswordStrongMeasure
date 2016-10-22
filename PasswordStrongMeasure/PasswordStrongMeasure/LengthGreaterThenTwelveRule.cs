using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordStrongMeasure
{
    /// <summary>
    /// 密码长度超过12个字符
    /// </summary>
    public class LengthGreaterThenTwelveRule:IRule
    {
        public int ScorePassword(string pwd)
        {
            if (string.IsNullOrEmpty(pwd))
            {
                return 0;
            }

            return pwd.Length > 12 ? 1 : 0;
        }
    }
}
