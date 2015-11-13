using System.Security.Cryptography.X509Certificates;

namespace Kartotek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Telefonnummer")]
    public class Telefonnummer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Forhold { get; set; }

        public int Nummer { get; set; }

        public int? PersonID { get; set; }

        public virtual Person Person { get; set; }
    }

    public class TelefonnummerDto
    {
        public int Id { get; set; }

        public int Nummer { get; set; }

    }

    public class TelefonnummerDetailsDto
    {
        public int Id { get; set; }
        public string Forhold { get; set; }
        public int Nummer { get; set; }
        public int? PersonId { get; set; }
    }
}
