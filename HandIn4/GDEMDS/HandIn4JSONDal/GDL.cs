namespace HandIn4JSONDal
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GDL : DbContext
    {
        // Your context has been configured to use a 'GDL' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HandIn4JSONDal.GDL' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'GDL' 
        // connection string in the application configuration file.
        public GDL()
            : base("name=GDL")
        {
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<GDLMeassurement> Meassurements { get; set; }
        public virtual DbSet<GDLAppartmentCharacteristic> Appartments { get; set; }
        public virtual DbSet<GDLSensorCharacteristic> Sensors { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<GDLSensorCharacteristic>().HasKey(q => q.sensorId);
            builder.Entity<GDLAppartmentCharacteristic>().HasKey(q => q.appartmentId);
            builder.Entity<GDLMeassurement>().HasKey(q => new {q.appartmentId, q.sensorId});

            //Relationships
            builder.Entity<GDLMeassurement>()
                .HasRequired(t => t.Appartment)
                .WithMany(t => t.Meassurements)
                .HasForeignKey(t => t.appartmentId);

            builder.Entity<GDLMeassurement>()
                .HasRequired(t => t.Sensor)
                .WithMany(t => t.Meassurements)
                .HasForeignKey(t => t.sensorId);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}