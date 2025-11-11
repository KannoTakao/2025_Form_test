using System;
using System.Drawing;
using System.Windows.Forms;

namespace Form_Test
{
    public partial class Form1 : Form
    {
        const int BUTTON_SIZE_X = 100;
        const int BUTTON_SIZE_Y = 100;
        const int BOARD_SIZE_X = 3;
        const int BOARD_SIZE_Y = 3;

        private TestButton[,] _buttonArray;
        private Random _random = new Random();

        public Form1()
        {
            InitializeComponent();
            _buttonArray = new TestButton[BOARD_SIZE_Y, BOARD_SIZE_X];

            for (int i = 0; i < BOARD_SIZE_X; i++)
            {
                for (int j = 0; j < BOARD_SIZE_Y; j++)
                {
                    TestButton testButton = new TestButton(this, i, j, new Size(BUTTON_SIZE_X, BUTTON_SIZE_Y), "");
                    _buttonArray[j, i] = testButton;
                    Controls.Add(testButton);
                }
            }

            InitializeBoard();
        }

        public TestButton GetTestButton(int x, int y)
        {
            if (x < 0 || x >= BOARD_SIZE_X) return null;
            if (y < 0 || y >= BOARD_SIZE_Y) return null;
            return _buttonArray[y, x];
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < BOARD_SIZE_X; i++)
            {
                for (int j = 0; j < BOARD_SIZE_Y; j++)
                {
                    bool randomButton = _random.Next(2) == 0;
                    GetTestButton(i, j).SetEnable(randomButton);
                }
            }
        }

        public void CheckClear()
        {
            bool message = _buttonArray[0, 0].IsEnabled();
            foreach(var DiggyMo in _buttonArray)
            {
                if ( DiggyMo.IsEnabled() != message)
                    return;
            }

            MessageBox.Show("クリアしました！");
            InitializeBoard();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}