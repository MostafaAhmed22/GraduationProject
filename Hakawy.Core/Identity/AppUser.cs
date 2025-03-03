﻿using Hakawy.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakawy.Core.Identity
{
	public class AppUser : IdentityUser
	{
		//public string DisplayName { get; set; }
		public string FName { get; set; }
		public string LName { get; set; }
		public string? PreferedLanguage { get; set; }
		public string? WritingStyle { get; set; }
		public ICollection<Story> Stories { get; set; }
	}
}
