using ElectronicShop.Data.Infrastructure;
using ElectronicShop.Data.Repositories;
using ElectronicShop.Model.Models;
using System.Collections.Generic;

namespace ElectronicShop.Service
{
    public interface IFooterService
    {
        Footer Add(Footer footer);

        void Update(Footer footer);

        Footer Delete(int id);

        IEnumerable<Footer> GetAll(); 

        Footer GetById(int id);
    }
    public class FooterService : IFooterService
    {
        private readonly IFooterRepository _footerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FooterService(IFooterRepository footerRepository, IUnitOfWork unitOfWork)
        {
            this._footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Footer Add(Footer footer)
        {
            return _footerRepository.Add(footer); 
        }

        public Footer Delete(int id)
        {
            return _footerRepository.Delete(id);
        }

        public IEnumerable<Footer> GetAll()
        {
            return _footerRepository.GetAll();
        } 

        public Footer GetById(int id)
        {
            return _footerRepository.GetSingleById(id);
        }

        public void Update(Footer Footer)
        {
            
        }
    }
}
