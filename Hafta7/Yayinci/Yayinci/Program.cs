using System;
using System.Collections.Generic;

// 1. IYayinci arayüzü
public interface IYayinci
{
    void AboneEkle(IAbone abone);
    void AboneCikar(IAbone abone);
    void Bildir(string mesaj);
}

// 1. IAbone arayüzü
public interface IAbone
{
    void BilgiAl(string mesaj);
}

// 2. Yayinci sınıfı
public class Yayinci : IYayinci
{
    private List<IAbone> aboneler = new List<IAbone>();

    public void AboneEkle(IAbone abone)
    {
        aboneler.Add(abone);
        Console.WriteLine($"{abone.GetType().Name} sisteme eklendi.");
    }

    public void AboneCikar(IAbone abone)
    {
        aboneler.Remove(abone);
        Console.WriteLine($"{abone.GetType().Name} sistemden çıkarıldı.");
    }

    public void Bildir(string mesaj)
    {
        Console.WriteLine($"Yayıncı: {mesaj}");
        foreach (var abone in aboneler)
        {
            abone.BilgiAl(mesaj);
        }
    }
}

// 3. Abone sınıfı
public class Abone : IAbone
{
    public string Ad { get; }

    public Abone(string ad)
    {
        Ad = ad;
    }

    public void BilgiAl(string mesaj)
    {
        Console.WriteLine($"{Ad} adlı abone bilgilendirildi: {mesaj}");
    }
}

// 4. Test Programı
class Program
{
    static void Main(string[] args)
    {
        // Yayıncı oluşturuluyor
        IYayinci yayinci = new Yayinci();

        // Aboneler oluşturuluyor
        IAbone abone1 = new Abone("Ahmet");
        IAbone abone2 = new Abone("Ayşe");
        IAbone abone3 = new Abone("Mehmet");

        // Aboneler yayıncıya ekleniyor
        yayinci.AboneEkle(abone1);
        yayinci.AboneEkle(abone2);
        yayinci.AboneEkle(abone3);

        // Yayıncı bir mesaj yayımlıyor
        yayinci.Bildir("Yeni bir makale yayımlandı!");

        Console.WriteLine("-----------------");

        // Bir abone sistemden çıkarılıyor
        yayinci.AboneCikar(abone2);

        // Yayıncı başka bir mesaj yayımlıyor
        yayinci.Bildir("İkinci makale yayımlandı!");
    }
}
