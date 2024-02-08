using Microsoft.AspNetCore.Mvc;
using System;

namespace CalendarApp.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index(int year, int month)
        {
            var currentDate = DateTime.Now;

            var viewModel = new CalendarViewModel
            {
                CurrentYear = year > 0 ? year : currentDate.Year,
                CurrentMonth = month > 0 ? month : currentDate.Month
            };

            viewModel.PreviousMonth = viewModel.CurrentMonth == 1 ? 12 : viewModel.CurrentMonth - 1;
            viewModel.PreviousYear = viewModel.CurrentMonth == 1 ? viewModel.CurrentYear - 1 : viewModel.CurrentYear;
            viewModel.NextMonth = viewModel.CurrentMonth == 12 ? 1 : viewModel.CurrentMonth + 1;
            viewModel.NextYear = viewModel.CurrentMonth == 12 ? viewModel.CurrentYear + 1 : viewModel.CurrentYear;

            // Other logic to populate calendar data...

            return View(viewModel); // Return the CalendarViewModel
        }

    }
}
