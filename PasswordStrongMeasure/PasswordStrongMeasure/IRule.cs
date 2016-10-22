using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordStrongMeasure
{
    public interface IRule
    {
        int ScorePassword(string pwd);
    }
}
