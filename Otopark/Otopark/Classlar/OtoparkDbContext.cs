﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Otopark.Classlar
{
    internal class OtoparkDbContext : DbContext
    {
        public DbSet<Marka> TBLMarka { get; set; }
        public DbSet<Seri> TBLSeri { get; set; }
        public DbSet<AracParkYerleri> TBLAracParkYerleri { get; set; }
        public DbSet<Musteri> TBLMusteri { get; set; }
        public DbSet<AracParkBilgileri> TBLAracParkBilgileri { get; set; }
        public DbSet<Satis> TBLSatis { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
