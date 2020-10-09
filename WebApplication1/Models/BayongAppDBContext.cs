using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BayongWebAppApi.Models
{
    public class BayongAppDBContext:DbContext
    {
        public BayongAppDBContext(DbContextOptions<BayongAppDBContext> options):base(options)
        {

        }
        public DbSet<ProductDetail> ProductDetails { get; set; }

        public DbSet<CategoryDetail> CategoryDetails { get; set; }
    }
}
