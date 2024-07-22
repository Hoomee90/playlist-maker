using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlaylistMaker.Models;

namespace PlaylistMaker.Controllers
{
	public class HomeController : Controller
	{
		private readonly PlaylistMakerContext _db;
		
		public HomeController(PlaylistMakerContext db)
		{
			_db = db;
		}

		[HttpGet("/")]
		public ActionResult Index()
		{
			ViewBag.Playlists = _db.Playlists.ToList(); 
			ViewBag.Songs = _db.Songs.ToList();
			return View();
		}
		
	}
}