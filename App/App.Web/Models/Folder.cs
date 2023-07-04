using System;
namespace App.Web.Models
{
	public class Folder
	{
		public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
		public string Name { get; set; }

        public Folder(Guid? parentId, string name)
        {
            Id = Guid.NewGuid();
            ParentId = parentId;
            Name = name;
        }
    }
}

