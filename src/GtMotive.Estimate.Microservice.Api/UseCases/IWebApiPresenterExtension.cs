using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.UseCases
{
    public interface IWebApiPresenterExtension : IWebApiPresenter
    {
        public void SetActionResult(IActionResult actionResult);
    }
}
