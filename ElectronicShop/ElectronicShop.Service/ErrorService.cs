using ElectronicShop.Data.Infrastructure;
using ElectronicShop.Data.Repositories;
using ElectronicShop.Model.Models;

namespace ElectronicShop.Service
{
    public interface IErrorService
    {
        Error Add(Error error);

        void SaveChanges();
    }

    public class ErrorService : IErrorService
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            _errorRepository = errorRepository;
            _unitOfWork = unitOfWork;
        }

        public Error Add(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}