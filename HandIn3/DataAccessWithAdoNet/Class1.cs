using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessWithAdoNet
{
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
                    Console.Write(_reader[0]);
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
