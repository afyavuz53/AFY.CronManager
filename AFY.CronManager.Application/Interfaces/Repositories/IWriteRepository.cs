﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFY.CronManager.Application.Interfaces.Repositories
{
    public interface IWriteRepository
    {
        Task<int> ExecuteAsync(string query, object? param = null);
    }
}
