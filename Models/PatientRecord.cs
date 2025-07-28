using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineHealthCareCenter.Models
{
    class PatientRecord
    {
        // 1. Class Fields
        public int id; // Unique identifier for the medical record
        public int patientId; // Patient's ID to link the record to a patient
        public string diagnosis; // Medical diagnosis for the patient
        public string treatment; // Treatment given or prescribed
    }
}
