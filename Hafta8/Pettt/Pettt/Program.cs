using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pettt
{
    // Interface: Identifiable
    public interface Identifiable
    {
        Guid Id { get; }
    }

    // Interface: Experienced
    public interface Experienced
    {
        string Name { get; set; }
    }

    // Class: Vaccine
    public class Vaccine
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    // Class: PetInformation
    public class PetInformation
    {
        public List<string> Traits { get; set; } = new List<string>();
        public List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();
    }

    // Class: Animal
    public class Animal
    {
        public string Type { get; set; }
        public string Breed { get; set; }
        public bool Carnivore { get; set; }
    }

    // Class: Owner implementing Experienced
    public class Owner : Experienced
    {
        public string Name { get; set; }
    }

    // Class: Pet implementing Identifiable
    public class Pet : Identifiable
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Age { get; set; }
        public Owner Owner { get; set; }
        public Animal Type { get; set; }
        public PetInformation PetInfo { get; set; }

        public void Feed()
        {
            // Logic to feed the pet
        }

        public bool IsHerbivore()
        {
            return !Type.Carnivore;
        }
    }

    // Program class
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a vaccine
            Vaccine vaccine1 = new Vaccine
            {
                Name = "Rabies",
                Type = "Preventive"
            };

            // Create pet information
            PetInformation petInfo = new PetInformation
            {
                Traits = new List<string> { "Friendly", "Playful" },
                Vaccines = new List<Vaccine> { vaccine1 }
            };

            // Create an animal type
            Animal animalType = new Animal
            {
                Type = "Dog",
                Breed = "Labrador",
                Carnivore = false
            };

            // Create an owner
            Owner owner = new Owner
            {
                Name = "Alice"
            };

            // Create a pet
            Pet pet = new Pet
            {
                Name = "Buddy",
                Age = 3,
                Owner = owner,
                Type = animalType,
                PetInfo = petInfo
            };

            // Output pet details
            Console.WriteLine($"Pet Name: {pet.Name}");
            Console.WriteLine($"Owner: {pet.Owner.Name}");
            Console.WriteLine($"Animal Type: {pet.Type.Type}, Breed: {pet.Type.Breed}");
            Console.WriteLine($"Is Herbivore: {pet.IsHerbivore()}");
            Console.WriteLine("Traits: " + string.Join(", ", pet.PetInfo.Traits));
            Console.WriteLine("Vaccines: " + string.Join(", ", pet.PetInfo.Vaccines.Select(v => v.Name)));
            Console.ReadLine();
        }
    }

}
