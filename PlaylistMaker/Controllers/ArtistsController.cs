using Microsoft.AspNetCore.Mvc;
using PlaylistMaker.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace PlaylistMaker.Controllers
{
	public class ArtistsController : Controller
	{
		private readonly PlaylistMakerContext _db;

		public ArtistsController(PlaylistMakerContext db)
		{
			_db = db;
		}

		public ActionResult Index()
		{
			return View(_db.Artists.ToList());
		}
		
		public ActionResult Details(int id)
		{
			Artist thisArtist = _db.Artists
				.Include(artist => artist.JoinEntities)
				.ThenInclude(join => join.Song)
				.FirstOrDefault(artist => artist.ArtistId == id);
			return View(thisArtist);
		}
		
		public ActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult Create(Artist artist)
		{
			if (!ModelState.IsValid)
			{
				return View(artist);
			}
			else
			{
				_db.Artists.Add(artist);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
		}
		
		public ActionResult AddSong(int id)
		{
			Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
			ViewBag.SongId = new SelectList(_db.Songs, "SongId", "Title");
			return View(thisArtist);
		}
		
		[HttpPost]
		public ActionResult AddSong(Artist artist, int songId)
		{
			bool joinEntityExists = _db.SongArtists.Any(join => join.SongId == songId && join.ArtistId == artist.ArtistId);
			if (!joinEntityExists && songId != 0)
			{
				_db.SongArtists.Add(new SongArtist() { SongId = songId, ArtistId = artist.ArtistId });
				_db.SaveChanges();
			}
			return RedirectToAction("Details", new { id = artist.ArtistId });
		}
		
		public ActionResult Edit(int id)
		{
			Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
			return View(thisArtist);
		}
		
		[HttpPost]
		public ActionResult Edit(Artist artist)
		{
			if (!ModelState.IsValid)
			{
				return View(artist);
			}
			else
			{
				_db.Artists.Update(artist);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
		}
		
		public ActionResult Delete(int id)
		{
			Artist thisArtist = _db.Artists.FirstOrDefault(tags => tags.ArtistId == id);
			return View(thisArtist);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Artist thisArtist = _db.Artists.FirstOrDefault(tags => tags.ArtistId == id);
			_db.Artists.Remove(thisArtist);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		[HttpPost]
		public ActionResult DeleteJoin(int joinId)
		{
			SongArtist joinEntry = _db.SongArtists.FirstOrDefault(entry => entry.SongArtistId == joinId);
			_db.SongArtists.Remove(joinEntry);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}