using AFY.CronManager.Application.Configurations;
using AFY.CronManager.Application.Interfaces.Repositories;
using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFY.CronManager.Infrastructure.Repositories
{
    internal class ReadRepository : IReadRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public ReadRepository(IOptions<DatabaseConfig> databaseOption)
        {
            _databaseConfig = databaseOption.Value;
        }

        public async Task<TResult?> GetAsync<TResult>(string sqlCommand, object? param = null)
        {
            var _sqlReadConnection = new MySqlConnection(_databaseConfig.BaseDbConnectionString);
            return await _sqlReadConnection.QueryFirstOrDefaultAsync<TResult>(sqlCommand, param);
        }
    }
}
