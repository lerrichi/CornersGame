using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Corners;
using MainMenu = Corners.MainMenu;

namespace CornersGame
{
    public partial class Records : Form
    {
        public Records()
        {
            InitializeComponent();
            ShowIcon = false;

            StreamReader f = new StreamReader("TextFile.txt");
            string s = f.ReadToEnd(); // Считывает все символы, начиная с текущей позиции до конца потока
            int[] arr = null; // только объявили пустую структуру, без выделения памяти 
            arr = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n.Trim())).ToArray();
            int a = arr[0]; //всего парий
            int b = arr[1]; //побед белых
            int c = arr[2]; //побед черных
            label1.Text = a.ToString();
            label2.Text = b.ToString();
            label3.Text = c.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MainMenu newgame = new MainMenu();
            newgame.Owner = this;
            newgame.ShowDialog();
        }
    }
}
