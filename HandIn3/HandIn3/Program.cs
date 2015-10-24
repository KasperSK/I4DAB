using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessWithAdoNet;


namespace HandIn3
{
    class Program
    {
        static void AddPerson1(AddresseKartotekDal myDal)
        {
            var folkeadr = new Addresse()
            {
                Bynavn = "Aarhus",
                Husnummer = "92",
                PostNummer = 8200,
                Vejnavn = "Finlandsgade"
            };
            myDal.CreateAddresse(folkeadr);

            var workadr = new Addresse()
            {
                Bynavn = "Aarhus",
                Husnummer = "80",
                PostNummer = 8200,
                Vejnavn = "Oslogade"
            };
            myDal.CreateAddresse(workadr);

            

            var person = new Person()
            {
                Fornavn = "Top",
                Mellemnavn = "Tom",
                Efternavn = "Hat",
                Forhold = "Anstrengt"
            };
            myDal.CreatePerson(person);

            var telefon = new Telefon()
            {
                Number = "80808080",
                Forhold = "Arbejde"
            };
            myDal.CreateTelefon(telefon, person);

            myDal.ConnectEkstraAddresse(person, workadr, "Arbejde");
            myDal.ConnectEkstraAddresse(person, folkeadr, "Hjemme");
            myDal.UpdateFolkeregisterAddresse(person, folkeadr);

        }

        static Person GetPerson1(AddresseKartotekDal myDal, int personid)
        {
            var person = myDal.ReadPerson(personid);
            person.FolkeregisterAddresse = myDal.ReadFolkeregisterAddresse(person);
            person.EkstraAddresser = myDal.ReadEkstraAddressesFromPerson(person);
            person.Telefoner = myDal.ReadTelefonerFromPerson(person);
            return person;
        }

        static void PrintEkstraAddresse(EkstraAddresse adr)
        {
            Console.WriteLine("Forhold: " + adr.Forhold);
            PrintAddresse(adr.Adresse);
        }

        static void PrintAddresse(Addresse adr)
        {
            Console.WriteLine("Vejnavn: " + adr.Vejnavn);
            Console.WriteLine("Nummer: " + adr.Husnummer);
            Console.WriteLine("Postnummer: " + adr.PostNummer);
            Console.WriteLine("By; " + adr.Bynavn);
        }

        static void PrintTelefon(Telefon tlf)
        {
            Console.WriteLine("Forhold: " + tlf.Forhold);
            Console.WriteLine("Nummer: " + tlf.Number);
        }

        static void PrintPerson(Person person)
        {
            Console.WriteLine("Fornavn: " + person.Fornavn);
            Console.WriteLine("Mellemnavn: " + person.Mellemnavn);
            Console.WriteLine("Efternavn: " + person.Efternavn);
            Console.WriteLine("Forhold: " + person.Forhold);
            Console.WriteLine("Folkeadr: ");
            PrintAddresse(person.FolkeregisterAddresse);
            Console.WriteLine("EkstraAddresser");
            foreach (var adr in person.EkstraAddresser)
            {
                PrintEkstraAddresse(adr);
            }
            Console.WriteLine("Telefoner");
            foreach (var telefon in person.Telefoner)
            {
                PrintTelefon(telefon);
            }
        }
        static void Main(string[] args)
        {
            var myDal =
                new AddresseKartotekDal(
                    "Data Source=10.29.0.29;Integrated Security=False;User ID=E15I4DABH2Gr7;Password=E15I4DABH2Gr7;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            //var myDal = new AddresseKartotekDal(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=HandIn2;Integrated Security=True;Pooling=False;Connect Timeout=30");
            
            AddPerson1(myDal);

            var person = GetPerson1(myDal, 1);

            PrintPerson(person);

            Console.ReadKey();
        }
    }
}
