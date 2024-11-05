using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char player = 'X';
        static char computer = 'O';

        static void Main(string[] args)
        {
            int turn = 0;
            bool gameWon = false;

            while (turn < 9 && !gameWon)
            {
                Console.Clear();
                BoardYazdir();

                if (turn % 2 == 0) // Kullanıcı
                {
                    KullaniciHamlesi();
                }
                else // Bilgisayar
                {
                    BilgisayarHamlesi();
                }

                gameWon = OyunKontrol();
                turn++;
            }

            Console.Clear();
            BoardYazdir();

            if (gameWon)
            {
                Console.WriteLine(turn % 2 == 0 ? "Bilgisayar kazandı! :((" : "Tebrikler! KAZANDIN :))");
            }
            else
            {
                Console.WriteLine("Oyun berabere!");
            }
            Console.ReadKey();
        }

        static void BoardYazdir()
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[0], board[1], board[2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[3], board[4], board[5]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[6], board[7], board[8]);
        }

        static void KullaniciHamlesi()
        {
            int secim;
            Console.Write("Bir pozisyon seçin (1-9): ");
            bool isValid = int.TryParse(Console.ReadLine(), out secim);

            while (!isValid || secim < 1 || secim > 9 || board[secim - 1] == player || board[secim - 1] == computer)
            {
                Console.Write("Geçersiz seçim. Başka bir pozisyon seçin: ");
                isValid = int.TryParse(Console.ReadLine(), out secim);
            }

            board[secim - 1] = player;
        }

        static void BilgisayarHamlesi()
        {
            Random rand = new Random();
            int secim = rand.Next(1, 10);

            while (board[secim - 1] == player || board[secim - 1] == computer)
            {
                secim = rand.Next(1, 10);
            }

            Console.WriteLine($"Bilgisayar {secim} pozisyonunu seçti.");
            board[secim - 1] = computer;
        }

        static bool OyunKontrol()
        {
            int[,] kazananKombinasyonlar = {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
                { 0, 4, 8 }, { 2, 4, 6 }
            };

            for (int i = 0; i < kazananKombinasyonlar.GetLength(0); i++)
            {
                if (board[kazananKombinasyonlar[i, 0]] == board[kazananKombinasyonlar[i, 1]] &&
                    board[kazananKombinasyonlar[i, 1]] == board[kazananKombinasyonlar[i, 2]])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
