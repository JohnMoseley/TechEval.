﻿using Heuristics.TechEval.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heuristics.TechEval.Web.Models {

	/// <summary>
	/// DTO representing the creation of a new Member
	/// </summary>
	public class NewMember {
        public int Id { get; set; }
        public string Name { get; set; }
		public string Email { get; set; }
        public int? CategoryId { get; set; }
    }
}