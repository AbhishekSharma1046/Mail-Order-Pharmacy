using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubscriptionService.Repository;
using SubscriptionService.Provider;
using SubscriptionService.Models;
using Microsoft.AspNetCore.Authorization;

namespace SubscriptionService.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
   
    public class SubscribeController : ControllerBase
    {
        private readonly SubContext _Db;
        ISubscribeProvider Provider;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(SubscribeController));
        
        public SubscribeController(ISubscribeProvider subscribeDrugs1,SubContext Db)
        {
            _Db = Db;
            Provider = subscribeDrugs1;
        }

        [HttpPost("{PolicyDetails}/{MemberId}")]
        public async Task<IActionResult> PostSubscribe([FromBody] PrescriptionDetails details, [FromHeader(Name = "Authorization")] string auth)
        {
            //[FromHeader(Name = "Authorization")] string auth
            string PolicyDetails = "PolicyDetails";
              int MemberId = 1;
            SubscriptionDetails data = new SubscriptionDetails() ;
            
                if (details == null || PolicyDetails == null || MemberId <= 0 || auth == null)
                {
                    //|| auth == null
                    _log4net.Info("PrescriptionDetails is null or " + "MemberId is= " + MemberId + " PolicyDetails is= " + PolicyDetails + " less or equal to  zero");
                    return BadRequest();
                }
                _log4net.Info("Subscription Request is raised from client side  for Drug= " + details.DrugName);

                 bool ata=Provider.Subscribe(details, PolicyDetails, MemberId, auth);
            
            
                _Db.TbPrescriptionDetails.Add(details);
                await _Db.SaveChangesAsync();
            

            
            return Ok(ata);
        }
     
        [HttpGet("{MemberId}/{SubscriptionId}")]
        public IActionResult PostUnsubscribe([FromRoute]int MemberId,int SubscriptionId, [FromHeader(Name="Authorization")] string auth)
        {
            SubscribeDrugs s = new SubscribeDrugs();
            SubscriptionDetails data = new SubscriptionDetails();
            _log4net.Info("UnSubscribe Request is raised from client side for subscriptionid = " + SubscriptionId);
           
                if (MemberId <= 0 || SubscriptionId <= 0||auth==null)
                {
                    _log4net.Info("MemberId is" + MemberId + "SubscriptionId is " + SubscriptionId + " less or equal to  zero");
                    return BadRequest();
                }
               // data = Provider.UnSubscribe(MemberId, SubscriptionId,auth);
           
            return Ok(s.PostUnSubscription(MemberId, SubscriptionId, auth));
        }
        [HttpGet]
        public IActionResult getdrug()
        {
            return Ok();
        }
       
    }
}
