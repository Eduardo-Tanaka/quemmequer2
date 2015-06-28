using AM_QMQ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AM_QMQ.DataAccess
{
    public class QMQContext : DbContext
    {
        public DbSet<Person> Pessoas { get; set; }
        public DbSet<PersonIndividual> PessoasFisicas { get; set; }
        public DbSet<PersonLegal> PessoasJuridicas { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}