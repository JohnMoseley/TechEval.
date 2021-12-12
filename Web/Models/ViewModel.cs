using Heuristics.TechEval.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heuristics.TechEval.Web.Models
{
    /// <summary>
    /// Dto for view
    /// </summary>
    public class ViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Category Category { get; set; }

        public string DisplayCategory
        {
            get
            {
                if(Category!=null)
                {
                    return this.Category.Name;
                }
                return "No Category!";
            }
        }
    }
}