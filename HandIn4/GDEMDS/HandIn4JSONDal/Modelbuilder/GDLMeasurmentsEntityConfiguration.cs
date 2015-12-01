using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandIn4JSONDal;

namespace HandIn4JSONDal.Modelbuilder
{
    class GDLMeasurmentsEntityConfiguration : EntityTypeConfiguration<GDLMeassurement>
    {
        public GDLMeasurmentsEntityConfiguration()
        {
            HasKey(q => new {q.sensorId, q.appartmentId});

           
        }
    }
}
