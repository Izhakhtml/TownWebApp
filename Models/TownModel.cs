using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TownWebApp.Models
{
    public partial class TownModel : DbContext
    {
        public TownModel()
            : base("name=TownModel")
        {
        }

        public virtual DbSet<Resident> Resident { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
