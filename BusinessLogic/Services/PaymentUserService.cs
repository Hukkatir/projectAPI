using Domian.Interfaces;
using Domian.Models;
using Domian.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PaymentUserService : IPaymentUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PaymentUserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<PaymentUser>> GetAll()
        {
            return _repositoryWrapper.PaymentUser.FindAll().ToListAsync();
        }

        public Task<PaymentUser> GetById(int idPayment, int idUser)
        {
            var paymentUser = _repositoryWrapper.PaymentUser
                .FindByCondition(x => x.PaymentId == idPayment && x.UserId == idUser).First();
            return Task.FromResult(paymentUser);
        }

        public Task Create(PaymentUser model)
        {
            _repositoryWrapper.PaymentUser.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(PaymentUser model)
        {
            _repositoryWrapper.PaymentUser.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int idPayment, int idUser)
        {
            var paymentUser = _repositoryWrapper.PaymentUser
                .FindByCondition(x => x.PaymentId == idPayment && x.UserId == idUser).First();

            _repositoryWrapper.PaymentUser.Delete(paymentUser);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
