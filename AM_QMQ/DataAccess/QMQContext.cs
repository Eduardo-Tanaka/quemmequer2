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
    }
}