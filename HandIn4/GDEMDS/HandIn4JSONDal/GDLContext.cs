using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn4JSONDal
{
    public class GDLContext : DbContext
    {
        public virtual DbSet<GDLMeassurement> Meassurements { get; set; }
        public virtual DbSet<GDLAppartmentCharacteristic> Appartments { get; set; }
        public virtual DbSet<GDLSensorCharacteristic> Sensors { get; set; }


    }
}
