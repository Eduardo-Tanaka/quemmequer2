using AM_QMQ.DataAccess;
using AM_QMQ.Models;
using AM_QMQ.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AM_QMQ.Repositories
{
    class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(QMQContext context) : base(context) { }

       

        public override void Add(Person entity)
        {
            entity.Password = CriptografiaUtils.CriptografarSHA256(entity.Password);
            base.Add(entity);
        }

        public Person Logar(string email, string senha)
        {
            senha = CriptografiaUtils.CriptografarSHA256(senha);
            return _dbSet.Where(u => u.Email == email && u.Password == senha).FirstOrDefault();
        }
    }
}