using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PM25.Models
{
    public class BodyTem
    {
        public int ID { get; set; }
        public string Img { get; set; }
        public string Summary { get; set; }
        public string Detail { get; set; }
    }
    public class BodyTemDBContext : DbContext
    {
        public DbSet<BodyTem> BodyTems { get; set; }
    }
}