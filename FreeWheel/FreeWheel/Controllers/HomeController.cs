using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FreeWheel.Repositories;
using FreeWheel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FreeWheel.Controllers
{
    public class HomeController : Controller
    {
        private IProgramRepository _programRepository;
        private IStationRepository _stationRepository;
        public HomeController(IProgramRepository programRepository, IStationRepository stationRepository)
        {
            _programRepository = programRepository;
            _stationRepository = stationRepository;
        }

        public IActionResult Index()
        {
            var model = new ProgramViewModel()
            {
                Stations = _stationRepository.GetAllStations().ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ProgramViewModel model)
        {
            model.Stations = _stationRepository.GetAllStations().ToList();
            model.FlightDate = _programRepository.GetProgramByStationId(model.StationId)?.FlightDate?.ToString("MMM dd, yyyy");
            model.ProgramName = _programRepository.GetProgramByStationId(model.StationId)?.ProgramName;
            return View(model);
        }

    }
}
