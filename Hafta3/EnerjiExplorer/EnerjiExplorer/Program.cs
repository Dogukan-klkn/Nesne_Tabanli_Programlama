using System;

class Program
{
    static void Main()
    {
        int[,] enerjiMaliyeti = {
            { 1, 3, 1 },
            { 2, 1, 2 },
            { 4, 3, 1 }
        };

        int enAzEnerji = EnAzEnerjiHesapla(enerjiMaliyeti);
        Console.WriteLine("En az enerji harcaması: " + enAzEnerji);
    }

    static int EnAzEnerjiHesapla(int[,] matris)
    {
        int n = matris.GetLength(0);
        int m = matris.GetLength(1);

        // Dinamik programlama matrisini oluştur
        int[,] dp = new int[n, m];

        // Başlangıç noktasını ayarlayın
        dp[0, 0] = matris[0, 0];

        // İlk satır ve ilk sütun için değerleri doldurun
        for (int i = 1; i < n; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + matris[i, 0];
        }

        for (int j = 1; j < m; j++)
        {
            dp[0, j] = dp[0, j - 1] + matris[0, j];
        }

        // Dinamik programlama ile geri kalan hücreleri doldurun
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < m; j++)
            {
                dp[i, j] = matris[i, j] + Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]);
            }
        }

        // Hedef hücresinin enerji maliyetini döndür
        return dp[n - 1, m - 1];
    }
}
