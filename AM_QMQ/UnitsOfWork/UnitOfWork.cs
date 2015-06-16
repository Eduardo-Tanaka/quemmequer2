using AM_QMQ.DataAccess;
using AM_QMQ.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AM_QMQ.UnitsOfWork
{
    public class UnitOfWork : IDisposable
    {
        private QMQContext _context = new QMQContext();

        private IPersonRepository _pessoaRepository;

        public IPersonRepository PessoaRepository
        {
            get
            {
                if (_pessoaRepository == null)
                {
                    _pessoaRepository = new PersonRepository(_context);
                }
                return _pessoaRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}