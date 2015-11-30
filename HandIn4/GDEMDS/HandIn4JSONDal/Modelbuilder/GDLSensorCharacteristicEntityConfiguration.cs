using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn4JSONDal.Modelbuilder
{
    class GDLSensorCharacteristicEntityConfiguration : EntityTypeConfiguration<GDLSensorCharacteristic>
    {
        public GDLSensorCharacteristicEntityConfiguration()
        {
            HasKey(e => e.sensorId);

            Property(p => p.description).IsRequired();
            Property(p => p.unit).IsRequired();
            Property(p => p.externalRef).IsRequired();
            Property(p => p.calibrationEquation).IsRequired();
            Property(p => p.calibrationCoeff).IsRequired();
            Property(p => p.calibrationDate).IsRequired();
        }
    }
}
