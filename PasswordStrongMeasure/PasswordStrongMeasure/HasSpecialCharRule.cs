using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordStrongMeasure
{
    public class HasSpecialCharRule:IRule
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
                    continue;
                }

                if (char.IsLetter(c))
                {
                    continue;
                }

                return 1;
            }

            return 0;
        }
    }
}
