using System.Collections.Generic;

namespace PlaylistMaker.Models
{
	public class Playlist
	{
		public int PlaylistId { get; set; }
		public string Name { get; set; }
		public List<Song> Songs { get; set; }
	}
}