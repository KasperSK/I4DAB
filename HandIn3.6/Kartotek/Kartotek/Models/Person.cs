namespace Kartotek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public class Person
    {
        public Person()
        {
            EkstraAddresses = new HashSet<EkstraAddresse>();
            Telefonnummers = new HashSet<Telefonnummer>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Fornavn { get; set; }

        [StringLength(200)]
        public string Mellemnavn { get; set; }

        [Required]
        [StringLength(200)]
        public string Efternavn { get; set; }

        [Required]
        [StringLength(200)]
        public string Forhold { get; set; }

        public int? FolkeAID { get; set; }

        public virtual Addresse Addresse { get; set; }

        public virtual ICollection<EkstraAddresse> EkstraAddresses { get; set; }

        public virtual ICollection<Telefonnummer> Telefonnummers { get; set; }
    }

    public class PersonDto
    {
        public int Id { get; set; }

        public string Navn { get; set; }
    }

    public class PersonDetailDto
    {
        public int Id { get; set; }

        public string ForNavn { get; set; }

        public string MellemNavn { get; set; }

        public string EfterNavn { get; set; }

        public string Forhold { get; set; }

        public int? FolkeregisterId { get; set; }

        public List<int> TlfIdList { get; set; } = new List<int>(); 
        public List<int> AddrIdList { get; set; } = new List<int>(); 
    }
}
