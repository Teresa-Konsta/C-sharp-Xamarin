using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3Group1
{
    public class Context : DbContext
    {
        public Context() : base()
        {

        }
        public DbSet<Fruits> Fruits { get; set; }
        public DbSet<Planets> Planets { get; set; }
    }
}
