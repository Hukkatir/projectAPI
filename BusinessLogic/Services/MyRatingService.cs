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
    public class MyRatingService : IMyRatingService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MyRatingService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<MyRating>> GetAll()
        {
            return _repositoryWrapper.MyRating.FindAll().ToListAsync();
        }

        public Task<MyRating> GetById(int id)
        {
            var rating = _repositoryWrapper.MyRating
                .FindByCondition(x => x.RatingId == id).First();
            return Task.FromResult(rating);
        }

        public Task Create(MyRating model)
        {
            _repositoryWrapper.MyRating.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(MyRating model)
        {
            _repositoryWrapper.MyRating.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var rating = _repositoryWrapper.MyRating
                .FindByCondition(x => x.RatingId == id).First();

            _repositoryWrapper.MyRating.Delete(rating);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
