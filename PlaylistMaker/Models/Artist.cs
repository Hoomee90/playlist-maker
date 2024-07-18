using System.Collections.Generic;

namespace PlaylistMaker.Models
{
	public class Artist
	{
		public int ArtistId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<SongArtist> JoinEntities { get; }
	}
}