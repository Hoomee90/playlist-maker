using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PlaylistMaker.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlaylistMaker.Controllers
{
	public class SongsController : Controller
	{
		private readonly PlaylistMakerContext _db;
		
		public SongsController(PlaylistMakerContext db)
		{
			_db = db;
		}
		
		public ActionResult Index()
		{
			List<Song> model = _db.Songs
				.Include(song => song.Playlist)
				.ToList();
			return View(model);
		}
		
		public ActionResult Create()
		{
			ViewBag.PlaylistId = new SelectList(_db.Playlists, "PlaylistId", "Name");
			return View();
		}
		
		[HttpPost]
		public ActionResult Create(Song song)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.CategoryId = new SelectList(_db.Playlists, "PlaylistId", "Name");
				return View(song);
			}
			else
			{
				_db.Songs.Add(song);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
		}
		
		public ActionResult Details(int id)
		{
			Song thisSong = _db.Songs
				.Include(song => song.Playlist)
				.Include(song => song.JoinEntities)
				.ThenInclude(join => join.Artist)
				.FirstOrDefault(song => song.SongId == id);
			return View(thisSong);
		}
		
		public ActionResult Edit(int id)
		{
			Song thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
			ViewBag.PlaylistId = new SelectList(_db.Playlists, "PlaylistId", "Name");
			return View(thisSong);
		}
		
		[HttpPost]
		public ActionResult Edit(Song song)
		{
			_db.Songs.Update(song);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult AddArtist(int id)
		{
			Song thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
			ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name");
			return View(thisSong);
		}
		
		[HttpPost]
		public ActionResult AddArtist(Song song, int artistId)
		{
			bool joinEntityExists = _db.SongArtists.Any(join => join.ArtistId == artistId && join.SongId == song.SongId);
			if (!joinEntityExists && artistId != 0)
			{
				_db.SongArtists.Add(new SongArtist() { ArtistId = artistId, SongId = song.SongId });
				_db.SaveChanges();
			}
			return RedirectToAction("Details", new { id = song.SongId });
		}
		
		public ActionResult Delete(int id)
		{
			Song thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
			return View(thisSong);
		}
		
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
				Song thisSong = _db.Songs.FirstOrDefault(song => song.SongId == id);
				_db.Songs.Remove(thisSong);
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