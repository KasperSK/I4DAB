namespace Kartotek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EkstraAddresse")]
    public class EkstraAddresse
    {
        public int Id { get; set; }

        public int PersonID { get; set; }

        public int AddresseID { get; set; }

        [Required]
        [StringLength(200)]
        public string Forhold { get; set; }

        public virtual Addresse Addresse { get; set; }

        public virtual Person Person { get; set; }
    }

    public class EkstraAddresseDto
    {
        public int Id { get; set; }

        public int PersonID { get; set; }

        public int AddresseID { get; set; }
    }

    public class EkstraAddresseDetail
    {
        public int Id { get; set; }

        public int PersonID { get; set; }

        public int AddresseID { get; set; }

        public string Forhold { get; set; }
    }
}
