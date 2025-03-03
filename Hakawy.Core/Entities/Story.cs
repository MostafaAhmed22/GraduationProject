﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakawy.Core.Entities
{
	public class Story : BaseEntity
	{
			public string Title { get; set; }
			public string Content { get; set; }
			public string Category { get; set; }
			public DateTime CreatedAt { get; set; }
			public int WriterId { get; set; }
			public Writer Writer { get; set; }
		
	}
}
