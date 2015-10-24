using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace DataAccessWithAdoNet
{
    public class Person
    {
        public Person()
        {
            EkstraAddresser = new List<EkstraAddresse>();
            Telefoner = new List<Telefon>();
        }
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        public string Efternavn { get; set; }
        public string Forhold { get; set; }
        public Addresse FolkeregisterAddresse { get; set; }
        public List<EkstraAddresse> EkstraAddresser { get; set; }
        public List<Telefon> Telefoner { get; set; }
    }

    public class EkstraAddresse
    {
        public int Id { get; set; }
        public Addresse Adresse { get; set; }
        public Person Person { get; set; }
        public string Forhold { get; set; }
    }

    public class Addresse
    {
        public Addresse()
        {
            Personer = new List<EkstraAddresse>();
        }
        public int Id { get; set; }
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }
        public int PostNummer { get; set; }
        public string Bynavn { get; set; }
        public List<EkstraAddresse> Personer { get; set; } 
    }

    public class Telefon
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Forhold { get; set; }
        public Person Owner { get; set; }
    }

    public class AddresseKartotekDal
    {
        private readonly SqlConnection _akdc;

        public AddresseKartotekDal(string connectionString)
        {
            _akdc = new SqlConnection(connectionString);
        }

        public void CreatePerson(Person person)
        {
            try
            {
                _akdc.Open();
                const string commandText = @"
                                         INSERT INTO
                                            Person
                                            (Fornavn, Mellemnavn, Efternavn, Forhold)
                                         OUTPUT
                                            INSERTED.ID
                                         VALUES
                                            (@Fornavn, @Mellemnavn, @Efternavn, @Forhold)
                                        ";
                using (var cmd = new SqlCommand(commandText, _akdc))
                {
                    cmd.Parameters.AddWithValue("@Fornavn", person.Fornavn);
                    cmd.Parameters.AddWithValue("@Mellemnavn", person.Mellemnavn);
                    cmd.Parameters.AddWithValue("@Efternavn", person.Efternavn);
                    cmd.Parameters.AddWithValue("@Forhold", person.Forhold);
                    var personid = (int) cmd.ExecuteScalar();
                    person.Id = personid;
                }
            }
            finally
            {
                _akdc?.Close();
            }
        }

        public Person ReadPerson(int personid)
        {
            Person person = null;
            SqlDataReader reader = null;
            try
            { 
                _akdc.Open();
                const string commandText = @"
                                            SELECT
                                                Fornavn,
                                                Mellemnavn,
                                                Efternavn,
                                                Forhold
                                            FROM
                                                Person
                                            WHERE
                                                Id = @Id
                                            ";
                using (var cmd = new SqlCommand(commandText, _akdc))
                {
                    cmd.Parameters.AddWithValue("@Id", personid);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    person = new Person
                    {
                        Id = personid,
                        Fornavn = reader["Fornavn"].ToString(),
                        Mellemnavn = reader["Mellemnavn"].ToString(),
                        Efternavn = reader["Efternavn"].ToString(),
                        Forhold = reader["Forhold"].ToString(),
                    };
                }
            }
           finally
            {
               reader?.Close();
                _akdc?.Close();
            }
            return person;
        }

        public void UpdatePerson(Person person)
        {
            try
            {
                _akdc.Open();
                const string commandText = @"
                                        UPDATE
                                            Person 
                                        SET
                                            Fornavn=@Fornavn,
                                            Mellemnavn=@Mellemnavn, 
                                            Efternavn=@Efternavn, 
                                            Forhold=@Forhold
                                        WHERE 
                                            Id = @Id
                                        ";

                using (var cmd = new SqlCommand(commandText, _akdc))
                {
                    cmd.Parameters.AddWithValue("@Fornavn", person.Fornavn);
                    cmd.Parameters.AddWithValue("@Mellemnavn", person.Mellemnavn);
                    cmd.Parameters.AddWithValue("@Efternavn", person.Efternavn);
                    cmd.Parameters.AddWithValue("@Forhold", person.Forhold);
                    cmd.Parameters.AddWithValue("@Id", person.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _akdc?.Close();
            }
        }

        public void DeletePerson(Person person)
        {
            try
            {
                _akdc.Open();
                const string commandText = @"
                                        DELETE FROM
                                            Person
                                        WHERE 
                                            Id = @Id
                                        ";

                var cmd = new SqlCommand(commandText, _akdc);
                cmd.Parameters.AddWithValue("@Id", person.Id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _akdc?.Close();
            }
        }




        public void CreateAddresse(Addresse addresse)
        {
            try
            {
                _akdc.Open();
                const string commandText = @"INSERT INTO
                                            Addresse
                                            (Vejnavn, Husnummer, Postnummer, Bynavn)
                                        OUTPUT
                                            INSERTED.ID
                                        VALUES
                                            (@Vejnavn, @Husnummer, @Postnummer, @Bynavn)";
                using (var cmd = new SqlCommand(commandText, _akdc))
                {
                    cmd.Parameters.AddWithValue("@Vejnavn", addresse.Vejnavn);
                    cmd.Parameters.AddWithValue("@Husnummer", addresse.Husnummer);
                    cmd.Parameters.AddWithValue("@Postnummer", addresse.PostNummer);
                    cmd.Parameters.AddWithValue("@Bynavn", addresse.Bynavn);
                    var addresseid = (int) cmd.ExecuteScalar();
                    addresse.Id = addresseid;
                }
            }
            finally
            {
                _akdc?.Close();
            }
        }

        public Addresse ReadAddresse(int addresseid)
        {
            Addresse addresse = null;
            SqlDataReader reader = null;
            try
            {
                _akdc.Open();
                const string commandText = @"
                                        SELECT
                                            Vejnavn,
                                            Husnummer,
                                            Postnummer,
                                            Bynavn
                                        FROM
                                            Addresse
                                        WHERE
                                            Id = @Id
                                        ";
                using (var cmd = new SqlCommand(commandText, _akdc))
                {
                    cmd.Parameters.AddWithValue("@Id", addresseid);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    addresse = new Addresse
                    {
                        Id = addresseid,
                        Vejnavn = reader["Vejnavn"].ToString(),
                        Husnummer = reader["Husnummer"].ToString(),
                        PostNummer = (int) reader["Postnummer"],
                        Bynavn = reader["Bynavn"].ToString(),
                    };
                }
            }
            finally
            {
                _akdc?.Close();
            }
            return addresse;
        }

        public void UpdateAddresse(Addresse addresse)
        {
            try
            {
                _akdc.Open();
                const string commandText = @"
                                        UPDATE
                                            Addresse 
                                        SET
                                            Vejnavn=@Vejnavn,
                                            Husnummer=@Husnummer,
                                            Postnummer=@Postnummer,
                                            Bynavn=@Bynavn
                                        WHERE 
                                            Id = @Id
                                        ";

                using (var cmd = new SqlCommand(commandText, _akdc))
                {
                    cmd.Parameters.AddWithValue("@Vejnavn", addresse.Vejnavn);
                    cmd.Parameters.AddWithValue("@Husnummer", addresse.Husnummer);
                    cmd.Parameters.AddWithValue("@Postnummer", addresse.PostNummer);
                    cmd.Parameters.AddWithValue("@Bynavn", addresse.Bynavn);
                    cmd.Parameters.AddWithValue("@Id", addresse.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _akdc?.Close();
            }
        }

        public void DeleteAddresse(Addresse addresse)
        {
            try
            {
                _akdc.Open();
                const string commandText = @"
                                        DELETE FROM
                                            Addresse
                                        WHERE 
                                            Id = @Id
                                        ";
                using (var cmd = new SqlCommand(commandText, _akdc))
                {
                    cmd.Parameters.AddWithValue("@Id", addresse.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _akdc?.Close();
            }
        }



        public void CreateTelefon(Telefon telefon, Person person)
        {
            try
            {
                _akdc.Open();
                const string commandText = @"INSERT INTO
                                            Telefonnummer
                                            (Nummer, Forhold, PersonID)
                                        OUTPUT
                                            INSERTED.ID
                                        VALUES
                                            (@Nummer, @Forhold, @PersonID)";
                using (var cmd = new SqlCommand(commandText, _akdc))
                {
                    cmd.Parameters.AddWithValue("@Nummer", telefon.Number);
                    cmd.Parameters.AddWithValue("@Forhold", telefon.Forhold);
                    cmd.Parameters.AddWithValue("@PersonID", person.Id);
                    var id = (int) cmd.ExecuteScalar();
                    telefon.Id = id;
                }
            }
            finally
            {
                _akdc?.Close();
            }
        }

        public Telefon ReadTelefon(int telefonid)
        {
            Telefon telefon = null;
            SqlDataReader reader = null;
            try
            {
                _akdc.Open();
                const string commandText = @"
                                        SELECT
                                            Nummer, Forhold
                                        FROM
                                            Telefonnummer
                                        WHERE
                                            Id = @Id
                                        ";
                using (var cmd = new SqlCommand(commandText, _akdc))
                {
                    cmd.Parameters.AddWithValue("@Id", telefonid);
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    telefon = new Telefon
                    {
                        Id = telefonid,
                        Number = reader["Nummer"].ToString(),
                        Forhold = reader["Forhold"].ToString(),
                    };
                }
            }
            finally
            {
                reader?.Close();
                _akdc?.Close();
            }
            return telefon;
        }

        public void UpdateTelefon(Telefon telefon)
        {
            try
            {
                _akdc.Open();
                const string commandText = @"
                                        UPDATE
                                            Telefon 
                                        SET
                                            Nummer=@Nummer,
                                            Forhold=@Forhold
                                        WHERE 
                                            Id = @Id
                                        ";
                using (var cmd = new SqlCommand(commandText, _akdc))
                {
                    cmd.Parameters.AddWithValue("@Nummer", telefon.Number);
                    cmd.Parameters.AddWithValue("@Forhold", telefon.Forhold);
                    cmd.Parameters.AddWithValue("@Id", telefon.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                _akdc?.Close();
            }
        }

        public void DeleteTelefon(Telefon telefon)
        {
            try
            {
                _akdc.Open();
                const string commandText = @"
                                        DELETE FROM
                                            Telefon
                                        WHERE 
                                            Id = @Id
                                        ";
                var cmd = new SqlCommand(commandText, _akdc);
                cmd.Parameters.AddWithValue("@Id", telefon.Id);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _akdc.Close();
            }
        }



        public void ConnectEkstraAddresse(Person person, Addresse addresse, string forhold)
        {
            _akdc.Open();
            const string commandText = @"
                                        INSERT INTO
                                            EkstraAddresse
                                            (PersonID, AddresseID, Forhold)
                                        OUTPUT
                                            INSERTED.ID
                                        VALUES
                                            (@PersonID, @AddresseID, @Forhold)
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@PersonID", person.Id);
            cmd.Parameters.AddWithValue("@AddresseID", addresse.Id);
            cmd.Parameters.AddWithValue("@Forhold", forhold);
            var id = (int)cmd.ExecuteScalar();
            _akdc.Close();
            var ekstraAddresse = new EkstraAddresse
            {
                Id = id,
                Person = person,
                Adresse = addresse,
                Forhold = forhold
            };
            person.EkstraAddresser.Add(ekstraAddresse);
            addresse.Personer.Add(ekstraAddresse);
        }

        public void DisconnectEkstraAddresse(EkstraAddresse ekstraAddresse)
        {
            ekstraAddresse.Person.EkstraAddresser.Remove(ekstraAddresse);
            ekstraAddresse.Adresse.Personer.Remove(ekstraAddresse);
            _akdc.Open();
            const string commandText = @"
                                        DELETE FROM
                                            EkstraAddresse
                                        WHERE 
                                            Id = @Id
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Id", ekstraAddresse.Id);
            cmd.ExecuteNonQuery();
            _akdc.Close();
        }

        public List<EkstraAddresse> ReadEkstraAddressesFromPerson(Person person)
        {
            var dt = new DataTable();
            var ekstraAddresser = new List<EkstraAddresse>();
            _akdc.Open();
            const string commandText = @"
                                        SELECT
                                            AddresseID, Forhold, Id
                                        FROM
                                            EkstraAddresse
                                        WHERE
                                            PersonID = @PersonID
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@PersonID", person.Id);
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                dt.Load(reader);
            }
            _akdc.Close();

            foreach (DataRow row in dt.Rows)
            {
                var ekstraAddresse = new EkstraAddresse()
                {
                    Id = (int)row["Id"],
                    Adresse = ReadAddresse((int)row["AddresseID"]),
                    Person = person,
                    Forhold = row["Forhold"].ToString(),
                };
                ekstraAddresser.Add(ekstraAddresse);
            }

            return ekstraAddresser;
        } 


        public List<Telefon> ReadTelefonerFromPerson(Person person)
        {
            var dt = new DataTable();
            var telefoner = new List<Telefon>();
            _akdc.Open();
            const string commandText = @"
                                        SELECT
                                            Id
                                        FROM
                                            Telefonnummer
                                        WHERE
                                            PersonID = @PersonID
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@PersonID", person.Id);
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                dt.Load(reader);
            }
            _akdc.Close();

            foreach (DataRow row in dt.Rows)
            {
                telefoner.Add(ReadTelefon((int)row["Id"]));
            }

            return telefoner;
        } 



        public void UpdateFolkeregisterAddresse(Person person, Addresse addresse)
        {
            _akdc.Open();
            const string commandText = @"
                                        UPDATE
                                            Person 
                                        SET
                                            FolkeAID=@FolkeAID
                                        WHERE 
                                            Id = @Id
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@FolkeAID", addresse.Id);
            cmd.Parameters.AddWithValue("@Id", person.Id);
            cmd.ExecuteNonQuery();
            _akdc.Close();
        }

        public Addresse ReadFolkeregisterAddresse(Person person)
        {
            
            _akdc.Open();
            const string commandText = @"
                                        SELECT
                                            FolkeAID
                                        FROM
                                            Person
                                        WHERE
                                            Id = @Id
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Id", person.Id);

            var addresseId = (int)cmd.ExecuteScalar();
            _akdc.Close();

            return ReadAddresse(addresseId);
            
        }

        
    }


}
