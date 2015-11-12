namespace Kartotek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Addresse")]
    public class Addresse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Addresse()
        {
            EkstraAddresses = new HashSet<EkstraAddresse>();
            People = new HashSet<Person>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Vejnavn { get; set; }

        [Required]
        [StringLength(10)]
        public string Husnummer { get; set; }

        public int Postnummer { get; set; }

        [Required]
        [StringLength(200)]
        public string Bynavn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EkstraAddresse> EkstraAddresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> People { get; set; }
    }

    public class AddresseDto
    {
        public int Id { get; set; }
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }
        public int Postnummer { get; set; }
        public string Bynavn { get; set; }
    }

    public class AddresseDtoDetail
    {
        public int Id { get; set; }
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }
        public int Postnummer { get; set; }
        public string Bynavn { get; set; }

        public List<int> PeopleIds { get; set; } = new List<int>();
        public List<int> EkstraAddreseIds { get; set; } = new List<int>();
    }
}
