using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamning_2_ra_kod
{
    class Person
    {
        /* CLASS: Person
         * PURPOSE: Using the variables to call out on the list
         */

        public string name, address, phone, email;
        public Person(string N, string A, string T, string E)
        {
            name = N; address = A; phone = T; email = E;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> Dict = new List<Person>();

            Console.Write("Laddar adresslistan ... ");
            using (StreamReader fileStream = new StreamReader(@"..\..\address.lis"))
            {
                while (fileStream.Peek() >= 0)
                {
                    string line = fileStream.ReadLine();
                    // Console.WriteLine(line);
                    string[] word = line.Split('#');
                    // Console.WriteLine("{0}, {1}, {2}, {3}", word[0], word[1], word[2], word[3]);
                    Person P = new Person(word[0], word[1], word[2], word[3]);
                    Dict.Add(P);
                }
            }
            Console.WriteLine("klart!");

            Console.WriteLine("Hej och välkommen till adresslistan");
            Console.WriteLine("Skriv 'sluta' för att sluta!");
            string command;
            do
            {
                Console.Write("> ");
                command = Console.ReadLine();
                if (command == "sluta")
                {
                    Console.WriteLine("Hej då!");
                }
                else if (command == "ny")
                {
                    Adresslista();
                }
                else if (command == "ta bort")
                {
                    Tabort();
                }
                else if (command == "visa")
                {
                    Visa();
                }
                else if (command == "ändra")
                {
                    Ändra();
                }
                else
                {
                    Console.WriteLine("Okänt kommando: {0}", command);
                }
            } while (command != "sluta");
        }
        static void Adresslista()
        {
            /* METHOD: Adresslista (static)
             * PURPOSE: It calls for the list of the address
             * RETURN VALUE: It returns the given name, address, phone and email taken from the input
             */
            List<Person> Dict = new List<Person>();
            Console.WriteLine("Lägger till ny person");         //Adds a new person
            Console.Write("  1. ange namn:    ");               //Write the name of the person
            string name = Console.ReadLine();
            Console.Write("  2. ange adress:  ");               //Write the address
            string adress = Console.ReadLine();
            Console.Write("  3. ange telefon: ");               //Write the phone number
            string phone = Console.ReadLine();
            Console.Write("  4. ange email:   ");               //Write the email address
            string email = Console.ReadLine();
            Dict.Add(new Person(name, adress, phone, email));
        }
        static void Tabort()
        {
            /* METHOD: Tabort (static)
             * PURPOSE: It serves as a delete function, when you want to delete a person then you write "tabort" in console
             * RETURN VALUE: The return value will be a deleted person from the list
             */
            List<Person> Dict = new List<Person>();
            Console.Write("Vem vill du ta bort (ange namn): ");  //Asks which name you want to delete (name)
            string villTaBort = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].name == villTaBort) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", villTaBort); //Shows that the written number doesn't exist in the list
            }
            else
            {
                Dict.RemoveAt(found);
            }
        }
        static void Visa()
        {
            /* METHOD: Visa (static)
             * PURPOSE: This method shows what is in the list
             * RETURN VALUE: It will return the list
             */
            List<Person> Dict = new List<Person>();
                for (int i = 0; i < Dict.Count(); i++)
                {
                    Person P = Dict[i];
                    Console.WriteLine("{0}, {1}, {2}, {3}", P.name, P.address, P.phone, P.email); // Shows the name of the person and his credentials
                }
        }
        static void Ändra()
        {
            /* METHOD: Ändra (static)
             * PURPOSE: Changes based on what you choose, for instance, if you choose to change name then simply write "name"
             * RETURN VALUE: It shows different credentials based on what you choose
             */
            List<Person> Dict = new List<Person>();
            Console.Write("Vem vill du ändra (ange namn): "); // Which name you would want to change
            string villÄndra = Console.ReadLine();
            int found = -1;
            for (int i = 0; i < Dict.Count(); i++)
            {
                if (Dict[i].name == villÄndra) found = i;
            }
            if (found == -1)
            {
                Console.WriteLine("Tyvärr: {0} fanns inte i telefonlistan", villÄndra); //If the user wrote a number that doesn't exist, shows error
            }
            else
            {
                Console.Write("Vad vill du ändra (namn, adress, telefon eller email): "); //Asks which one of the following credentials to change
                string fältAttÄndra = Console.ReadLine();
                Console.Write("Vad vill du ändra {0} på {1} till: ", fältAttÄndra, villÄndra); //Chooses a person and changes it to the new written one
                string nyttVärde = Console.ReadLine();
                switch (fältAttÄndra)
                {
                    case "namn": Dict[found].name = nyttVärde; break;
                    case "adress": Dict[found].address = nyttVärde; break;
                    case "telefon": Dict[found].phone = nyttVärde; break;
                    case "email": Dict[found].email = nyttVärde; break;
                    default: break;
                }
            }
        }
    }
}
