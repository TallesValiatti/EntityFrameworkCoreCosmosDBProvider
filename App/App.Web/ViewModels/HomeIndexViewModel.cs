using System.ComponentModel.DataAnnotations;

namespace App.Web.ViewModels
{
	public class HomeIndexViewModel
	{
		public Guid? ParentFolderId { get; set; }

		[Required]
		[Display(Name = "Folder Name")]
		public string? FolderName { get; set; } = default!;
	}
}

