using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFY.CronManager.Application.Interfaces.Repositories
{
    public interface IReadRepository
    {
        Task<TResult?> GetAsync<TResult>(string sqlCommand, object? param = null);
    }
}
