using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlaylistMaker.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlaylistMaker.Controllers
{
	public class PlaylistsController : Controller
	{
		private readonly PlaylistMakerContext _db;
		
		public PlaylistsController(PlaylistMakerContext db)
		{
			_db = db;
		}
		
		public ActionResult Index()
		{
			List<Playlist> model = _db.Playlists.ToList();
			return View(model);
		}
		
		public ActionResult Create()
		{
		return View();
		}
		
		[HttpPost]
		public ActionResult Create(Playlist playlist)
		{
			_db.Playlists.Add(playlist);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult Details(int id)
		{
			Playlist thisPlaylist = _db.Playlists
				.Include(playlist => playlist.Songs)
				.ThenInclude(song => song.JoinEntities)
				.ThenInclude(join => join.Artist)
				.FirstOrDefault(playlist => playlist.PlaylistId == id);
			return View(thisPlaylist);
		}
		
		public ActionResult Edit(int id)
		{
			Playlist thisPlaylist = _db.Playlists.FirstOrDefault(playlist => playlist.PlaylistId == id);
			return View(thisPlaylist);
		}
		
		[HttpPost]
		public ActionResult Edit(Playlist playlist)
		{
			_db.Playlists.Update(playlist);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult Delete(int id)
		{
			Playlist thisPlaylist = _db.Playlists.FirstOrDefault(playlist => playlist.PlaylistId == id);
			return View(thisPlaylist);
		}
		
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
				Playlist thisPlaylist = _db.Playlists.FirstOrDefault(playlist => playlist.PlaylistId == id);
				_db.Playlists.Remove(thisPlaylist);
				_db.SaveChanges();
				return RedirectToAction("Index");
		}
	}
}