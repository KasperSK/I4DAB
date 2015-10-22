using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessWithAdoNet
{
    public class Person
    {
        public Person()
        {
            
        }
        public Person(int id, string fornavn, string mellemnavn, string efternavn, string forhold, List<EkstraAddresse> ekstraAddresser, List<Telefon> telefoner )
        {
            Id = id;
            Fornavn = fornavn;
            Mellemnavn = mellemnavn;
            Efternavn = efternavn;
            Forhold = forhold;
            PersonAddresser = personaddresser;
            Telefoner = telefoner;
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
        public EkstraAddresse()
        { }
        public EkstraAddresse(int id, Addresse addresse, Person person, string forhold)
        {
            Id = id;
            Adresse = addresse;
            Person = person;
            Forhold = forhold;
        }
        public int Id { get; set; }
        public Addresse Adresse { get; set; }
        public Person Person { get; set; }
        public string Forhold { get; set; }
    }

    public class Addresse
    {
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
            _akdc.Open();
            const string commandText = @"
                                         INSERT INTO
                                            person
                                            (Fornavn, Mellemnavn, Efternavn, Forhold, FolkeAID)
                                         OUTPUT
                                            INSERTED.ID
                                         VALUES
                                            (@Fornavn, @Mellemnavn, @Efternavn, @Forhold, @FolkeAID)
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Fornavn", person.Fornavn);
            cmd.Parameters.AddWithValue("@Mellemnavn", person.Mellemnavn);
            cmd.Parameters.AddWithValue("@Efternavn", person.Efternavn);
            cmd.Parameters.AddWithValue("@Forhold", person.Forhold);
            cmd.Parameters.AddWithValue("@FolkeAID", person.FolkeregisterAddresse.Id);
            var personid = (int)cmd.ExecuteScalar();
            person.Id = personid;
            _akdc.Close();
        }

        public Person ReadPerson(int personid)
        {
            _akdc.Open();
            const string commandText = @"
                                        SELECT
                                            Fornavn,
                                            Mellemnavn,
                                            Efternavn,
                                            Forhold,
                                            FolkeAID
                                        FROM
                                            person
                                        WHERE
                                            PersonID = @personid
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@personid", personid);
            var reader = cmd.ExecuteReader();
            reader.Read();
            var person = new Person
            {
                Id = personid,
                Fornavn = reader["Fornavn"].ToString(),
                Mellemnavn = reader["Mellemnavn"].ToString(),
                Efternavn = reader["Efternavn"].ToString(),
                Forhold = reader["Forhold"].ToString()
            };
            var folkeAid = (int) reader["FolkeAID"];
            _akdc.Close();
            person.FolkeregisterAddresse = _ReadAddresse(folkeAid);
            return person;
        }

        public void UpdatePerson(Person person)
        {
            _akdc.Open();
            const string commandText = @"
                                        UPDATE
                                            person 
                                        SET
                                            Fornavn=@Fornavn,
                                            Mellemnavn=@Mellemnavn, 
                                            Efternavn=@Efternavn, 
                                            Forhold=@Forhold,
                                            FolkeAID=@FolkeAID
                                        WHERE 
                                            PersonID = @Id
                                        ";

            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Fornavn", person.Fornavn);
            cmd.Parameters.AddWithValue("@Mellemnavn", person.Mellemnavn);
            cmd.Parameters.AddWithValue("@Efternavn", person.Efternavn);
            cmd.Parameters.AddWithValue("@Forhold", person.Forhold);
            cmd.Parameters.AddWithValue("@FolkeAID", person.FolkeregisterAddresse.Id);
            cmd.Parameters.AddWithValue("@Id", person.Id);
            cmd.ExecuteNonQuery();
            _akdc.Close();
        }

        public void DeletePerson(Person person)
        {
            _akdc.Open();
            const string commandText = @"
                                        DELETE FROM
                                            person
                                        WHERE 
                                            PersonID = @Id
                                        ";

            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Id", person.Id);
            cmd.ExecuteNonQuery();
            _akdc.Close();
        }




        public void CreateAddresse(Addresse addresse)
        {
            _akdc.Open();
            const string commandText = @"INSERT INTO
                                            Addresse
                                            (Vejnavn, Husnummer, Postnummer, Bynavn)
                                        OUTPUT
                                            INSERTED.ID
                                        VALUES
                                            (@Vejnavn, @Husnummer, @Postnummer, @Bynavn)";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Vejnavn", addresse.Vejnavn);
            cmd.Parameters.AddWithValue("@Husnummer", addresse.Husnummer);
            cmd.Parameters.AddWithValue("@Postnummer", addresse.PostNummer);
            cmd.Parameters.AddWithValue("@Bynavn", addresse.Bynavn);
            var addresseid = (int)cmd.ExecuteScalar();
            addresse.Id = addresseid;
            _akdc.Close();
        }

        public Addresse ReadAddresse(int addresseid)
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
                                            AddresseID = @addresseid
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@addresseid", addresseid);
            var reader = cmd.ExecuteReader();
            reader.Read();
            var addresse = new Addresse
            {
                Id = addresseid,
                Vejnavn = reader["Vejnavn"].ToString(),
                Husnummer = reader["Husnummer"].ToString(),
                PostNummer = (int) reader["Postnummer"],
                Bynavn = reader["Bynavn"].ToString()
            };
            _akdc.Close();
            return addresse;
        }

        public void UpdateAddresse(Addresse addresse)
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
                                            AddresseID = @Id
                                        ";

            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Vejnavn", addresse.Vejnavn);
            cmd.Parameters.AddWithValue("@Husnummer", addresse.Husnummer);
            cmd.Parameters.AddWithValue("@Postnummer", addresse.PostNummer);
            cmd.Parameters.AddWithValue("@Bynavn", addresse.Bynavn);
            cmd.Parameters.AddWithValue("@Id", addresse.Id);
            cmd.ExecuteNonQuery();
            _akdc.Close();
        }

        public void DeleteAddresse(Addresse addresse)
        {
            _akdc.Open();
            const string commandText = @"
                                        DELETE FROM
                                            Addresse
                                        WHERE 
                                            AddresseID = @Id
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Id", addresse.Id);
            cmd.ExecuteNonQuery();
            _akdc.Close();
        }




        public void CreateTelefon(Telefon telefon)
        {
            _akdc.Open();
            const string commandText = @"INSERT INTO
                                            Telefon
                                            (Number)
                                        OUTPUT
                                            INSERTED.ID
                                        VALUES
                                            (@Number)";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Number", telefon.Number);
            cmd.Parameters.AddWithValue("@PersonID", telefon.Owner.Id);
            var id = (int)cmd.ExecuteScalar();
            telefon.Id = id;
            _akdc.Close();
        }

        public Telefon ReadTelefon(int telefonid)
        {
            _akdc.Open();
            const string commandText = @"
                                        SELECT
                                            Number
                                        FROM
                                            Telefon
                                        WHERE
                                            TelefonID = @Id
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Id", telefonid);
            var reader = cmd.ExecuteReader();
            reader.Read();
            var telefon = new Telefon
            {
                Id = telefonid,
                Number = reader["Number"].ToString(),
            };
            _akdc.Close();
            return telefon;
        }

        public void UpdateTelefon(Telefon telefon)
        {
            _akdc.Open();
            const string commandText = @"
                                        UPDATE
                                            Telefon 
                                        SET
                                            Number=@Number,
                                        WHERE 
                                            TelefonID = @Id
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Number", telefon.Number);
            cmd.Parameters.AddWithValue("@Id", telefon.Id);
            cmd.ExecuteNonQuery();
            _akdc.Close();
        }

        public void DeleteTelefon(Telefon telefon)
        {
            _akdc.Open();
            const string commandText = @"
                                        DELETE FROM
                                            Telefon
                                        WHERE 
                                            TelefonID = @Id
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Id", telefon.Id);
            cmd.ExecuteNonQuery();
            _akdc.Close();
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



        public void ConnectPhone(Telefon telefon, Person person)
        {
            _akdc.Open();
            const string commandText = @"
                                        UPDATE
                                            Telefon 
                                        SET
                                            Number=@Number,
                                        WHERE 
                                            TelefonID = @Id
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@Number", telefon.Number);
            cmd.Parameters.AddWithValue("@Id", telefon.Id);
            cmd.ExecuteNonQuery();
            _akdc.Close();
        }

        public void DisconnectPhone(Telefon telefon)
        {
            
        }

        public void UpdateFolkeregisterAddresse(Person person, Addresse addresse)
        {
            person.FolkeregisterAddresse = addresse;
            _akdc.Open();
            const string commandText = @"
                                        UPDATE
                                            person 
                                        SET
                                            FolkeAID=@FolkeAID,
                                        WHERE 
                                            PersonID = @Id
                                        ";
            var cmd = new SqlCommand(commandText, _akdc);
            cmd.Parameters.AddWithValue("@FolkeAID", addresse.Id);
            cmd.Parameters.AddWithValue("@Id", person.Id);
            cmd.ExecuteNonQuery();
            _akdc.Close();
        }
        

        
    }


}
