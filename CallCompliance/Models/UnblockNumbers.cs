using System;

namespace CallCompliance.Models {
    public class UnblockNumbers {
        public string PhoneNumber { get; set; }
        public int ReasonOverrideId { get; set; }
        public int StudentTypeId { get; set; }
        public string Notes { get; set; }
        public DateTime ModifiedBy { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }
}