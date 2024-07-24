using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaylistMaker.Models
{
	public class Playlist
	{
		public int PlaylistId { get; set; }
		[Required(ErrorMessage = "The playlist must have a name.")]
		public string Name { get; set; }
		public List<Song> Songs { get; set; }
	}
}