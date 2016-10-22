using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordStrongMeasure
{
    public static class RuleManager
    {
        private static List<IRule> m_rules = new List<IRule>();

        public static void AddRule(IRule rule)
        {
            m_rules.Add(rule);
        }

        public static void AddRules(IEnumerable<IRule> rules)
        {
            m_rules.AddRange(rules);
        }

        public static int CalculatePasswordStrongPoint(string password)
        {
            return CalculatePasswordStrongPoint(password, m_rules);
        }

        public static int CalculatePasswordStrongPoint(string password, IEnumerable<IRule> rules)
        {
            if (string.IsNullOrEmpty(password) || rules == null)
            {
                return 0;
            }

            int point = 0;

            foreach (IRule rule in m_rules)
            {
                point += rule.ScorePassword(password);
            }

            return point;
        }

    }
}
