using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaylistMaker.Models
{
	public class Song
	{
		public int SongId { get; set; }
		[Required(ErrorMessage = "The song must have a title.")]
		public string Title { get; set; }
		[Required(ErrorMessage = "The song must have a genre.")]
		public string Genre { get; set; }
		[Required(ErrorMessage = "The song must have a description.")]
		public string Description { get; set; }
		[Required(ErrorMessage = "The song must have a length.")]
		public string Length { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = "You must add your song to a playlist. Have you created a playlist yet?")]
		public int PlaylistId { get; set; }
		public Playlist Playlist { get; set; }
		public List<SongArtist> JoinEntities { get; }
	}
}