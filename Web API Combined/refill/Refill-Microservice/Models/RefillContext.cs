using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RefillApi.Models
{
    public class RefillContext:DbContext
    {


        public RefillContext(DbContextOptions<RefillContext> options) : base(options) { }

        public DbSet<RefillOrder> TbRefillOrder { get; set; }
    }
}
