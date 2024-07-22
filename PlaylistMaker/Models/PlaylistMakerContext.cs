using Microsoft.EntityFrameworkCore;

namespace PlaylistMaker.Models
{
	public class PlaylistMakerContext : DbContext
	{
		public DbSet<Playlist> Playlists { get; set; }
		public DbSet<Song> Songs { get; set; }
		public DbSet<Artist> Artists { get; set; }
		public DbSet<SongArtist> SongArtists { get; set; }

		public PlaylistMakerContext(DbContextOptions options) : base(options) { }
	}
}