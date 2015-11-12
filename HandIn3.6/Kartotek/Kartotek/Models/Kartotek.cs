namespace Kartotek.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Kartotek : DbContext
    {
        public Kartotek()
            : base("name=Kartotek")
        {
        }

        public virtual DbSet<Addresse> Addresses { get; set; }
        public virtual DbSet<EkstraAddresse> EkstraAddresses { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Telefonnummer> Telefonnummers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresse>()
                .Property(e => e.Vejnavn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Addresse>()
                .Property(e => e.Husnummer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Addresse>()
                .Property(e => e.Bynavn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Addresse>()
                .HasMany(e => e.EkstraAddresses)
                .WithRequired(e => e.Addresse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Addresse>()
                .HasMany(e => e.People)
                .WithOptional(e => e.Addresse)
                .HasForeignKey(e => e.FolkeAID);

            modelBuilder.Entity<EkstraAddresse>()
                .Property(e => e.Forhold)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Fornavn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Mellemnavn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Efternavn)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Forhold)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.EkstraAddresses)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Telefonnummer>()
                .Property(e => e.Forhold)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
