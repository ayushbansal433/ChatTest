using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatTest.API.Helper;
using ChatTest.Common.DbModels;
using ChatTest.Common.DTOs;
using ChatTest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatTest.API.Controllers
{
    [Route("api/v1/signal")]
    public class SignalController : Controller
    {
        private readonly IUnitOfWork uow;
        private readonly IHubContext<Signal> hubContext;

        public SignalController(IUnitOfWork uow, IHubContext<Signal> hubContext)
        {
            this.uow = uow;
            this.hubContext = hubContext;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SaveSignalAsync(SignalInputModel signal)
        {
            try
            {
                SignalDataModel data = new SignalDataModel() { 
                    AccessCode= signal.AccessCode,
                    Area= signal.Area,
                    CustomerName= signal.CustomerName,
                    Description= signal.Description,
                    SignalDate= DateTime.Now,
                    Zone= signal.Zone
                };
                await uow.SignalRepository.AddAsync(data);
                if (await uow.SaveChangesAsync()>0)
                {
                    SignalVM signalVM = new SignalVM()
                    {
                        AccessCode = signal.AccessCode,
                        Area = signal.Area,
                        CustomerName = signal.CustomerName,
                        Description = signal.Description,
                        SignalDate = data.SignalDate,
                        Zone = signal.Zone
                    };
                    await this.hubContext.Clients.All.SendAsync("SignalMessageReceived", signalVM);
                    return Ok();
                }
                return BadRequest(new { message = "Some error occured." });

            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
