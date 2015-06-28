using AM_QMQ.DataAccess;
using AM_QMQ.Models;
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

        private IGenericRepository<PersonIndividual> _individualRepository;

        private IGenericRepository<PersonLegal> _legalRepository;

        private IPersonRepository _pessoaRepository;

        private IGenericRepository<Address> _addressRepository;

        private IGenericRepository<City> _cityRepository;

        private IGenericRepository<State> _stateRepository;

        private IGenericRepository<District> _districtRepository;

        private IGenericRepository<Donation> _donationRepository;

        private IGenericRepository<Image> _imageRepository;

        public IGenericRepository<Image> IamgeRepository
        {
            get
            {
                if (_imageRepository == null)
                {
                    _imageRepository = new GenericRepository<Image>(_context);
                }
                return _imageRepository;
            }
        }

        public IGenericRepository<Donation> DonationRepository
        {
            get
            {
                if (_donationRepository == null)
                {
                    _donationRepository = new GenericRepository<Donation>(_context);
                }
                return _donationRepository;
            }
        }

        public IGenericRepository<District> DistrictRepository
        {
            get
            {
                if (_districtRepository == null)
                {
                    _districtRepository = new GenericRepository<District>(_context);
                }
                return _districtRepository;
            }
        }

        public IGenericRepository<State> StateRepository
        {
            get
            {
                if (_stateRepository == null)
                {
                    _stateRepository = new GenericRepository<State>(_context);
                }
                return _stateRepository;
            }
        }

        public IGenericRepository<City> CityRepository
        {
            get
            {
                if (_cityRepository == null)
                {
                    _cityRepository = new GenericRepository<City>(_context);
                }
                return _cityRepository;
            }
        }

        public IGenericRepository<Address> AddressRepository
        {
            get
            {
                if (_addressRepository == null)
                {
                    _addressRepository = new GenericRepository<Address>(_context);
                }
                return _addressRepository;
            }
        }

        public IGenericRepository<PersonIndividual> IndividualRepository
        {
            get
            {
                if (_individualRepository == null)
                {
                    _individualRepository = new GenericRepository<PersonIndividual>(_context);
                }
                return _individualRepository;
            }
        }

        public IGenericRepository<PersonLegal> LegalRepository
        {
            get
            {
                if (_legalRepository == null)
                {
                    _legalRepository = new GenericRepository<PersonLegal>(_context);
                }
                return _legalRepository;
            }
        }

        public IPersonRepository PersonRepository
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