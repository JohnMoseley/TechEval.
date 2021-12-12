using System.Linq;
using System.Web.Mvc;
using Heuristics.TechEval.Core;
using Heuristics.TechEval.Web.Models;
using Heuristics.TechEval.Core.Models;
using Newtonsoft.Json;
using AutoMapper;
using System.Collections.Generic;
using Heuristics.TechEval.Core.Repository;

namespace Heuristics.TechEval.Web.Controllers {

	public class MembersController : Controller {

		private readonly IMembersRepository _context;

		public MembersController() {
			_context = new MembersRepository(new DataContext());
		}

		/// <summary>
		/// Display List in View
		/// </summary>
		/// <returns></returns>
		public ActionResult List() {

			//Get Data Model
			var list = _context.ListMembers();
		
			//Map Datamodel to view model
			List<ViewModel> allMembers =
				Mapper.Map<List<Member>, List<ViewModel>>(list);

			return View(allMembers);
		}

		[HttpPost]
		public ActionResult New(NewMember data) {
			var newMember = new Member {
				Name = data.Name,
				Email = data.Email
			};

			_context.AddMember(newMember);
			

			return Json(JsonConvert.SerializeObject(newMember));
		}
	}
}