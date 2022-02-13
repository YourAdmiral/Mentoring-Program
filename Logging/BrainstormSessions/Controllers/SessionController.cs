using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Logger;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]

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
            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            var session = await _sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
                return Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            log.Debug("Expected 2 Debug messages in the logs");

            log.Debug("Expected 2 Debug messages in the logs");

            return View(viewModel);
        }
    }
}
