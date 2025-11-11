using System;
using System.Drawing;
using System.Windows.Forms;

namespace Form_Test
{
    public class TestButton : Button
    {
        private Color _onColor = Color.LightBlue;
        private Color _offColor = Color.DarkBlue;
        private bool _enable;
        private Form1 _form1;
        private int _x;
        private int _y;

        public bool IsEnabled()
        {
            return _enable;
        }

        public void SetEnable(bool on)
        {
            _enable = on;
            BackColor = on ? _onColor : _offColor;
        }

        public void Togle()
        {
            SetEnable(!_enable);
        }

        public TestButton(Form1 form1, int x, int y, Size size, string text)
        {
            _x = x;
            _y = y;
            _form1 = form1;
            Location = new Point(x * size.Width, y * size.Height);
            Size = size;
            Text = text;
            SetEnable(false);
            Click += ClickEvent;
        }

        private void ClickEvent(object sender, EventArgs e)
        {
            _form1.GetTestButton(_x, _y)?.Togle();
            _form1.GetTestButton(_x + 1, _y)?.Togle();
            _form1.GetTestButton(_x - 1, _y)?.Togle();
            _form1.GetTestButton(_x, _y + 1)?.Togle();
            _form1.GetTestButton(_x, _y - 1)?.Togle();

            _form1.CheckClear();
        }
    }
}