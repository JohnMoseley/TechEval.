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
using System.Net;
using System.Web;

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
			var members = _context.ListMembers();
			var categories = _context.ListCategories();
			

			//Map Datamodels to view model
			List<ViewMember> allMembers =
				Mapper.Map<List<Member>, List<ViewMember>>(members);
			List<SelectListItem> allCategories =
				Mapper.Map<List<Category>, List<SelectListItem>>(categories);

			 var model = new ViewAll() { Categories = allCategories, Members = allMembers };
			return View(model);
		}

		[HttpPost]
		public ActionResult New(NewMember data) {
			Member newMember = null;

			try
            {
				newMember = new Member
				{
					
					Name = data.Name,
					Email = data.Email,
					CategoryId = data.CategoryId == 0 ? null: data.CategoryId
				};
					_context.AddMember(newMember);
			}
			catch (Exception ex)
            {

				HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(JsonConvert.SerializeObject(HttpUtility.HtmlEncode(ex.Message)));
			}
			return Json(JsonConvert.SerializeObject(newMember));
		}
	}
}