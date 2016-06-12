using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace mvc05.Models
{
    [Bind(Exclude = "Result")]
    public class Cal
    {
        const string blockedPattern = @"((?!ABC).)*";
        const string blockedErrMessage = "Contains blocked string!!";

        [Display(Name = "Input Value 1")]
        [Required(ErrorMessage = "a number for Input 1 must be specified")]
        [Range(0, 100, ErrorMessage = "must be 0 - 100")]
        public int Input1 { get; set; }

        [Display(Name = "Input Value 2")]
        [Required(ErrorMessage = "a number for Input 2 must be specified")]
        [Range(0, 100, ErrorMessage = "must be 0 - 100")]
        public int Input2 { get; set; }

        [StringLength(10)]
        [AllowHtml]
        [RegularExpression(blockedPattern, ErrorMessage = blockedErrMessage)]
        [Remote("CheckRemarks", "Cal", ErrorMessage = "ABC not allowed!")]
        public string Remarks { get; set; }

        public string Result { get; set; }

        [ScaffoldColumn(false)]
        public int Testing { get; set; }
    }
}
