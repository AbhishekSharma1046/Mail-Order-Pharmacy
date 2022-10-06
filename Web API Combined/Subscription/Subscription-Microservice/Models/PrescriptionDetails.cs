using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionService.Models
{
    public class PrescriptionDetails
    {
        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int InsurancePolicyNumber { get; set; }

        public string InsuranceProvider { get; set; }
        public DateTime PrescriptionDate { get; set; }
        [Required(ErrorMessage = "Plese Enter DrugName")]
        public string DrugName { get; set; }
        public string DoctorName { get; set; }

        public string RefillOccurrence { get; set; }


       



    }
}
