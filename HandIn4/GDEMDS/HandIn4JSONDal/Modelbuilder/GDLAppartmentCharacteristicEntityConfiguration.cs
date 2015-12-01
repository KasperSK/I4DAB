using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn4JSONDal.Modelbuilder
{
    class GDLAppartmentCharacteristicEntityConfiguration : EntityTypeConfiguration<GDLAppartmentCharacteristic>
    {
        public GDLAppartmentCharacteristicEntityConfiguration()
        {
            HasKey(e => e.appartmentId);

            Property(p => p.floor).IsRequired();
            Property(p => p.no).IsRequired();
            Property(p => p.size).IsRequired();

            
        }
    }
}
