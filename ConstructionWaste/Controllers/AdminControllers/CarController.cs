using AutoMapper;
using ConstructionWaste.DTOs.Car;
using ConstructionWaste.Models;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructionWaste.Controllers.AdminControllers
{
    [Authorize(Roles = "admin")]
    public class CarController : Controller
    {
        public readonly IUOW _service;
        private readonly IMapper _mapper;

        public CarController(IUOW service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult CarList()
        {
            var dbModel = _service.Car.GetAllCar();
            var cars = _mapper.Map<IEnumerable<CarDTO>>(dbModel);

            return View(cars.OrderByDescending(x=>x.Id).Take(10));
        }

        public IActionResult CarDrivers()
        {
            var dbModel = _service.CarDriver.GetAllCarDriver();
            var carDrivers = _mapper.Map<IEnumerable<CarDriverDTO>>(dbModel);

            return View(carDrivers.OrderByDescending(x=>x.Id).Take(10));
        }

        public IActionResult CarDriver(int id)
        {
            var dbModel = _service.CarDriver.GetCarDriverByCar(id);
            var car=_mapper.Map<CarDriverDTO>(dbModel);
            return View(car);
        }

        public IActionResult AddCarAndDriver()
        {
            CarVM model = new CarVM();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddCarAndDriver(CarVM model)
        {
            model.Car.Id = _service.Car.AddId();
            model.CarDriver.Id = _service.CarDriver.AddId();
            model.Car.CreatedAt = model.CarDriver.CreatedAt = DateTime.Now;
            model.CarDriver.CarId = model.Car.Id;

            if (!ModelState.IsValid)
                return View(model);

            var newCar = _mapper.Map<Car>(model.Car);
            var newCarDriver = _mapper.Map<CarDriver>(model.CarDriver);

            _service.Car.Create(newCar);
            _service.CarDriver.Create(newCarDriver);
            _service.Commit();

            return RedirectToAction(nameof(CarList));
        }

        public IActionResult EditCarAndDriver(int id)
        {
            CarVM model = new CarVM();
            var editCar = _service.Car.GetCar(id);
            var editCarDriver = _service.CarDriver.GetCarDriverByCar(editCar.Id);

            model.Car = _mapper.Map<CarDTO>(editCar);
            model.CarDriver = _mapper.Map<CarDriverDTO>(editCarDriver);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditCarAndDriver(CarVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var editCar = _service.Car.GetCar(model.Car.Id);
            var editCarDriver = _service.CarDriver.GetCarDriverByCar(model.Car.Id);
            if(editCar == null && editCarDriver == null)
            {
                throw new Exception("object not found");
                
            }

            Car x=_mapper.Map<CarDTO, Car>(model.Car, editCar);
            CarDriver y=_mapper.Map<CarDriverDTO, CarDriver>(model.CarDriver, editCarDriver);
            _service.Car.Update(x);
            _service.CarDriver.Update(y);
            _service.Commit();

            return RedirectToAction(nameof(CarList));
        }

        [HttpPost]
        public IActionResult DeleteCarAndDriver(int id)
        {
            var deleteCar = _service.Car.GetCar(id);
            var deleteCarDriver = _service.CarDriver.GetCarDriverByCar(deleteCar.Id);

            _service.Car.Delete(deleteCar);
            _service.CarDriver.Delete(deleteCarDriver);
            _service.Commit();

            return RedirectToAction(nameof(CarList));
        }



    }
}
