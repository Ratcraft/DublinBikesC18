using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace DublinBikes.Models
{
    public class DublinBike
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string ContractName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

       
        [Required]
        [StringLength(30)]
        public string Address { get; set; }

        [Required]
        [Range(-90, 90)]
        public float Latitude { get; set; }

        [Required]
        [Range(-90,90)]
        public float Longitude { get; set; }


        [Required]
        public bool Banking { get; set; }

        [Required]
        [Range(1, 100)]
        public int Available_bikes { get; set; }

        [Required]
        [Range(1, 100)]
        public int Available_stands { get; set; }

        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(30)]
        public string Status { get; set; }
    }

}