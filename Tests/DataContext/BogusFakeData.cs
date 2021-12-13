using Bogus;
using Heuristics.TechEval.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heuristics.TechEval.Tests.DataContext
{
    internal static class BogusFakeData
    {
        public static List<Member> GenerateMembers(int numberToGenerate)
        {
            int id = 1;
            var categoryFaker = new Faker<Category>()
                .RuleFor(m => m.Name, f => f.Name.JobTitle())
                 .RuleFor(m => m.Id, id++);
            var categories = categoryFaker.Generate(numberToGenerate);

            id = 1;

            var memberFaker = new Faker<Member>()
                .RuleFor(m => m.Email, f => f.Internet.Email())
                .RuleFor(m => m.Name, f => f.Name.FullName())
                .RuleFor(m => m.CategoryId, id)
                .RuleFor(m => m.Category, categories[id])
                .RuleFor(m => m.Id, id++);

            return memberFaker.Generate(numberToGenerate);
        }
    }
}
