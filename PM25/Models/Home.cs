using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PM25.Models
{
    public class Home
    {
        public int ID { get; set; }
        public string preface { get; set; }
    }
    public class DataDBContext : DbContext
    {
        public DbSet<Home> Homes { get; set; }
        public DbSet<Pedia> Pedias { get; set; }
        public DbSet<BodyTem> BodyTems { get; set; }
        public DbSet<Infra> Infras { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Now> Nows { get; set; }
    }
}