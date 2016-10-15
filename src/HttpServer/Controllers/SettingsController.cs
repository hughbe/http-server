using Microsoft.AspNetCore.Mvc;

namespace HttpServer.Controllers
{
	public class SettingsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
