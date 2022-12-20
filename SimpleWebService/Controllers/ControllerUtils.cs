using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SimpleWebService.Controllers
{
    public static class ControllerUtils
    {

        internal static ActionResult InernalServerError()
        {
            return new ContentResult() { Content = "Internal Error", StatusCode = (int)HttpStatusCode.InternalServerError };
        }

        internal static ActionResult CreatedResult()
        {
            return new ContentResult() {StatusCode = (int)HttpStatusCode.Created };
        }
    }
}
