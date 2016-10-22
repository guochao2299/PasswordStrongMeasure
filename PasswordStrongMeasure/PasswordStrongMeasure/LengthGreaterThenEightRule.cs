using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordStrongMeasure
{
    /// <summary>
    /// 密码长度超过8个字符
    /// </summary>
    public class LengthGreaterThenEightRule:IRule
    {

        public int ScorePassword(string pwd)
        {
            if (string.IsNullOrEmpty(pwd))
            {
                return 0;
            }

            return pwd.Length > 8 ? 1 : 0;
        }
    }
}
