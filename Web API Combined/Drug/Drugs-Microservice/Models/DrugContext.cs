using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MfpeDrugsApi.Models
{
    public class DrugContext:DbContext
    {
        
        public DrugContext(DbContextOptions<DrugContext> options) : base(options) { }

        public DbSet<Drug> TbDrug { get; set; }

        public DbSet<DrugLocation> TbDruglocation { get; set; }
    }
}
