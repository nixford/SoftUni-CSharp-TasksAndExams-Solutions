﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public Medicament()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
        }
        public int MedicamentId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
