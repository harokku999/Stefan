using System.Collections.Generic;
using System.Threading.Tasks;
using Stefan.Core;
using Stefan.DataAccess;
using Stefan.DataAccess.Entities;

namespace Stefan.Domain
{
    public interface IManufacturerService
    {
        Task Create(Manufacturer model);
        Task<IList<Manufacturer>> GetAll();
        Task<Manufacturer> Get(int id);
        Task Edit(Manufacturer model);
    }

    public class ManufacturerService : IManufacturerService
    {
        private readonly IGenericRepository<Manufacturer> _manufacturerRepository;
        private readonly IDateTimeService _dateTimeService;

        public ManufacturerService(
            IGenericRepository<Manufacturer> manufacturerRepository,
            IDateTimeService dateTimeService)
        {
            _manufacturerRepository = manufacturerRepository;
            _dateTimeService = dateTimeService;
        }

        public async Task Create(Manufacturer model)
        {
            model.CreateDate = _dateTimeService.Get();
            await _manufacturerRepository.Create(model);
        }

        public async Task<IList<Manufacturer>> GetAll()
        {
            return await _manufacturerRepository.GetAll();
        }

        public async Task<Manufacturer> Get(int id)
        {
            return await _manufacturerRepository.Get(id);
        }

        public async Task Edit(Manufacturer model)
        {
            await _manufacturerRepository.Edit(model);
        }
    }
}
