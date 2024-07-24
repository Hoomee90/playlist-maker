using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaylistMaker.Models
{
	public class Artist
	{
		public int ArtistId { get; set; }
		[Required(ErrorMessage = "The artist must have a name.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "The artist must have a description.")]
		public string Description { get; set; }
		public List<SongArtist> JoinEntities { get; }
	}
}