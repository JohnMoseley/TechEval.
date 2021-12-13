using System.Linq;
using System.Web.Mvc;
using Heuristics.TechEval.Core;
using Heuristics.TechEval.Web.Models;
using Heuristics.TechEval.Core.Models;
using Newtonsoft.Json;
using AutoMapper;
using System.Collections.Generic;
using Heuristics.TechEval.Core.Repository;
using System;

namespace Heuristics.TechEval.Web.Controllers {

	public class MembersController : Controller {

		private readonly IMembersRepository _context;

		public MembersController() {
			_context = new MembersRepository(new DataContext());
			ViewBag.Message = "Nothing";
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
			Member newMember = null;

			try
            {
			     newMember = new Member
				{
					Name = data.Name,
					Email = data.Email
				};

				_context.AddMember(newMember);

			}
			catch (Exception ex)
            {

               ViewBag.Message = ex.Message;

			}
		

			return Json(JsonConvert.SerializeObject(newMember));
		}
	}
}