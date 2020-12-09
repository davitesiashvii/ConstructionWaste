using AutoMapper;
using ConstructionWaste.DTOs.Clients;
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
    public class ClientController : Controller
    {
        public readonly IUOW _service;
        private readonly IMapper _mapper;

        public ClientController(IUOW service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult ClientList(string SearchTerm)
        {
            var Modenl = _service.Client.GetAllClient(SearchTerm);

            var ClientList = _mapper.Map<IEnumerable<ClientsDTO>>(Modenl);

            return View(ClientList.OrderByDescending(x=>x.Id).Take(10));
        }

        public IActionResult AddClient()
        {
            ClientVM newClient = new ClientVM();
            var clientsType = _service.Client.GetClientTypes();
            
            newClient.ClientTypeList = _mapper.Map<IEnumerable<ClientTypeDTO>>(clientsType);

            return View(newClient);
        }

        [HttpPost]
        public IActionResult AddClient(ClientVM newClient)
        {
            if (!ModelState.IsValid)
            {
                return View(newClient);
            }
            //newClient.Client.TypeId = newClient.ClientType.Id;
            newClient.Client.InsertTime = DateTime.Now;
            newClient.Client.TypeId = 3;

            Client dbModel=_mapper.Map<Client>(newClient.Client);

            dbModel.Id=_service.Client.getId();
            _service.Client.Create(dbModel);
            _service.Commit();

            return RedirectToAction(nameof(ClientList));
        }

        public IActionResult EditClient(int Id)
        {
            var client = _service.Client.GetClient(Id);
            var model = _mapper.Map<ClientTest>(client);
            return View(model);
        }

        [HttpPost]
        public IActionResult EditClient(ClientTest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.TypeId = 4;
            var dbModel = _service.Client.GetClient(model.Id);

            if (dbModel == null)
            {
                throw new Exception("object not found");
            }

            _mapper.Map<ClientTest,Client>(model,dbModel);
            _service.Client.Update(dbModel);
            _service.Commit();

            return RedirectToAction(nameof(ClientList));
        }

        [HttpPost]
        public IActionResult DeleteClient(int id) 
        {
            var client = _service.Client.GetClient(id);
            _service.Client.Delete(client);
            _service.Commit();

            return RedirectToAction(nameof(ClientList));
        }


    }

}
