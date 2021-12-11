using Heuristics.TechEval.Core.Models;
using System.Data.Entity;

namespace Heuristics.TechEval.Core
{
    public interface IDataContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Member> Members { get; set; }

        int SaveChanges();
    }
}