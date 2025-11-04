using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

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

        public void SetEnable(bool on)
        {
            _enable = on;
            if (on)
            {
                BackColor = _onColor;
            }
            else
            {
                BackColor = _offColor;
            }
        }

        public void Togle() 
        {
            SetEnable(!_enable);
        }

        public TestButton(Form1 form1,int x,int y,Size size, string text)
        {
            //横位置を保管
            _x = x;
            
            //縦位置を保管
            _y = y;

            //Form1の参照を保管
            _form1 = form1;

            // ボタンの位置を設定
            Location = new Point(x * size.Width,y * size.Height);

            // ボタンの大きさを設定
            Size = size;

            // ボタン内のテキストを設定
            Text = text;

            SetEnable(false);

            Click += ClickEvent;
        }

        private void ClickEvent(object sender, EventArgs e)
        {
            _form1.GetTestButton(_x,_y)?.Togle();
            _form1.GetTestButton(_x+1,_y)?.Togle();
            _form1.GetTestButton(_x-1,_y)?.Togle();
            _form1.GetTestButton(_x,_y+1)?.Togle();
            _form1.GetTestButton(_x,_y-1)?.Togle();
        }
    }
}

