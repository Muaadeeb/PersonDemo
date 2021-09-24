﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
		// Code First:
		// 1). add-migration initialCommitAnyMessage
		// 2). update-database

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Person> Persons { get; set; }
	}
}
