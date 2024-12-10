using cms.web.Models;
using cms.web.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace cms.web.Controllers
{
    public class CarController : BaseController<CarController>
    {
        private readonly ICar _car;
        public CarController(ICar car) {
            _car = car; 
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetCarDetailList(JQueryDataTableParamModel param)
        {
            string sortCol = GetSortingColumnName(param.iSortCol_0);
            var data = await _car.GetCarDetailList(param, sortCol);
            return Json(
                data
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetCarDetailByBradName(string brandName)
        {
            return Json(await _car.GetCarDetailByBradName(brandName));
        }

        //Get car detail by brand and class name
        [HttpGet]
        public async Task<IActionResult> GetCarDetailByBrandClass(string brandName,string className)
        {
            return Json(await _car.GetCarDetailByBrandClass(brandName,className));
        }

        [HttpPost]
        public async Task<IActionResult> AddEditCar(CarRequestResponse carVM)
        {
            return Json(await _car.AddEditCar(carVM));
        }
        [HttpPost]
        public async Task<IActionResult> AddEditCarModel(AddCarModelRequest carModelVM)
        {
            return Json(await _car.AddEditCarModel(carModelVM));
        }
    }
}

