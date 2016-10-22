using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordStrongMeasure
{
    public partial class ucPwdStrongShower : UserControl
    {
        public ucPwdStrongShower()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        private int m_pwsLevelAmount = 1;
        public int PasswordStrongLevelAmount
        {
            get 
            {
                return m_pwsLevelAmount;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("密码强度等级必须是大于0的整数");
                }

                m_pwsLevelAmount = value;
                Invalidate(this.ClientRectangle);
            }
        }

        private int m_pwdLevel = 0;
        public int PasswordStrongLevel
        {
            get
            {
                return m_pwdLevel;
            }
            set
            {
                if (m_pwdLevel < 0 || m_pwdLevel > m_pwsLevelAmount)
                {
                    throw new ArgumentOutOfRangeException("PasswordStringLevel");
                }

                m_pwdLevel = value;
                Invalidate(this.ClientRectangle);
            }
        }

        private Color m_pwdColor = Color.Green;
        public Color PasswordColor
        {
            get
            {
                return m_pwdColor;
            }
            set
            {
                m_pwdColor = value;
                Invalidate(this.ClientRectangle);
            }
        }

        private bool m_error = false;

        private const int SPLIT_WIDTH = 2;

        private void ucPwdStrongShower_Paint(object sender, PaintEventArgs e)
        {
            if (m_error)
            {
                return;
            }

            int w = Convert.ToInt32(Width / m_pwsLevelAmount) - SPLIT_WIDTH;
            SolidBrush sb=new SolidBrush(this.BackColor);
            SolidBrush sbFore = new SolidBrush(m_pwdColor);

            try
            {
                e.Graphics.FillRectangle(sb, this.ClientRectangle);

                int start = 0;

                for (int i = 0; i < m_pwdLevel; i++)
                {
                    e.Graphics.FillRectangle(sbFore, start, 0, w, this.Height);
                    start += w + SPLIT_WIDTH;
                }
            }
            catch(Exception ex)
            {
                m_error = true;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sb.Dispose();
                sbFore.Dispose();
            }
        }
    }
}
