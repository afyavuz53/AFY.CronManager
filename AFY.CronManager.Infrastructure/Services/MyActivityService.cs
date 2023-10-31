using AFY.CronManager.Application.Interfaces.Repositories;
using AFY.CronManager.Application.Interfaces.Services;
using AFY.CronManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFY.CronManager.Infrastructure.Services
{
    internal class MyActivityService : IMyActivityService
    {
        private readonly IReadRepository _readRepository;
        private readonly IWriteRepository _writeRepository;
        public MyActivityService(IReadRepository readRepository, IWriteRepository writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<MyActivity> GetById(int id)
        {
            var query = "select * from Activities as a where a.Id = @activityid";
            return await _readRepository.GetAsync<MyActivity>(query, new { activityid = id });
        }

        public async Task<int> CountAll()
        {
            return await _readRepository.GetAsync<int>("select count(*) from Activities");
        }

        public async Task<bool> Insert(MyActivity model)
        {
            var query = @"INSERT INTO Activities
( Name, Description, CreatedOn)
VALUES( @Name, @Description, @CreatedOn);";
            var result = await _writeRepository.ExecuteAsync(query, model); // Model ile tablodaki propery lerin isimleri aynı olduğu için modeli direk gönderebiliriz.
            return result > 0;
        }

        public async Task MyFunction()
        {
            var count = await CountAll();
            await Insert(new MyActivity()
            {
                Name = "JnrCoder",
                CreatedOn = DateTime.Now,
                Description = $"Tablodaki satır sayısı : {count}"
            });
        }
    }
}
