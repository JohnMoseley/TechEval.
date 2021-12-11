using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Heuristics.TechEval.Core.Models;

namespace Heuristics.TechEval.Core {

    public class DataContext : DbContext, IDataContext
    {

        public DataContext() : base("Database") { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}