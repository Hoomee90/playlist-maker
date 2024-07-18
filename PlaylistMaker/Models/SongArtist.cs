namespace PlaylistMaker.Models
{
	public class SongArtist
	{
		public int SongArtistId { get; set; }
		public int SongId { get; set; }
		public Song Song { get; set; }
		public int ArtistId { get; set; }
		public Artist Artist { get; set; }
	}
}