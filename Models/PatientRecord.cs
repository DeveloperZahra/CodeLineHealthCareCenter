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
        public DateTime recordDate; // Date when the record was created

        // 2. Class Properties
        public int Id // Unique identifier for the medical record
        {
            get { return id; }
            set { id = value; }
        }
        public int PatientId // Patient's ID to link the record to a patient
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public string Diagnosis // Medical diagnosis for the patient
        {
            get { return diagnosis; } 
            set { diagnosis = value; }
        }

        public string Treatment // Treatment given or prescribed
        {
            get { return treatment; }
            set { treatment = value; }
        }

        public DateTime RecordDate // Date when the record was created
        {
            get { return recordDate; }
            set { recordDate = value; }
        }

        // 3. Class Constructors

    }
}
