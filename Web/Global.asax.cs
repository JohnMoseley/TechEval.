using AutoMapper;
using Heuristics.TechEval.Core.Models;
using Heuristics.TechEval.Web.Models;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Heuristics.TechEval.Web {
	public class MvcApplication : System.Web.HttpApplication {
		protected void Application_Start() {
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			//Initialize the mapper
			Mapper.Initialize(cfg => {
				cfg.CreateMap<Member, ViewMember>();
				cfg.CreateMap<NewMember, Member>();
				cfg.CreateMap<Category, SelectListItem>()
				.ForMember(dest => dest.Text, act => act.MapFrom(src => src.Name))
				.ForMember(dest => dest.Value, act => act.MapFrom(src => src.Id.ToString()));
			});
		}
	}
}
