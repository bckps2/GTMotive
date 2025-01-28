using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public sealed class WebApiPresenter : IWebApiPresenterExtension
    {
        public IActionResult ActionResult { get; private set; }

        public void SetActionResult(IActionResult actionResult)
        {
            ActionResult = actionResult;
        }
    }
}
