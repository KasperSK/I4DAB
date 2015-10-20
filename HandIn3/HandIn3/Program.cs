using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessWithAdoNet;


namespace HandIn3
{
    class Program
    {
        static void Main(string[] args)
        {
            AddresseKartotekDal myDal = new AddresseKartotekDal(@"Data Source=(localdb)\ProjectsV12;Initial Catalog=HandIn2;Integrated Security=True;Pooling=False;Connect Timeout=30");
            myDal.GetAllPersons();
            Console.ReadKey();
        }
    }
}
