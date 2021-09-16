using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using laba1.Models;

namespace laba1.Data
{
    public class laba1Context : DbContext
    {
        public laba1Context (DbContextOptions<laba1Context> options)
            : base(options)
        {
        }

        public DbSet<laba1.Models.WebPage> WebPage { get; set; }
    }
}
