using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace Form_Test
{
    internal class TestButton : Button
    {
        /// <summary>onの時の色</summary>
        private Color _onColor = Color.LightBlue;

        /// <summary>offの時の色</summary>
        private Color _offColor = Color.DarkBlue;

        /// <summary>現在OnかOffか</summary>
        private bool _enable;


        /// <summary>onとoffの設定</summary> 
        /// <param name="on"></param>
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
        public TestButton(Point position, Size size, string text)
        {
            // ボタンの位置を設定
            Location = position;
            // ボタンの大きさを設定
            Size = size;
            // ボタン内のテキストを設定
            Text = text;

            SetEnable(false);

            Click += ClickEvent;
        }
        private void ClickEvent(object sender, EventArgs e)
        {
            SetEnable(!_enable);
        }
    }
}

