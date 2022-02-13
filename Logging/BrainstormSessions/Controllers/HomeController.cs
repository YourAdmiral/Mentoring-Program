using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using BrainstormSessions.Logger;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace BrainstormSessions.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;

        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public HomeController(IBrainstormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var sessionList = await _sessionRepository.ListAsync();

                var model = sessionList.Select(session => new StormSessionViewModel()
                {
                    Id = session.Id,
                    DateCreated = session.DateCreated,
                    Name = session.Name,
                    IdeaCount = session.Ideas.Count
                });

                log.Info("Expected Info messages in the logs");

                return View(model);
            }
            catch (Exception e)
            {
                log.Error("Expected Error messages in the logs");

                return null;
            }
        }

        public class NewSessionModel
        {
            [Required]
            public string SessionName { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewSessionModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    log.Warn("Expected Warn messages in the logs");

                    return BadRequest(ModelState);
                }
                else
                {
                    await _sessionRepository.AddAsync(new BrainstormSession()
                    {
                        DateCreated = DateTimeOffset.Now,
                        Name = model.SessionName
                    });
                }

                return RedirectToAction(actionName: nameof(Index));
            }
            catch (Exception e)
            {
                log.Error("Expected Error messages in the logs");

                return null;
            }
        }
    }
}
