using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using BrainstormSessions.Logger;
using BrainstormSessions.Mail;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
                const string message = "Index method was finished";

                var sessionList = await _sessionRepository.ListAsync();

                var model = sessionList.Select(session => new StormSessionViewModel()
                {
                    Id = session.Id,
                    DateCreated = session.DateCreated,
                    Name = session.Name,
                    IdeaCount = session.Ideas.Count
                });

                MailSender.Send(message);

                log.Info(message);

                return View(model);
            }
            catch (Exception ex)
            {
                MailSender.Send(ex.Message);

                log.Error($"[{nameof(HomeController)} | {nameof(this.Index)}] {ex.Message}");

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
                const string message = "Model is invalid";

                if (!ModelState.IsValid)
                {
                    MailSender.Send(message);

                    log.Warn(message);

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
            catch (Exception ex)
            {
                MailSender.Send(ex.Message);

                log.Error($"[{nameof(HomeController)} | {nameof(this.Index)}] {ex.Message}");

                return null;
            }
        }
    }
}
