using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordStrongMeasure
{
    public class HasLowerUpperCharRule:IRule
    {
        public int ScorePassword(string pwd)
        {
            if (string.IsNullOrEmpty(pwd))
            {
                return 0;
            }

            bool hasLowerChar = false;
            bool hasUpperChar = false;

            foreach (char c in pwd)
            {
                if(!char.IsLetter(c))
                {
                    continue;
                }

                if (char.IsLower(c))
                {
                    hasLowerChar = true;
                }
                else if (char.IsUpper(c))
                {
                    hasUpperChar = true;
                }
            }

            return (hasUpperChar && hasLowerChar) ? 1 : 0;
        }
    }
}
