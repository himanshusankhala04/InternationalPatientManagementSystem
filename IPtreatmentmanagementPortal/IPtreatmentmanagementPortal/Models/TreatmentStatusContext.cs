using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IPtreatmentmanagementPortal.Models
{
    public class TreatmentStatusContext : DbContext
    {
        public TreatmentStatusContext(DbContextOptions<TreatmentStatusContext> options) : base(options)
        { }

        public DbSet<TreatmentStatus> TreatmentStatuses { get; set; }
    }
}
