using System;

class Program
{
    static void Main()
    {
        // Kullanıcıdan dizi boyutunu al
        Console.Write("Dizide kaç sayı olacak: ");
        int boyut = int.Parse(Console.ReadLine());

        // Dizi elemanlarını kullanıcıdan al
        int[] sayilar = new int[boyut];
        for (int i = 0; i < boyut; i++)
        {
            Console.Write($"Dizinin {i + 1}. sayısını girin: ");
            sayilar[i] = int.Parse(Console.ReadLine());
        }

        // Diziyi sıralayın
        Array.Sort(sayilar);

        // Kullanıcıdan aranacak sayıyı al
        Console.Write("Aranacak sayıyı girin: ");
        int aranan = int.Parse(Console.ReadLine());

        // İkili arama algoritması ile aranan sayının dizide olup olmadığını kontrol edin
        bool bulundu = IkiliArama(sayilar, aranan);

        // Sonucu ekrana yazdırın
        if (bulundu)
            Console.WriteLine($"{aranan} sayısı dizide bulundu.");
        else
            Console.WriteLine($"{aranan} sayısı dizide bulunamadı.");
    }

    // İkili arama fonksiyonu
    static bool IkiliArama(int[] dizi, int hedef)
    {
        int sol = 0;
        int sag = dizi.Length - 1;

        while (sol <= sag)
        {
            int orta = (sol + sag) / 2;

            if (dizi[orta] == hedef)
                return true;
            else if (dizi[orta] < hedef)
                sol = orta + 1;
            else
                sag = orta - 1;
        }
        return false;
    }
}
