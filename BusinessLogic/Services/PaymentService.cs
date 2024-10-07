using Domian.Interfaces;
using Domian.Models;
using Domian.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PaymentService : IPaymentService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PaymentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Payment>> GetAll()
        {
            return _repositoryWrapper.Payment.FindAll().ToListAsync();
        }

        public Task<Payment> GetById(int id)
        {
            var Payment = _repositoryWrapper.Payment
                .FindByCondition(x => x.PaymentId == id).First();
            return Task.FromResult(Payment);
        }

        public Task Create(Payment model)
        {
            _repositoryWrapper.Payment.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Payment model)
        {
            _repositoryWrapper.Payment.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var Payment = _repositoryWrapper.Payment
                .FindByCondition(x => x.PaymentId == id).First();

            _repositoryWrapper.Payment.Delete(Payment);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
