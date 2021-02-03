using ChatTest.Common;
using ChatTest.Common.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatTest.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SignalDbContext _signalDbContext;

        private IRepository<SignalDataModel> signalRepository;
        public UnitOfWork(SignalDbContext signalDbContext)
        {
            this._signalDbContext = signalDbContext;
        }

        public IRepository<SignalDataModel> SignalRepository
        {
            get { return signalRepository ?? (signalRepository = new Repository<SignalDataModel>(_signalDbContext)); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _signalDbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _signalDbContext.SaveChanges();
        }
    }
}
