using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordStrongMeasure
{
    public class HasDigitRule:IRule
    {
        public int ScorePassword(string pwd)
        {
            if (string.IsNullOrEmpty(pwd))
            {
                return 0;
            }

            foreach (char c in pwd)
            {
                if (char.IsDigit(c))
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
