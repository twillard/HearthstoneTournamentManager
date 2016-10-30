using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Logger
    {
        private System.Windows.Forms.RichTextBox m_logTextBox;
        private int m_messageNum;
        private bool m_debug;

        public Logger(System.Windows.Forms.RichTextBox logTextbox)
        {
            m_logTextBox = logTextbox;
            m_messageNum = 0;
            m_debug = false;
        }

        public void LogInfo(string message)
        {
            AppendMessageNum();
            Log(message);
        }

        public void LogError(string message)
        {
            AppendMessageNum();
            AppendText("ERROR: ", Color.Red);
            Log(message);
        }

        public void SetDebugEnabled(bool enabled)
        {
            m_debug = enabled;
        }

        public void LogDebug(string message)
        {
            if (m_debug)
            {
                AppendMessageNum();
                AppendText("Debug: ", Color.Purple);
                Log(message);
            }
        }

        private void AppendText(string text, Color color)
        {
            m_logTextBox.SelectionStart = m_logTextBox.TextLength;
            m_logTextBox.SelectionLength = 0;

            m_logTextBox.SelectionColor = color;
            m_logTextBox.AppendText(text);
            m_logTextBox.SelectionColor = m_logTextBox.ForeColor;
        }

        private void AppendMessageNum()
        {
            m_logTextBox.AppendText(String.Format("[{0:000}]: ", m_messageNum));
            ++m_messageNum;
        }

        private void Log(string message)
        {
            m_logTextBox.AppendText(message);
            m_logTextBox.AppendText(Environment.NewLine);

            // set the current caret position to the end
            m_logTextBox.SelectionStart = m_logTextBox.Text.Length;
            // scroll it automatically
            m_logTextBox.ScrollToCaret();
        }
    }
}
