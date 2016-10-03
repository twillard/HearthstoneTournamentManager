using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Logger
    {
        private System.Windows.Forms.TextBox m_logTextBox;
        private int m_messageNum;

        public Logger(System.Windows.Forms.TextBox logTextbox)
        {
            m_logTextBox = logTextbox;
            m_messageNum = 0;
        }

        public void Log(string message)
        {
            m_logTextBox.Text = String.Format("[{0:000}]: {1}\r\n", m_messageNum, message) + m_logTextBox.Text;
            ++m_messageNum;
        }
    }
}
