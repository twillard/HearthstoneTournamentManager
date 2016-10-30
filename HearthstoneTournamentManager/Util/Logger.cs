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
        private bool m_debug;

        public Logger(System.Windows.Forms.TextBox logTextbox)
        {
            m_logTextBox = logTextbox;
            m_messageNum = 0;
            m_debug = false;
        }

        public void LogInfo(string message)
        {
            Log("Info: " + message);
        }

        public void LogError(string message)
        {
            Log("ERROR: " + message);
        }

        public void SetDebugEnabled(bool enabled)
        {
            m_debug = enabled;
        }

        public void LogDebug(string message)
        {
            if (m_debug)
            {
                Log("Debug: " + message);
            }
        }

        private void Log(string message)
        {
            m_logTextBox.AppendText(String.Format("[{0:000}]: {1}\r\n", m_messageNum, message));
            ++m_messageNum;
        }
    }
}
