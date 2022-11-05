using System.Diagnostics;

namespace okenko
{
    public partial class Form1 : Form
    {

        //Dictionary<int, Button> buttons = new Dictionary<int, Button>();
        Button[,] buttons = new Button[4, 4];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int title = 3;
            for (int i = 0; i < 8; i++)
            {
                title *= 3;
            }
            Text = "0x" + title.ToString("X2");
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    buttons[x, y] = new Button();
                    buttons[x, y].Size = new Size(48, 48);
                    buttons[x, y].Location = new Point(12 + x * 48, 12 + y * 48);
                    buttons[x, y].Enabled = false;
                    Controls.Add(buttons[x,y]);
                }
            }
            GenerateRandom(2);
        }
        Random random = new Random();
        Random rnd = new Random();
        private void GenerateRandom(int count)
        {
            for (int j = 0; j < count; j++)
            {
                int rx = random.Next(0, 4);
                int ry = random.Next(0, 4);
                if (buttons[rx, ry].Text == "")
                {
                    buttons[rx, ry].Text = ((int)Math.Pow(3, rnd.Next(1, 3))).ToString("X2");
                    continue;
                }
                j--;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Up();
                    break;
                case Keys.Down:
                    Down();
                    break;
                case Keys.Left:
                    mvLeft();
                    break;
                case Keys.Right:
                    mvRight();
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        private void Up()
        {
            bool moving = true;
            while (moving)
            {
                moving = false;
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (buttons[x, y].Text == "")
                        {
                            buttons[x, y].Text = buttons[x, y + 1].Text;
                            buttons[x, y + 1].Text = "";
                            if (buttons[x, y].Text != "") moving = true;
                        }
                        else if (buttons[x, y].Text == buttons[x, y + 1].Text)
                        {
                            buttons[x, y].Text = (int.Parse(buttons[x, y].Text, System.Globalization.NumberStyles.HexNumber) * 3).ToString("X2");
                            buttons[x, y + 1].Text = "";
                            moving = true;
                        }
                    }
                }
            }
            GenerateRandom(1);
            bool end = true;
            foreach (Button btn in buttons)
            {
                if (btn.Text == "")
                {
                    end = false;
                }
            }
            if (end)
            {
                End();
            }
        }

        private void Down()
        {
            bool moving = true;
            while (moving)
            {
                moving = false;
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 1; y < 4; y++)
                    {
                        if (buttons[x, y].Text == "")
                        {
                            buttons[x, y].Text = buttons[x, y - 1].Text;
                            buttons[x, y - 1].Text = "";
                            if (buttons[x, y].Text != "") moving = true;
                        }
                        else if (buttons[x, y].Text == buttons[x, y - 1].Text)
                        {
                            buttons[x, y].Text = (int.Parse(buttons[x, y].Text, System.Globalization.NumberStyles.HexNumber) * 3).ToString("X2");
                            buttons[x, y - 1].Text = "";
                            moving = true;
                        }
                    }
                }
            }
            GenerateRandom(1);
            bool end = true;
            foreach (Button btn in buttons)
            {
                if (btn.Text == "")
                {
                    end = false;
                }
            }
            if (end)
            {
                End();
            }
        }

        private void mvLeft()
        {
            bool moving = true;
            while (moving)
            {
                moving = false;
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (buttons[x, y].Text == "")
                        {
                            buttons[x, y].Text = buttons[x + 1, y].Text;
                            buttons[x + 1, y].Text = "";
                            if (buttons[x, y].Text != "") moving = true;
                        }
                        else if (buttons[x, y].Text == buttons[x + 1, y].Text)
                        {
                            buttons[x, y].Text = (int.Parse(buttons[x, y].Text, System.Globalization.NumberStyles.HexNumber) * 3).ToString("X2");
                            buttons[x + 1, y].Text = "";
                            moving = true;
                        }
                    }
                }
            }
            GenerateRandom(1);
            bool end = true;
            foreach (Button btn in buttons)
            {
                if (btn.Text == "")
                {
                    end = false;
                }
            }
            if (end)
            {
                End();
            }
        }

        private void mvRight()
        {
            bool moving = true;
            while (moving)
            {
                moving = false;
                for (int x = 1; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (buttons[x, y].Text == "")
                        {
                            buttons[x, y].Text = buttons[x - 1, y].Text;
                            buttons[x - 1, y].Text = "";
                            if (buttons[x, y].Text != "") moving = true;
                        }
                        else if (buttons[x, y].Text == buttons[x - 1, y].Text)
                        {
                            buttons[x, y].Text = (int.Parse(buttons[x, y].Text, System.Globalization.NumberStyles.HexNumber) * 3).ToString("X2");
                            buttons[x - 1, y].Text = "";
                            moving = true;
                        }
                    }
                }
            }
            GenerateRandom(1);
            bool end = true;
            foreach (Button btn in buttons)
            {
                if (btn.Text == "")
                {
                    end = false;
                }
            }
            if (end)
            {
                End();
            }
        }

        private void End()
        {
            DialogResult result = MessageBox.Show("You're trash.\nTry again?", "GG", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) Application.Restart();
            Application.Exit();
        }
    }
}