using AM_QMQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_QMQ.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person Logar(string email, string senha);
    }
}
