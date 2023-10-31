using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFY.CronManager.Domain.Entities
{
    public class MyActivity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? Description { get; set; }
    }
}
