using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PasswordStrongMeasure;

namespace TestPassword
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            txtPwd.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RuleManager.AddRule(new HasDigitRule());
            RuleManager.AddRule(new HasLowerUpperCharRule());
            RuleManager.AddRule(new HasSpecialCharRule());
            RuleManager.AddRule(new LengthGreaterThenEightRule());
            RuleManager.AddRule(new LengthGreaterThenTwelveRule());

            this.psShower.PasswordStrongLevelAmount = 5;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.psShower.PasswordStrongLevel = RuleManager.CalculatePasswordStrongPoint(txtPwd.Text);
            this.lblResult.Text = string.Format("密码强度检测得分为{0}", this.psShower.PasswordStrongLevel);
        }


    }
}
