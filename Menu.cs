using CornersGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Corners
{
    public partial class MainMenu : Form
    {

        public MainMenu()
        {
            InitializeComponent();
            ShowIcon = false;
        }

        private void button_GameStart_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //Settings newwindow = new Settings();
            //newwindow.Owner = this;
            //newwindow.ShowDialog();
            this.Visible = false;
            Main newgame = new Main();
            newgame.Owner = this;
            newgame.ShowDialog();

        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button_Settings_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Settings newwindow = new Settings();
            newwindow.Owner = this;
            newwindow.ShowDialog();
        }

        private void button_Records_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Records newwindow = new Records();
            newwindow.Owner = this;
            newwindow.ShowDialog();
        }

        private void button_Rules_Click(object sender, EventArgs e)
        {
            string message = "Цель игры - быстрее оппонента передвинуть все свои шашки на то место, где изначально располагались его фигуры. \n\nКаждый игрок может за один ход переместить одну шашку. \n\nШашки перемещаются вертикально и горизонтально на соседнюю пустую клетку. \n\nШашки могут перепрыгивать через свои и чужие фигуры, если за фигурой есть пустая клетка. Число прыжков за ход для одной шашки не ограничивается.";
            string caption = "Правила игры Уголки";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Information);

        }
    }
}
