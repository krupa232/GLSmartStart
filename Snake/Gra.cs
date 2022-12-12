using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging; // do robienia screenow. ImageFormat.jpeg

namespace Snake
{
    public partial class Gra : Form
    {
        private List<Kolko> Snake = new List<Kolko>(); //"tablica", wszystko zwiazane z wezem
        private Kolko owoc = new Kolko(); //obiekt owoc
        int maxSzerokosc; //maksymalna szerokosc po ktorej bedzie poruszac sie snake
        int maxWysokosc; //maksymalna wysokosc po ktorej bedzie poruszac sie snake
        int wynik; //licznik punktow
        int rekord; //highscore

        Random rand = new Random(); //liczby losowe

        bool idzLewo, idzPrawo, idzDol, idzGora; //kierunki



        public Gra()
        {
            InitializeComponent();

            new Ustawienia();
        }

        private void wcisnijPrzycisk(object sender, KeyEventArgs e)
        {
            //sterowanie, po wcisnieciu przycisku ustawia wartosci na true
            //przed skreceniem w lewo sprawdza czy snake idzie w prawo, nie moze przejsc po swoim ciele
            if (e.KeyCode == Keys.Left && Ustawienia.kierunek != "prawo")
            {
                idzLewo = true;
            }

            if (e.KeyCode == Keys.Right && Ustawienia.kierunek != "lewo")
            {
                idzPrawo = true;
            }

            if (e.KeyCode == Keys.Up && Ustawienia.kierunek != "dol")
            {
                idzGora = true;
            }
            if (e.KeyCode == Keys.Down && Ustawienia.kierunek != "gora")
            {
                idzDol = true;
            }
        }

        private void puscPrzycisk(object sender, KeyEventArgs e)
        {
            //po puszczeniu przycisku ustawia wartosci na false
            if (e.KeyCode == Keys.Left)
            {
                idzLewo = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                idzPrawo = false;
            }

            if (e.KeyCode == Keys.Up)
            {
                idzGora = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                idzDol = false;
            }

        }

        private void zacznijGre(object sender, EventArgs e)
        {
            restart();

        }

        private void zrobScreena(object sender, EventArgs e)
        {
            //napis na gorze ekranu do screena
            Label opis = new Label(); 
            opis.Text = "Uzyskales " + wynik + " punktow i twoj rekord to " + rekord + " punktow!";
            opis.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            opis.ForeColor = Color.Black;
            opis.AutoSize = false;
            opis.Width = oknoGry.Width;
            opis.Height = 30;
            opis.TextAlign = ContentAlignment.MiddleCenter;
            oknoGry.Controls.Add(opis);

            //zapisywanie pliku
            SaveFileDialog screen = new SaveFileDialog();
            screen.FileName = "Screen z gry Snake"; //nazwa pliku
            screen.DefaultExt = "jpg"; //domyslny typ pliku
            screen.Filter = "Plik obrazu JPG (*.jpg) | *.jpg"; //typ pliku do wybrania przy zapisie
            screen.ValidateNames = true; //sprawdzanie poprawnosci nazwy pliku, wywali blad przy niedozwolonych znakach w nazwie

            //przekonwertowanie pliku na jpg
            if (screen.ShowDialog() == DialogResult.OK)
            {
                int szerokosc = Convert.ToInt32(oknoGry.Width); //rozmiar screena
                int wysokosc = Convert.ToInt32(oknoGry.Height); //rozmiar screena
                Bitmap bmp = new Bitmap(szerokosc, wysokosc);
                oknoGry.DrawToBitmap(bmp, new Rectangle(0, 0, szerokosc, wysokosc)); //zapisanie wszystkiego co w oknie gry
                bmp.Save(screen.FileName, ImageFormat.Jpeg);
                oknoGry.Controls.Remove(opis); //usuniecie opisu nad oknem gry po zapisaniu screena
            }

        }

        private void liczCzas(object sender, EventArgs e)
        {
            //ustawianie kierunku

            if (idzLewo)
            {
                Ustawienia.kierunek = "lewo";
            }

            if (idzPrawo)
            {
                Ustawienia.kierunek = "prawo";
            }

            if (idzDol)
            {
                Ustawienia.kierunek = "dol";
            }

            if (idzGora)
            {
                Ustawienia.kierunek = "gora";
            }
            
            //sterowanie c.d.
            for (int i = Snake.Count -1; i >= 0; i--)
            {
                if (i == 0) //glowa snake jest na 0
                {

                    switch (Ustawienia.kierunek)
                    {
                        case "lewo":
                            Snake[i].X--;
                            break;

                        case "prawo":
                            Snake[i].X++;
                            break;

                        case "dol":
                            Snake[i].Y++;
                            break;

                        case "gora":
                            Snake[i].Y--;
                            break;
                    }

                    //przechodzenie przez krawędzie planszy
                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxSzerokosc;
                    }

                    if (Snake[i].X > maxSzerokosc)
                    {
                        Snake[i].X = 0;
                    }

                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxWysokosc;
                    }

                    if (Snake[i].Y > maxWysokosc)
                    {
                        Snake[i].Y = 0;
                    }

                    // jesli owoc bedzie na tej samej pozycji co glowa snake, to snake zje owoc
                    if (Snake[i].X == owoc.X && Snake[i].Y == owoc.Y)
                    {
                        zjedzOwoc();
                    }

                    //sprawdza czy snake nie uderzyl w swoje cialo
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        //jesli glowa uderzy w cialo to koniec gry
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            koniecGry();
                        }

                    }
                }
                else //podazanie kawalkow ciala za soba
                {
                    Snake[i].X = Snake[i - 1].X; 
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }

            oknoGry.Invalidate(); //aktualizowanie okna gry
        }

        private void rysuj(object sender, PaintEventArgs e)
        {
            Graphics okno = e.Graphics; //dodanie PaintEvent do okna gry
            Brush kolorSnake; //brush uzyty do kolorowania snake

            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0) //glowa snake, index 0
                {
                    kolorSnake = Brushes.Black;
                }
                else //reszta ciała
                {
                    kolorSnake = Brushes.Green;
                }

                //kolorowanie snake
                okno.FillEllipse(kolorSnake, new Rectangle
                (
                    Snake[i].X * Ustawienia.szerokosc,
                    Snake[i].Y * Ustawienia.wysokosc,
                    Ustawienia.szerokosc, Ustawienia.wysokosc
                 ));
            }

            //kolorowanie owoców
            okno.FillEllipse(Brushes.Red, new Rectangle
          (
              owoc.X * Ustawienia.szerokosc,
              owoc.Y * Ustawienia.wysokosc,
              Ustawienia.szerokosc, Ustawienia.wysokosc
          ));
        }


        private void restart()
        {
            //odleglosci na jakich bedzie poruszal sie waz
            maxSzerokosc = oknoGry.Width / Ustawienia.szerokosc - 1;
            maxWysokosc = oknoGry.Height / Ustawienia.wysokosc - 1;

            Snake.Clear(); //przy starcie gry czysci snake'a
            przyciskStart.Enabled = false; //wylacza przyciski przy rozpoczeciu gry
            przyciskScreen.Enabled = false;
            wynik = 0;
            wynikGry.Text = "Wynik: " + wynik;

            Kolko glowa = new Kolko { X = 10, Y = 5 }; //tworzy glowe snake, pozycja startowa snake
            Snake.Add(glowa); //dodawanie glowy snake'a do List, index 0

            //tworzenie startowego snake
            for (int i = 0; i < 10; i++)
            {
                Kolko cialo = new Kolko();
                Snake.Add(cialo); //dodawanie ciala snake do List
            }

            //generowanie pozycji pierwszego owoca
            owoc = new Kolko { X = rand.Next(2, maxSzerokosc), Y = rand.Next(2, maxWysokosc) }; // 2 żeby nie było za blisko ściany

            czasGry.Start(); //start timera gry

        }
        private void zjedzOwoc()
        {
            //wynik zwieksza sie o 1 po zjedzeniu owoca
            wynik += 1;
            wynikGry.Text = "Wynik: " + wynik;

            //dodanie kawalka ciala po zjedzeniu owoca
            Kolko cialo = new Kolko
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(cialo);

            //generowanie pozycji owoców
            owoc = new Kolko { X = rand.Next(2, maxSzerokosc), Y = rand.Next(2, maxWysokosc) };

        }
        private void koniecGry()
        {
            czasGry.Stop();
            //wlaczanie przyciskow po zatrzymaniu gry
            przyciskStart.Enabled = true; 
            przyciskScreen.Enabled = true;

            //ustalanie rekordu gracza
            if (wynik > rekord)
            {
                rekord = wynik;

                //wyswietlenie rekordu gracza
                rekordGry.Text = "Rekord: " + Environment.NewLine + rekord;
                rekordGry.ForeColor = Color.Green;
                rekordGry.TextAlign = ContentAlignment.MiddleCenter;
            }

        }

    }
}
