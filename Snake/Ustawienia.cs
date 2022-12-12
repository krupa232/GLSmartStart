using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Ustawienia
    {
        public static int szerokosc { get; set; }
        public static int wysokosc { get; set; }

        public static string kierunek;

        public Ustawienia() //konstruktor
        {
            //domyslne rozmiary
            szerokosc = 16;
            wysokosc = 16;
            kierunek = "lewo"; //domyslny kierunek
        }


    }
}
