﻿using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
  public  class OdeToFoodDBContext: DbContext
    {
        public DbSet<Restaruant> Restaurants { get; set; }
    }
}
