using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PM25.Models
{
    public class Pedia
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
    public class PediaDBContext : DbContext
    {
        public DbSet<Pedia> Pedias { get; set; }
    }
}