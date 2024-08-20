﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity {
	/// <summary>
	/// Setup, so that roles use Guid as a key instead of a string
	/// </summary>
	public class ApplicationRole : IdentityRole<Guid>{
	}
}