﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTreatmentService.Model
{
    public enum AilmentCategory
    {
        Orthopaedics,
        Urology
    }
    public class IPTreatmentPackage
    {
        public int TreatmentPackageID { get; set; }
       
        public AilmentCategory Ailment { get; set; }
        public string TreatmentPackageName { get; set; }
        public string TestDetails { get; set; }
        public int Cost { get; set; }
        public int TreatmentDuration { get; set; }
    }
}
