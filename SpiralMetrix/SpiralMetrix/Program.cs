using System;

class SpiralMatris
{
    static void Main(string[] args)
    {
        // Kullanıcıdan matris boyutunu alıyoruz
        Console.Write("Matrisin boyutunu giriniz (N): ");
        int N = int.Parse(Console.ReadLine());

        // NxN boyutunda boş bir matris oluşturuyoruz
        int[,] matris = new int[N, N];

        // Spiral matris doldurmak için gerekli değişkenler
        int deger = 1;  // Matrise yazılacak değer
        int baslangicSatir = 0, baslangicSutun = 0;  // Başlangıç noktaları
        int bitisSatir = N - 1, bitisSutun = N - 1;  // Bitiş noktaları

        while (baslangicSatir <= bitisSatir && baslangicSutun <= bitisSutun)
        {
            // Üst sırayı soldan sağa doldur
            for (int i = baslangicSutun; i <= bitisSutun; i++)
            {
                matris[baslangicSatir, i] = deger++;
            }
            baslangicSatir++;

            // Sağ sütunu yukarıdan aşağıya doldur
            for (int i = baslangicSatir; i <= bitisSatir; i++)
            {
                matris[i, bitisSutun] = deger++;
            }
            bitisSutun--;

            // Alt sırayı sağdan sola doldur
            if (baslangicSatir <= bitisSatir)
            {
                for (int i = bitisSutun; i >= baslangicSutun; i--)
                {
                    matris[bitisSatir, i] = deger++;
                }
                bitisSatir--;
            }

            // Sol sütunu aşağıdan yukarıya doldur
            if (baslangicSutun <= bitisSutun)
            {
                for (int i = bitisSatir; i >= baslangicSatir; i--)
                {
                    matris[i, baslangicSutun] = deger++;
                }
                baslangicSutun++;
            }
        }

        // Matrisi ekrana yazdırıyoruz
        Console.WriteLine("Spiral matris:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matris[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}
