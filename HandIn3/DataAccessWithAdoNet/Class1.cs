using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessWithAdoNet
{
    public class PersonModel
    {
        Guid PersonId { get; set; }
        string Fornavn { get; set; }
        string Mellemnavn { get; set; }
        string Efternavn { get; set; }
        string Type { get; set; }

        private List<EkstraAddresse> EkstraAddresse { get; set; }
        private List<Telefon> Telefon { get; set; } 
    }

    public class EkstraAddresse
    {
        int AddresseID { get; set; }
        string Vejnavn { get; set; }
        string Husnummer { get; set; }

        int PostNummer { get; set; }
        string Bynavn { get; set; }
        string Type { get; set; }

        int PersonId { get; set; }
    }

    public class Telefon
    {
        
    }

    public class AddresseKartotekDal
    {
        private string _connectionString;
        private SqlConnection AKDC;
        private SqlDataReader _reader;

        public AddresseKartotekDal(string connectionString)
        {
            _connectionString = connectionString;
            AKDC = new SqlConnection(_connectionString);
        }

        public void GetAllPersons()
        {
            try
            {
                AKDC.Open();
                var cmd = new SqlCommand("SELECT * FROM person", AKDC);

                _reader = cmd.ExecuteReader();

                while (_reader.Read())
                {
                    Console.WriteLine(_reader[0]);
                    Console.Write(_reader[1]);
                    Console.Write(_reader[2]);
                    Console.Write(_reader[3]);
                    Console.Write(_reader[4]);

                }
            }
            finally
            {
                if (_reader != null)
                {
                    _reader.Close();
                }

                if (AKDC != null)
                {
                    AKDC.Close();
                }
            }

        }
    }
}
