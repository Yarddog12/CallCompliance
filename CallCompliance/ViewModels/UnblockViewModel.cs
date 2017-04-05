﻿using CallCompliance.Models;
using System;
using System.Collections.Generic;

namespace CallCompliance.ViewModels {
    public class UnblockViewModel {

        public string PhoneNumber { get; set; }
        public int ReasonOverrideId { get; set; }
        public IEnumerable<ReasonOverride> ReasonOverrides { get; set; }
        public int StudentTypeId { get; set; }
        public string Notes { get; set; }    
        public DateTime ModifiedBy { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }

    }
}