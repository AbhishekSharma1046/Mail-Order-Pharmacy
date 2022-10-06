using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MfpeDrugsApi.Models;
using MfpeDrugsApi.Provider;
using MfpeDrugsApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MfpeDrugsApi.Controllers
{
    
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrugsApiController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DrugsApiController));
        IProvider _prov;
        private readonly DrugContext _Db;
        public DrugsApiController(IProvider drugprov, DrugContext Db)
        {
            _Db = Db;
            _prov = drugprov;

        }
        public List<LocationWiseDrug> locationwisedrugslist = new List<LocationWiseDrug>();
        DrugRepository re=new DrugRepository();
        [HttpGet("{id:int}", Name = "Get")]
        public async Task<IActionResult> searchDrugsByIDAsync(int id)
        {
                _log4net.Info("Drug ID " + id + " Entered For Searching");
                if (id <= 0)
                    return BadRequest();



            var l1 = await _Db.TbDrug.FindAsync(id);
            var druglocationlist = _Db.TbDruglocation.ToList();
        //Drug l1 = druglist.Find(p => p.Id == id);
            if (l1 != null)
            {
                foreach (var i in druglocationlist)
                {
                    if (i.Id == l1.Id)
                    {
                        LocationWiseDrug lwd = new LocationWiseDrug();
                        lwd.Id = l1.Id;
                        lwd.Name = l1.Name;
                        lwd.ManufacturedDate = l1.ManufacturedDate;
                        lwd.ExpiryDate = l1.ExpiryDate;
                        lwd.Manufacturer = l1.Manufacturer;
                        lwd.Quantity = i.Quantity;
                        lwd.Location = i.Location;
                        locationwisedrugslist.Add(lwd);
                    }
                }
            }


            return Ok(locationwisedrugslist);    
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> searchDrugsByNameAsync(string name)
        {
            _log4net.Info(" Drug Name "+name+" Entered For Searching");
            if (name == null)
                return BadRequest();

           
            var l = _Db.TbDrug.Where(z => z.Name.StartsWith(name)).ToList();
            var druglocationlist = _Db.TbDruglocation.ToList();
           // Drug l1 = druglist.Find(p => p.Name == name);
            if (l != null)
            {
                foreach (var i in druglocationlist) {
                    foreach (var l1 in l)
                    {

                        if (i.Id == l1.Id)
                        {
                            LocationWiseDrug lwd = new LocationWiseDrug();
                            lwd.Id = l1.Id;
                            lwd.Name = l1.Name;
                            lwd.ManufacturedDate = l1.ManufacturedDate;
                            lwd.ExpiryDate = l1.ExpiryDate;
                            lwd.Manufacturer = l1.Manufacturer;
                            lwd.Quantity = i.Quantity;
                            lwd.Location = i.Location;
                            locationwisedrugslist.Add(lwd);
                        }
                    }
                }
            }

            return Ok(locationwisedrugslist);
        }

         /*   [HttpPost]
        public bool getDispatchableDrugStock([FromBody] DrugLocation model)
        {
            _log4net.Info("Input Recieved From Another Api");
            DrugRepository obj = new DrugRepository();
            return obj.getDispatchableDrugStock((int)model.Id, (string)model.Location);
        }*/
        [HttpPost("{DrugId}/{Location}")]
        public IActionResult getDispatchableDrugStock(int DrugId, string Location)
        {
            _log4net.Info("Drug Id = "+DrugId+" and Location = "+Location+" Recieved From refill Api");
            if (DrugId <= 0 || Location == null)
                return BadRequest();
            return Ok(_prov.getDispatchableDrugStock(DrugId, Location));
        }

       // DrugLocation ree = new DrugLocation();
        [HttpGet]
        public IActionResult getdrug()
        {
            var druglocationlist = _Db.TbDruglocation.ToList();
            return Ok(druglocationlist);
        }
    }
}
