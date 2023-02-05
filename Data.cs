using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CornersGame
{
    static class Data
    {
        public static int[,] Board = new int[8, 8] {
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 1, 1, 1 },
                  { 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 0, 0, 0, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
                  { 2, 2, 2, 0, 0, 0, 0, 0 },
            };
        public static string Format = "9x9";
        public static string Theme = "Стандарт";

        public static Color BrightColor = Color.White;
        public static Color DarkColor = Color.Gray;

    }
}
