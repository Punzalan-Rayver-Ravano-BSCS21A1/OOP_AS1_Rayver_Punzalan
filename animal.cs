using System;
using System.Collections.Generic;

namespace project1
{
    public enum Kind
    {
        Dog,
        Cat,
        Lizard,
        Fish
    }

    public enum Gender
    {
        Male,
        Female
    }

    public interface IAnimal
    {
        string name { get; set; }
        string owner { get; set; }
        Gender gender { get; set; }
        string color { get; set; }
    }

    public interface ISound
    {
        string sound();
    }

    public abstract class Pet : IAnimal
    {
        public Kind kind { get; set; }
        public string name { get; set; }
        public string owner { get; set; }
        public Gender gender { get; set; }
        public string color { get; set; }

        public abstract override string ToString();
    }

    public class Dog : Pet, ISound
    {
        public bool ISsweet { get; set; }
        public string breed { get; set; }

        public override string ToString()
        {
            string sweet = ISsweet ? "Sweet" : "Neutral";
            return $"Dog - {name}, ({gender}), Owner: {owner}, Breed: {breed}, Color: {color}, Affection: {sweet}";
        }

        public string sound()
        {
            return "Woof woof!";
        }
    }

    public class Cat : Pet, ISound
    {
        public string breed { get; set; }
        public override string ToString()
        {
            return $"Cat - {name}, ({gender}), Owner: {owner}, Breed: {breed}, Color: {color}";
        }
        public string sound()
        {
            return "Purr!";
        }
    }

    public class Lizard : Pet, ISound
    {
        public string scale { get; set; }
        public override string ToString()
        {
            return $"Lizard - {name}, ({gender}), Owner: {owner}, Scale: {scale}, Color: {color}";
        }
        public string sound()
        {
            return "Chuck chuck chuck";
        }
    }

    public class Fish : Pet, ISound
    {
        public bool Swim { get; set; }
        public string type { get; set; }

        public override string ToString()
        {
            string swim = Swim ? "Can Swim" : "Can't swim";
            return $"Fish - {name}, ({gender}), Owner: {owner}, Type: {type}, Swim: {swim}, Color: {color}";
        }

        public string sound()
        {
            return "Blub blub blub";
        }
    }

    class animal
    {
        static List<Pet> petsInventory = new List<Pet>();

    static void Main(string[] args)
    {
    
        bool returntoMain = false;
        while (true)
        {
            AddPet();
            Console.Write("Add another pet? (y/press any key): ");
            if (Console.ReadLine().ToLower() != "y")
            {   
                break;
            }
            Console.Clear();
        }
        Console.Clear();
        Console.Write("Which type of animal would you like to list? (Dog, Cat, Lizard, Fish, or 'All'): ");
        string choice = Console.ReadLine();
      
        Console.WriteLine("\nAll pets in the inventory:");
        ListPets(choice);
     
    }


    static void AddPet()
      {
            int numbering;
            Kind kind;
            while (true)
            {
                Console.WriteLine("Welcome to Pet Inventory!");
                numbering = petsInventory.Count + 1;
                Console.WriteLine("Pet " + numbering);
                
                Console.Write("Kind (Dog, Cat, Lizard, Fish): ");
                string kindChoice = Console.ReadLine();

                if (Enum.TryParse<Kind>(kindChoice, true, out kind))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid, press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Gender (M/F): ");
            Gender gender = Console.ReadLine().ToUpper() == "M" ? Gender.Male : Gender.Female;
            Console.Write("Owner: ");
            string owner = Console.ReadLine();

            Console.Write("Color: ");
            string color = Console.ReadLine();

            Pet pet = null;

            switch (kind)
            {
                case Kind.Dog:
                    Console.Write("Affection(y/n): ");
                    bool sweet = Console.ReadLine().ToLower() == "y";
                    Console.Write("Breed: ");
                    string breed = Console.ReadLine();
                    pet = new Dog { name = name, gender = gender, owner = owner, breed = breed, kind = kind, ISsweet = sweet, color = color };
                    break;

                case Kind.Cat:
                    Console.Write("Breed: ");
                    string breed1 = Console.ReadLine();
                    pet = new Cat { name = name, gender = gender, owner = owner, breed = breed1, kind = kind, color = color };
                    break;

                case Kind.Lizard:
                    Console.Write("Scale: ");
                    string scale = Console.ReadLine();
                    pet = new Lizard { name = name, gender = gender, owner = owner, kind = kind, color = color, scale = scale };
                    break;

                case Kind.Fish:
                    Console.Write("Swim(y/n): ");
                    bool swim = Console.ReadLine().ToLower() == "y";
                    Console.Write("Type: ");
                    string type = Console.ReadLine();
                    pet = new Fish { name = name, gender = gender, owner = owner, kind = kind, color = color, Swim = swim, type = type };
                    break;
            }

            petsInventory.Add(pet);
            Console.WriteLine("Pet is added to the inventory!!");
            

            if (pet is ISound soundMaker)
            {
                Console.WriteLine($"{pet.name} says: {soundMaker.sound()}");
            }

        
      }
        
    static void ListPets(string choice) 
        {
            foreach (var pet in petsInventory)
            {
                if (choice.ToLower() == "all" || pet.kind.ToString().ToLower() == choice.ToLower())
                {
                    Console.WriteLine($"* {pet.ToString()}");
                }
            }
              Console.ForegroundColor = ConsoleColor.DarkRed;
              Console.WriteLine("The program is exiting...");
              Console.ReadKey();
        }
    }
}
