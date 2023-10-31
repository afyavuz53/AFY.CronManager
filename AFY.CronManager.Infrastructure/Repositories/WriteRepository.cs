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
    internal class WriteRepository: IWriteRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public WriteRepository(IOptions<DatabaseConfig> databaseOptions)
        {
            _databaseConfig = databaseOptions.Value;
        }

        public async Task<int> ExecuteAsync(string query, object? param = null)
        {
            var _sqlReadConnection = new MySqlConnection(_databaseConfig.BaseDbConnectionString);
            return await _sqlReadConnection.ExecuteAsync(query, param);
        }
    }
}
