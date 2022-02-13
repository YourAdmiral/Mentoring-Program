using System;
using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Logger;
using BrainstormSessions.Mail;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;

        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public SessionController(IBrainstormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<IActionResult> Index(int? id)
        {
            try
            {
                const string messageStarted = "Session started";

                const string messageFinished = "Session finished";

                const string messageIdWithoutValue = "Id not valid";

                const string messageSessionNotFound = "Session not found";

                log.Debug(messageStarted);

                if (!id.HasValue)
                {
                    MailSender.Send(messageIdWithoutValue);

                    log.Warn(messageIdWithoutValue);

                    return RedirectToAction(actionName: nameof(Index),
                        controllerName: "Home");
                }

                var session = await _sessionRepository.GetByIdAsync(id.Value);

                if (session == null)
                {
                    MailSender.Send(messageSessionNotFound);

                    log.Warn(messageSessionNotFound);

                    return Content("Session not found.");
                }

                var viewModel = new StormSessionViewModel()
                {
                    DateCreated = session.DateCreated,
                    Name = session.Name,
                    Id = session.Id
                };

                log.Debug(messageFinished);

                return View(viewModel);
            }
            catch (Exception ex)
            {
                log.Error($"[{nameof(HomeController)} | {nameof(this.Index)}] {ex.Message}");

                return null;
            }
        }
    }
}
