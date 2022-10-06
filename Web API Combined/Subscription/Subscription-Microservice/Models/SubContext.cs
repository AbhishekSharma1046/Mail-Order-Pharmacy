using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionService.Models
{
    public class SubContext:DbContext
    {
        public SubContext(DbContextOptions<SubContext>options ):base(options) { }

        public DbSet<PrescriptionDetails> TbPrescriptionDetails { get; set; }
    }
}
