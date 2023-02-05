using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Corners;
using MainMenu = Corners.MainMenu;


namespace CornersGame
{
    public partial class Main : Form
    {
        const int boardsize = 8;
        const int cellsize = 50;
        
        int currentPlayer;
        Button Prev;
        bool isMoving;

        int[,] board = new int[boardsize, boardsize];

        Button[,] buttons = new Button[boardsize, boardsize]; 

        Image whiteFigure;
        Image blackFigure;
        string form = Data.Format;
        
        List<int[]> steps = new List<int[]>(); //Здесь хранятся доступные ходы




        public Main()
        {
            InitializeComponent();
            ShowIcon = false;

            whiteFigure = new Bitmap(Properties.Resources.w);
            blackFigure = new Bitmap(Properties.Resources.b);
            this.Text = "Уголки";

            label2.Text = "Первыми ходят белые";
            label1.Visible = false;
            Init();
        }

        public void Init()
        {
            currentPlayer = 1;
            isMoving = false;
            Prev = null;

            board = Data.Board;

            LoadBoard();
        }

        public void LoadBoard()
        {
            this.Width = boardsize * cellsize;
            this.Height = 50 + boardsize * cellsize;

            for (int i = 0; i < boardsize; i++)
            {
                for (int j = 0; j < boardsize; j++)
                {
                    
                    Button button = new Button();
                    button.Location = new Point(j * cellsize, i * cellsize);
                    button.Size = new Size(cellsize, cellsize);
                    button.Click += new EventHandler(ChosenFigure);
                 
                    if (board[i, j] == 1)
                        button.BackgroundImage = whiteFigure;
                    else if (board[i, j] == 2) button.BackgroundImage = blackFigure;


                    button.BackColor = GetPrevButtonColor(button);
                    buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
        }

        public void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
            string player = null;
            if (currentPlayer == 1)
                player = "Ход белых";
            if (currentPlayer == 2)
                player = "Ход черных";
            label1.Text = player;
            label1.Visible = true;
        }

        public Color GetPrevButtonColor(Button Prev)
        {
            
            if ((Prev.Location.Y / cellsize) % 2 != 0)
            {
                if ((Prev.Location.X / cellsize) % 2 == 0)
                {
                    return Data.DarkColor;
                }
            }
            if ((Prev.Location.Y / cellsize) % 2 == 0)
            {
                if ((Prev.Location.X / cellsize) % 2 != 0)
                {
                    return Data.DarkColor;
                }
            }

            return Data.BrightColor;
        }

        public void ChosenFigure(object sender, EventArgs e)
        {
            label2.Visible = false;
                if (Prev != null)
                    Prev.BackColor = GetPrevButtonColor(Prev);
                Button chosen = sender as Button;
                if (board[chosen.Location.Y / cellsize, chosen.Location.X / cellsize] != 0 && board[chosen.Location.Y / cellsize, chosen.Location.X / cellsize] == currentPlayer)
                {
                    chosen.BackColor = Color.Red;
                    isMoving = true;
                    Prev = chosen;

                }
                else
                {
                    if (isMoving)
                    {
                        bool ok = CanMove(Prev.Location.X / cellsize, Prev.Location.Y / cellsize, chosen.Location.X / cellsize, chosen.Location.Y / cellsize);
                    if (ok)
                      {
                            int temp = board[chosen.Location.Y / cellsize, chosen.Location.X / cellsize];
                            board[chosen.Location.Y / cellsize, chosen.Location.X / cellsize] = board[Prev.Location.Y / cellsize, Prev.Location.X / cellsize];
                            board[Prev.Location.Y / cellsize, Prev.Location.X / cellsize] = temp;
                            chosen.BackgroundImage = Prev.BackgroundImage;
                            Prev.BackgroundImage = null;
                        isMoving = false;
                        SwitchPlayer();
                      }
                    }
                }
                
            
            int a = Winner();

                if (a != 0)
                {
                    int[] arr = null; // только объявили пустую структуру, без выделения памяти 

                    using (StreamReader f = new StreamReader("TextFile.txt"))
                    {
                        string s = f.ReadToEnd(); // Считывает все символы, начиная с текущей позиции до конца потока

                        arr = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n.Trim())).ToArray();
                        if (a == 1)
                        { arr[1]++; arr[0]++; }
                        if (a == 2)
                        { arr[2]++; arr[0]++; }
                    }

                    using (StreamWriter writer = new StreamWriter("TextFile.txt"))
                    {
                        string result = String.Join(" ", arr); ;
                        writer.Write(result);
                    }
                if (a == 1)
                { label1.Visible = false; label2.Visible = true; label2.Text = "Победили белые!!"; }
                if (a == 2)
                { label1.Visible = false; label2.Visible = true; label2.Text = "Победили черные!!"; }
            }
        }


        public bool CanMove(int X, int Y, int X1, int Y1) //обычный ход
        {
            bool ok = false;
            int[] arr = null;
            steps = NormalMove(X, Y);
            int s = steps.Count;
            for (int i = 0; i < s; i++)
            {
                if (steps[i] == arr)
                { steps.RemoveRange(i, 1); i--; s = steps.Count; }
            }
            for (int i = 0; i < steps.Count; i++)
            { if (steps[i][0] == Y1 && steps[i][1] == X1)
                { ok = true; break; }
                else
                    ok = false;
            }
            return ok;
        }


        public int Winner() 
        {
            int countBlack = 0;
            int countWhite = 0;
            int winner = 0;

            if (form == "9x9")
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 5; j < boardsize; j++)
                    {
                        if (board[i, j] == 2)
                            countBlack++;
                    }
                }

                for (int i = 5; i < boardsize; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == 1)
                            countWhite++;
                    }
                }
                if (countBlack == 9)
                    winner = 2;
                if (countWhite == 9)
                    winner = 1;
                else winner = 0;
            }
            if (form == "12x12")
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 4; j < boardsize; j++)
                    {
                        if (board[i, j] == 2)
                            countBlack++;
                    }
                }

                for (int i = 5; i < boardsize; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (board[i, j] == 1)
                            countWhite++;
                    }
                }
                if (countBlack == 12)
                    winner = 2;
                if (countWhite == 12)
                    winner = 1;
                else winner = 0;
            }
            if (form == "10x10")
            {
                for (int i = 0; i < 1; i++) //первая строчка
                {
                    for (int j = 4; j < boardsize; j++)
                    {
                        if (board[i, j] == 2)
                            countBlack++;
                    }
                }
                for (int i = 1; i < 2; i++) //вторая строчка
                {
                    for (int j = 5; j < boardsize; j++)
                    {
                        if (board[i, j] == 2)
                            countBlack++;
                    }
                }
                for (int i = 2; i < 3; i++) //третья строчка
                {
                    for (int j = 6; j < boardsize; j++)
                    {
                        if (board[i, j] == 2)
                            countBlack++;
                    }
                }
                for (int i = 3; i < 4; i++) //четвертая строчка
                {
                    for (int j = 7; j < boardsize; j++)
                    {
                        if (board[i, j] == 2)
                            countBlack++;
                    }
                }

                for (int i = 4; i < 5; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        if (board[i, j] == 1)
                            countWhite++;
                    }
                }
                for (int i = 5; i < 6; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (board[i, j] == 1)
                            countWhite++;
                    }
                }
                for (int i = 6; i < 7; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == 1)
                            countWhite++;
                    }
                }
                for (int i = 7; i < boardsize; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (board[i, j] == 1)
                            countWhite++;
                    }
                }
                if (countBlack == 10)
                    winner = 2;
                if (countWhite == 10)
                    winner = 1;
                if (countBlack != 10 && countWhite != 10) winner = 0;
            }

            return winner;
            

        }

        public List<int[]> NormalMove(int A, int B) // нахождение возможных ходов
        {
            // "поворот" обхода
            var rote = 1;
            // флаг, то что ближайшиее искать не стоит
            // при обходе, после "прыжка"
            var flag = 0;
            int[] arr = null;
            int X, Y;
            // Данный массив хранит цепочку обхода элементов, при нахождении всех возможных вариантов
            
            List<int[]> path = new List<int[]>(); 
            path.Add(arr);
            path[0] = new int [2];
            path[0][0] = A;
            path[0][1] = B;
            // данный массив будет хранить "отработанные" клетки
            var traveled = new int [8, 8];

            
            for (var m = 0; m < 8; m++)
            {
                for (var n = 0; n < 8; n++)
                {
                    traveled[m, n] = 0;
                }
            }

            // РЕЗУЛЬТАТ работы данной функции, мвссив содержащий позиции клеток,
            // в которые можно сделать ход
            
            List<int[]> result = new List<int[]>(); //Здесь хранятся доступные ходы
            

            while (rote < 5)
            {
                X = path[0][0]; //i
                Y = path[0][1];//j

                if (rote == 1)
                {
                    if (X > 0 && board[Y, X - 1] == 0) 
                    {
                        if (flag == 0)
                        {
                            traveled[Y, X - 1] = 1;
                            int c = result.Count;
                            if (c == 0)
                            {
                                for (int i = 0; i < 1; i++)
                                    result.Add(arr);
                            }
                            else
                            {
                                for (int i = 0; i < c; i++)
                                    result.Add(arr);
                            }
                            result[c] = new int [2];
                            result[c][0] = Y;
                            result[c][1] = X - 1;
                        }
                    }
                    else
                    {
                        if (X > 1 && board[Y, X - 2] == 0 && traveled[Y, X - 2] == 0)
                        {
                            traveled[Y, X - 2] = 1; 
                            int rc = result.Count;
                            if (rc == 0)
                            {
                                for (int i = 0; i < 1; i++)
                                    result.Add(arr);
                            }
                            else {
                                for (int i = 0; i < rc; i++)
                                    result.Add(arr);
                            }
                            result[rc] = new int[2];
                            result[rc][0] = Y;
                            result[rc][1] = X - 2;
                            int pc = path.Count;
                            for (int i = 0; i < 2; i++)
                                path.Add(arr);
                            path[pc] = new int [2];
                            path[pc][1] = Y;
                            path[pc][0] = X - 2;
                        }
                    }
                }
                else
                {
                    if (rote == 2)
                    {
                        if ((Y + 1) < 8 && board[Y + 1, X] == 0)
                        {
                            if (flag == 0)
                            {
                                traveled[Y + 1, X] = 1;
                                int c = result.Count;
                                if (c == 0)
                                {
                                    for (int i = 0; i < 1; i++)
                                        result.Add(arr);
                                }
                                else
                                {
                                    for (int i = 0; i < c; i++)
                                        result.Add(arr);
                                }
                                result[c] = new int[2];
                                result[c][0] = Y + 1;
                                result[c][1] = X;
                            }
                        }
                        else
                        {
                            if ((Y + 2) < 8 && board[Y + 2, X] == 0 && traveled[Y + 2, X] == 0)
                            {
                                traveled[Y + 2, X] = 1; 
                                int rc = result.Count;
                                if (rc == 0)
                                {
                                    for (int i = 0; i < 1; i++)
                                        result.Add(arr);
                                }
                                else
                                {
                                    for (int i = 0; i < rc; i++)
                                        result.Add(arr);
                                }
                                result[rc] = new int[2]; //
                                result[rc][0] = Y + 2;
                                result[rc][1] = X;
                                int pc = path.Count;
                                for (int i = 0; i < 2; i++)
                                    path.Add(arr);
                                path[pc] = new int[2];
                                path[pc][1] = Y + 2;
                                path[pc][0] = X;
                            }
                        }
                    }
                    else
                    {
                        if (rote == 3)
                        {
                            if ((X + 1) < 8 && board[Y, X + 1] == 0)
                            {
                                if (flag == 0)
                                {
                                    traveled[X + 1, Y] = 1;
                                    int c = result.Count;
                                    if (c == 0)
                                    {
                                        for (int i = 0; i < 1; i++)
                                            result.Add(arr);
                                    }
                                    else
                                    {
                                        for (int i = 0; i < c; i++)
                                            result.Add(arr);
                                    }
                                    result[c] = new int[2];
                                    result[c][0] = Y;
                                    result[c][1] = X + 1;
                                }
                            }
                            else
                            {
                                if ((X + 2) < 8 && board[Y, X + 2] == 0 && traveled[Y, X + 2] == 0)
                                {
                                    traveled[Y, X + 2] = 1;
                                    int rc = result.Count;
                                    if (rc == 0)
                                    {
                                        for (int i = 0; i < 1; i++)
                                            result.Add(arr);
                                    }
                                    else
                                    {
                                        for (int i = 0; i < rc; i++)
                                            result.Add(arr);
                                    }
                                    result[rc] = new int[2];
                                    result[rc][0] = Y;
                                    result[rc][1] = X + 2;
                                    int pc = path.Count;
                                    for (int i = 0; i < 2; i++)
                                        path.Add(arr);
                                    path[pc] = new int[2];
                                    path[pc][1] = Y;
                                    path[pc][0] = X + 2;
                                }
                            }
                        }
                        else
                        {
                            if (Y > 0 && board[Y - 1, X] == 0)
                            {
                                if (flag == 0)
                                {
                                    traveled[Y - 1, X] = 1;
                                    int c = result.Count;
                                    if (c == 0)
                                    {
                                        for (int i = 0; i < 1; i++)
                                            result.Add(arr);
                                    }
                                    else
                                    {
                                        for (int i = 0; i < c; i++)
                                            result.Add(arr);
                                    }
                                    result[c] = new int[2];//
                                    result[c][0] = Y - 1;
                                    result[c][1] = X;
                                }
                            }
                            else
                            {
                                if (Y > 1 && board[Y - 2, X] == 0 && traveled[Y - 2, X] == 0)
                                {
                                    traveled[Y - 2, X] = 1;
                                    int rc = result.Count;
                                    if (rc == 0)
                                    {
                                        for (int i = 0; i < 1; i++)
                                            result.Add(arr);
                                    }
                                    else
                                    {
                                        for (int i = 0; i < rc; i++)
                                            result.Add(arr);
                                    }
                                    result[rc] = new int[2]; 
                                    result[rc][0] = Y - 2;
                                    result[rc][1] = X;
                                    int p = path.Count;
                                    for (int i = 0; i < 2; i++)
                                        path.Add(arr);
                                    path[p] = new int[2];
                                    path[p][1] = Y - 2;
                                    path[p][0] = X;
                                }
                            }

                            flag = 1;
                            int pc = path.Count;
                            for (int i = 0; i < pc; i++)
                            {
                                if (path[i] == arr)
                                { path.RemoveRange(i, 1); pc--; }
                            }
                            

                            if (path.Count > 1)
                            {
                                path[0][0] = path[1][0];
                                path[0][1] = path[1][1];
                                path.RemoveRange(0, 1);
                                rote = 0;
                            }
                        }
                    }
                }

                rote++;
            }

           
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MainMenu f2 = new Corners.MainMenu();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
