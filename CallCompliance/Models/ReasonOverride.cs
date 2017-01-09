using System;

namespace CallCompliance.Models {
    public class ReasonOverride {
        public byte Id { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedBy { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }
}