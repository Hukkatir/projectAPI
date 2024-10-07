using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class CategoryFile
    {
        public CategoryFile()
        {
            Files = new HashSet<File>();
        }

        public int CategoryFileId { get; set; }
        public string CategoryFileName { get; set; } = null!;

        public virtual ICollection<File> Files { get; set; }
    }
}
