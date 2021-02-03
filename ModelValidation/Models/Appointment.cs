using Microsoft.AspNetCore.Mvc;
using ModelValidation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidation.Models
{
    public class Appointment
    {
        [Required]
        [Display(Name = "Имя")]
        public string ClientName { get; set; }

        [UIHint("Date")]
        [Required(ErrorMessage = "Укажите дату")]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "Вы должны принять условия соглашения")]
        [MustBeTrue(ErrorMessage = "Ну не тру же...")]
        public bool TermsAccepted { get; set; }
    }
}
