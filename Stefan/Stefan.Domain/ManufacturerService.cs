using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Stefan.Core;
using Stefan.DataAccess;
using Stefan.DataAccess.Entities;

namespace Stefan.Domain
{
    public interface IManufacturerService
    {
        Task Add(Manufacturer model);
        Task<List<Manufacturer>> GetAll();
    }

    public class ManufacturerService : IManufacturerService
    {
        private readonly IDateTimeService _dateTimeService;

        public ManufacturerService(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public async Task Add(Manufacturer model)
        {
            using (var context = new StefanDbContext())
            {
                model.CreateDate = _dateTimeService.Get();

                context.Manufacturers.Add(model);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Manufacturer>> GetAll()
        {
            using (var context = new StefanDbContext())
            {
                return context.Manufacturers.ToList();
            }
        }
    }
}
