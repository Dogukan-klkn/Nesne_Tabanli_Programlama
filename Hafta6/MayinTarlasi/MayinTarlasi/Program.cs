using System;

class Program
{
    static void Main()
    {
        const int satirSayisi = 10;
        const int sutunSayisi = 10;
        const int mayinSayisi = 15;
        char[,] oyunTahtasi = new char[satirSayisi, sutunSayisi];
        bool[,] mayinlar = new bool[satirSayisi, sutunSayisi];
        bool oyunBitti = false;

        // Tahtayı başlat
        for (int satir = 0; satir < satirSayisi; satir++)
        {
            for (int sutun = 0; sutun < sutunSayisi; sutun++)
            {
                oyunTahtasi[satir, sutun] = '-';
            }
        }

        // Mayınları yerleştir
        Random rastgele = new Random();
        for (int i = 0; i < mayinSayisi; i++)
        {
            int satir, sutun;
            do
            {
                satir = rastgele.Next(satirSayisi);
                sutun = rastgele.Next(sutunSayisi);
            } while (mayinlar[satir, sutun]);
            mayinlar[satir, sutun] = true;
        }

        while (!oyunBitti)
        {
            // Oyun tahtasını göster
            Console.Clear();
            for (int satir = 0; satir < satirSayisi; satir++)
            {
                for (int sutun = 0; sutun < sutunSayisi; sutun++)
                {
                    Console.Write(oyunTahtasi[satir, sutun] + " ");
                }
                Console.WriteLine();
            }

            // Kullanıcıdan giriş al
            Console.WriteLine("Bir hücre seçin (örnek: 3 4): ");
            string giris = Console.ReadLine();
            string[] parcala = giris.Split(' ');
            if (parcala.Length != 2 ||
                !int.TryParse(parcala[0], out int secilenSatir) ||
                !int.TryParse(parcala[1], out int secilenSutun) ||
                secilenSatir < 0 || secilenSatir >= satirSayisi ||
                secilenSutun < 0 || secilenSutun >= sutunSayisi)
            {
                Console.WriteLine("Geçersiz giriş. Tekrar deneyin.");
                continue;
            }

            // Mayına basıldı mı?
            if (mayinlar[secilenSatir, secilenSutun])
            {
                Console.Clear();
                Console.WriteLine("Mayına bastınız! Oyun bitti.");
                oyunBitti = true;
                break;
            }

            // Çevresindeki mayınları say
            int mayinSayisiCevre = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int komsuSatir = secilenSatir + i;
                    int komsuSutun = secilenSutun + j;
                    if (komsuSatir >= 0 && komsuSatir < satirSayisi &&
                        komsuSutun >= 0 && komsuSutun < sutunSayisi &&
                        mayinlar[komsuSatir, komsuSutun])
                    {
                        mayinSayisiCevre++;
                    }
                }
            }

            // Hücreyi aç
            oyunTahtasi[secilenSatir, secilenSutun] = mayinSayisiCevre.ToString()[0];

            // Kazanma durumu kontrolü
            bool kazandi = true;
            for (int satir = 0; satir < satirSayisi; satir++)
            {
                for (int sutun = 0; sutun < sutunSayisi; sutun++)
                {
                    if (oyunTahtasi[satir, sutun] == '-' && !mayinlar[satir, sutun])
                    {
                        kazandi = false;
                        break;
                    }
                }
            }

            if (kazandi)
            {
                Console.Clear();
                Console.WriteLine("Tebrikler! Tüm mayınlardan kaçtınız.");
                oyunBitti = true;
            }
        }
    }
}
