using Heuristics.TechEval.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heuristics.TechEval.Web.Models
{
    public class ViewAll
    {
        public List<ViewMember> Members { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}