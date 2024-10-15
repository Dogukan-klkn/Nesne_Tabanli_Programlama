using System;
using System.Collections.Generic;

class TechCitySimulator
{
    static int[,] harita; // Grid
    static bool[,] ziyaretEdildi; // Ziyaret durumu
    static int[] yonlerX = { -1, 1, 0, 0 }; // 4 yön (x ekseni)
    static int[] yonlerY = { 0, 0, -1, 1 }; // 4 yön (y ekseni)
    static int boyut; // Grid boyutu
    static Random rastgele = new Random(); // Rastgele sayı üretici

    public static void BaslatSimulasyon()
    {
        // Grid boyutunu kullanıcıdan alıyoruz
        Console.Write("Lütfen grid boyutunu giriniz (N): ");
        boyut = int.Parse(Console.ReadLine());

        // Grid ve ziyaret durumlarını başlatıyoruz
        harita = new int[boyut, boyut];
        ziyaretEdildi = new bool[boyut, boyut];

        // Grid değerlerini rastgele oluşturuyoruz (0 veya 1)
        Console.WriteLine("Rastgele oluşturulan grid (0 = zarar görmüş, 1 = zarar görmemiş):");
        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                harita[i, j] = rastgele.Next(2); // 0 veya 1 rastgele üret
                Console.Write(harita[i, j] + " "); // Oluşturulan haritayı yazdır
            }
            Console.WriteLine();
        }

        // Robotların başlangıç pozisyonlarını alıyoruz
        List<Tuple<int, int>> robotBaslangiclari = new List<Tuple<int, int>>();
        Console.WriteLine("Robotların başlangıç pozisyonlarını giriniz:");
        for (int i = 1; i <= 3; i++)
        {
            int x, y;
            bool gecerliPozisyon = false;

            while (!gecerliPozisyon)
            {
                Console.Write($"Robot {i} X koordinatı (0-{boyut - 1}): ");
                x = int.Parse(Console.ReadLine());
                Console.Write($"Robot {i} Y koordinatı (0-{boyut - 1}): ");
                y = int.Parse(Console.ReadLine());

                if (x >= 0 && x < boyut && y >= 0 && y < boyut && harita[x, y] == 1) // Pozisyon geçerli mi?
                {
                    robotBaslangiclari.Add(new Tuple<int, int>(x, y));
                    gecerliPozisyon = true;
                }
                else
                {
                    Console.WriteLine("Geçersiz pozisyon girdiniz veya zarar görmüş bir düğüm seçtiniz. Tekrar deneyin.");
                }
            }
        }

        // Robotların kurtardığı düğüm sayısını hesaplayalım
        int toplamKurtarilan = 0;
        for (int i = 0; i < robotBaslangiclari.Count; i++)
        {
            int kurtarilan = Arama(robotBaslangiclari[i].Item1, robotBaslangiclari[i].Item2);
            Console.WriteLine($"Robot {i + 1}, {kurtarilan} düğüm kurtardı.");
            toplamKurtarilan += kurtarilan;
        }

        // Toplam kurtarılan düğüm sayısını yazdırıyoruz
        Console.WriteLine($"Toplam kurtarılan düğüm sayısı: {toplamKurtarilan}");
    }

    // Robotun kurtardığı düğüm sayısını bulmak için arama fonksiyonu (BFS)
    static int Arama(int baslangicX, int baslangicY)
    {
        if (harita[baslangicX, baslangicY] == 0 || ziyaretEdildi[baslangicX, baslangicY]) // Eğer geçilemezse geri dön
        {
            return 0;
        }

        int dugumSayisi = 1; // Kurtarılan düğüm sayısını tutar
        Queue<Tuple<int, int>> kuyruk = new Queue<Tuple<int, int>>();
        kuyruk.Enqueue(new Tuple<int, int>(baslangicX, baslangicY)); // Başlangıç noktasını ekliyoruz
        ziyaretEdildi[baslangicX, baslangicY] = true; // Ziyaret edildi olarak işaretliyoruz

        while (kuyruk.Count > 0) // Kuyruk boşalana kadar devam
        {
            var mevcut = kuyruk.Dequeue(); // Kuyruktan eleman çıkar
            int x = mevcut.Item1;
            int y = mevcut.Item2;

            // 4 yöne bakıyoruz
            for (int i = 0; i < 4; i++)
            {
                int yeniX = x + yonlerX[i];
                int yeniY = y + yonlerY[i];

                if (GecerliKonum(yeniX, yeniY) && harita[yeniX, yeniY] == 1 && !ziyaretEdildi[yeniX, yeniY])
                {
                    ziyaretEdildi[yeniX, yeniY] = true; // Ziyaret edildi olarak işaretle
                    dugumSayisi++; // Kurtarılan düğüm sayısını artır
                    kuyruk.Enqueue(new Tuple<int, int>(yeniX, yeniY)); // Kuyruğa yeni düğüm ekle
                }
            }
        }

        return dugumSayisi; // Kurtarılan düğüm sayısını döndür
    }

    // Geçerli pozisyon olup olmadığını kontrol eder
    static bool GecerliKonum(int x, int y)
    {
        return x >= 0 && x < boyut && y >= 0 && y < boyut; // Pozisyon grid sınırları içinde mi?
    }

    static void Main(string[] args)
    {
        BaslatSimulasyon(); // Simülasyonu başlat
        Console.ReadLine();
    }
}
