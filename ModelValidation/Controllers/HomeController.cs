using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View("MakeBooking", new Appointment { Date = DateTime.Now });

        public ViewResult MakeBooking(Appointment appointment)
        {
            //if (string.IsNullOrEmpty(appointment.ClientName))
            //{
            //    ModelState.AddModelError(nameof(appointment.ClientName), "Введите своё имя");
            //}
            if (ModelState.GetValidationState("Date") == ModelValidationState.Valid && DateTime.Now > appointment.Date)
            {
                ModelState.AddModelError(nameof(appointment.Date), "Укажите корректную дату");
            }
            //if (!appointment.TermsAccepted)
            //{
            //    ModelState.AddModelError(nameof(appointment.TermsAccepted), "Нужно принять условия соглашения");
            //}

            if (ModelState.IsValid)
            {
                return View("Completed", appointment);
            }
            return View();
        }
    }
}
