using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        bool oyunDevam = true;

        while (oyunDevam)
        {
            // Kelime havuzu
            string[] kelimeListesi = new string[]
       {
            "izmir", "afyonkarahisar", "ağrı", "aksaray", "amasya", "ankara", "antalya", "ardahan", "artvin",
            "batman", "bayburt", "bilecik", "bingöl", "bitlis", "bolu", "burdur",
            "bursa", "çanakkale", "çankırı", "çorum", "denizli", "düzce", "edirne", "elazığ", "erzincan",
            "erzurum", "eskişehir", "gaziantep", "giresun", "gümüşhane", "hakkari", "hatay", "istanbul",
            "izmir", "kahramanmaraş", "karabük", "karaman", "kars", "kastamonu", "kayseri",
            "kilis", "kocaeli", "konya", "kütahya", "malatya", "manisa", "mardin", "mersin", "muğla", "muş",
            "nevşehir", "niğde", "ordu", "osmaniye", "rize", "sakarya", "samsun", "siirt", "sinop", "sivas",
            "tekirdağ", "tokat", "trabzon", "tunceli", "uşak", "van", "yalova", "yozgat",
            "zonguldak"
       };

            Random rastgele = new Random();
            string secilenKelime = kelimeListesi[rastgele.Next(0, kelimeListesi.Length)].ToLower(); // Seçilen kelime küçük harf

            // Oyuncunun göreceği boşluklar (gizli kelime)
            char[] gizliKelime = new string('_', secilenKelime.Length).ToCharArray();

            // Yanlış tahmin sayısı
            int can = 10;
            List<char> yanlisTahminler = new List<char>();

            while (can > 0 && new string(gizliKelime) != secilenKelime)
            {
                // Ekranı temizleyelim
                Console.Clear();

                // Oyunun durumu
                Console.WriteLine("Adam Asmaca Oyunu");
                Console.WriteLine($"Kelime: {KelimeyiGoruntule(gizliKelime)}"); // Boşluklu şekilde göster
                Console.WriteLine($"Kalan Can: {can}");
                Console.WriteLine("Yanlış Tahminler: " + string.Join(", ", yanlisTahminler));

                // Kullanıcıya harf veya kelime tahmini seçeneği sunalım
                Console.WriteLine("Bir harf tahmin edin veya kelimeyi çözmeye çalışın:");
                string tahmin = Console.ReadLine().ToLower(); // Tahmin al, küçük harfe çevir

                // Tahmin bir harf mi yoksa kelime mi kontrol et
                if (tahmin.Length == 1) // Harf tahmini
                {
                    char tahminChar = tahmin[0]; // Tahmin edilen harfi al

                    // Harf tahmini doğru mu?
                    if (secilenKelime.Contains(tahminChar.ToString())) // Doğrudan char ile kontrol
                    {
                        // Doğru tahmin
                        for (int i = 0; i < secilenKelime.Length; i++)
                        {
                            if (secilenKelime[i] == tahminChar)
                            {
                                gizliKelime[i] = tahminChar; // Harfi doğru yerleştiriyoruz
                            }
                        }
                    }
                    else
                    {
                        // Yanlış tahmin
                        if (!yanlisTahminler.Contains(tahminChar)) // Yanlış tahminleri kaydediyoruz
                        {
                            yanlisTahminler.Add(tahminChar); // Yanlış tahminleri kaydediyoruz
                            can--; // Can azaltıyoruz
                        }
                    }
                }
                else if (tahmin.Length > 1) // Eğer tahmin bir kelime ise
                {
                    // Kelime tahmini
                    if (tahmin == secilenKelime)
                    {
                        // Doğru kelime tahmini
                        gizliKelime = secilenKelime.ToCharArray();
                        break; // Oyunu kazandık, döngüden çık
                    }
                    else
                    {
                        // Yanlış kelime tahmini
                        Console.WriteLine("Yanlış kelime tahmini!");
                        can--; // Yanlış kelime tahmininde de can azalır
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen bir harf veya kelime tahmin edin.");
                }
            }

            // Oyun Sonucu
            Console.Clear();
            if (new string(gizliKelime) == secilenKelime)
            {
                Console.WriteLine("Tebrikler! Kelimeyi bildiniz: " + secilenKelime);
            }
            else
            {
                Console.WriteLine("Üzgünüz, kaybettiniz! Kelime: " + secilenKelime);
            }

            // Terminalin kapanmasını önlemek için kullanıcıdan seçenek iste
            Console.WriteLine("Tekrar oynamak için 'R' tuşuna basın, çıkmak için 'Q' tuşuna basın...");
            ConsoleKeyInfo tus = Console.ReadKey(); // Kullanıcıdan tuş alıyoruz

            if (tus.Key == ConsoleKey.R)
            {
                // Oyun tekrar başlasın
                continue;
            }
            else if (tus.Key == ConsoleKey.Q)
            {
                // Program sonlansın
                oyunDevam = false;
            }
        }

        Console.WriteLine("\nProgramdan çıkılıyor. İyi günler!");
    }

    // Gizli kelimeyi boşluklu şekilde görüntüleyen metot
    static string KelimeyiGoruntule(char[] gizliKelime)
    {
        return string.Join(" ", gizliKelime); // Harfler arasına boşluk ekliyoruz
    }
}
