using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Corners;
using MainMenu = Corners.MainMenu;

namespace CornersGame
{
    public partial class Settings : Form
    {
        
        const int boardsize = 8;
        string form, theme;
        public int[,] board;

        Color bright;
        Color dark;

        public int[,] Board
        {
            get //чтение значения
            {
                return board;
            }
            set //ввод или изменение значения
            {
                board = value;
            }
        }
        public Color Bright
        {
            get //чтение значения
            {
                return bright;
            }
            set //ввод или изменение значения
            {
                bright = value;
            }
        }
        public Color Dark
        {
            get //чтение значения
            {
                return dark;
            }
            set //ввод или изменение значения
            {
                dark = value;
            }
        }

        public Settings() //конструктор без параметров
        {
            InitializeComponent();
            ShowIcon = false;
            comboBox1.Text = Data.Format.ToString();
            comboBox1.SelectionLength = 0;

            comboBox2.Text = Data.Theme.ToString();
            board = new int[boardsize, boardsize] {
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
            };
            bright = Color.White;
            dark = Color.Gray;
        }

        public Settings(int[,] b, Color br, Color dr) //конструктор с параметрами
        {
            InitializeComponent();
            ShowIcon = false;
            comboBox1.Text = Data.Format.ToString();
            comboBox2.Text = Data.Theme.ToString();
            Board = b;
            Bright = br;
            Dark = dr;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            form = comboBox1.Text;
            board = Format(form);  
        }

        static int[,] Format(string form)
        {
            int[,] board;
            if (form == "9x9")
            {
                return board = new int[boardsize, boardsize] {
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
            };
            }
            if (form == "10x10")
            {
                return board = new int[boardsize, boardsize] {
                {0,0,0,0,1,1,1,1 },
                {0,0,0,0,0,1,1,1 },
                {0,0,0,0,0,0,1,1 },
                {0,0,0,0,0,0,0,1 },
                {2,0,0,0,0,0,0,0 },
                {2,2,0,0,0,0,0,0 },
                {2,2,2,0,0,0,0,0 },
                {2,2,2,2,0,0,0,0 },
                 };
            }
            if (form == "12x12")
            {
                return board = new int[boardsize, boardsize] {
                {0,0,0,0,1,1,1,1 },
                {0,0,0,0,1,1,1,1 },
                {0,0,0,0,1,1,1,1 },
                {0,0,0,0,0,0,0,0 },
                {0,0,0,0,0,0,0,0 },
                {2,2,2,2,0,0,0,0 },
                {2,2,2,2,0,0,0,0 },
                {2,2,2,2,0,0,0,0 },
              };
            }

            else return board = new int[boardsize, boardsize] {
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
            };
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            Settings s = new Settings(board, bright, dark);
            this.Visible = false;
            MainMenu f2 = new Corners.MainMenu();
            f2.Show();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            theme = comboBox2.Text;
            bright = BoardThemeBr(theme);
            dark = BoardThemeDr(theme);
            
        }

        static Color BoardThemeBr(string theme)
        {
            if (theme == "Ночь")
            {
                return Color.Gray;
            }
            if (theme == "Утро")
            {
                return Color.BlanchedAlmond;
            }
            if (theme == "День")
            {
                return Color.LightSkyBlue;
            }
            if (theme == "Вечер")
            {
                return Color.PaleVioletRed;
            }
            else
            {
                return Color.White;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings changed = new Settings(board, bright, dark);
            //this.Visible = false;
            
            Data.Board = changed.board;
            Data.BrightColor = changed.bright;
            Data.DarkColor = changed.dark;
            Data.Format = form;
            Data.Theme = theme; 
        }

        static Color BoardThemeDr(string theme) 
        {
            if (theme == "Ночь")
            {
                return Color.MidnightBlue;
            }
            if (theme == "Утро")
            {
                return Color.Salmon;
            }
            if (theme == "День")
            {
                return Color.Green;
            }
            if (theme == "Вечер")
            {
                return Color.Crimson;
            }
            else
            {
                return Color.Gray;
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}
