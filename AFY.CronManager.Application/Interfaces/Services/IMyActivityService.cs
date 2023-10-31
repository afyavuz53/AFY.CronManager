using AFY.CronManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFY.CronManager.Application.Interfaces.Services
{
    public interface IMyActivityService
    {
        Task<MyActivity> GetById(int id);
        Task<int> CountAll();
        Task<bool> Insert(MyActivity model);
        Task MyFunction();
    }
}
