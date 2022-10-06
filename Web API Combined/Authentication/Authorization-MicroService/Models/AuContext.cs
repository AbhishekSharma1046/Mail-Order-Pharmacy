using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroService.Models
{
    public class AuContext:DbContext
    {
        public AuContext(DbContextOptions<AuContext> options) : base(options) { }

        public DbSet<MemberDetails> TbPrescriptionDetails { get; set; }

       // public DbSet<UserData> TbPrescriptionDeta { get; set; }
    }
}
