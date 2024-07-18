using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaylistMaker.Models
{
	public class Song
	{
		public int SongId { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }
		public string Description { get; set; }
		public string Length { get; set; }
		public int PlaylistId { get; set; }
		public Playlist Playlist { get; set; }
		public List<SongArtist> JoinEntities { get; }
	}
}