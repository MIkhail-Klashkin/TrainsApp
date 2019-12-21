using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TrainsApp.Models;

namespace TrainsApp.DAL
{
    public class TrainDBContext:DbContext
    {
        static TrainDBContext()
        {
            Database.SetInitializer(new TrainDBInitializer());
        }

        public TrainDBContext() : base("TrainDBContext")
        {

        }

        public DbSet<UserDB> Users { get; set; }

     //   public DbSet<Post> Posts { get; set; }
    }
}