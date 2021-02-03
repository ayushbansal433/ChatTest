using ChatTest.Common.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatTest.Repository
{
    public interface IUnitOfWork
    {
        IRepository<SignalDataModel> SignalRepository { get; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
