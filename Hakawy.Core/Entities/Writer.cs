using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakawy.Core.Entities
{
	public class Writer : BaseEntity
	{
		public string FName { get; set; }
		public string LName { get; set; }
        public string Email { get; set; }
        public string? PreferedLanguage { get; set; }
		public string? WritingStyle { get; set; }
		public ICollection<Story> Stories { get; set; }
	}
}
