using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HandleInvalidModelState.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class HandleInvalidModelWithRedirectActionFilterAttribute : InvalidModelStateActionFilterBase
    {
        private readonly string _redirectUrl;

        public HandleInvalidModelWithRedirectActionFilterAttribute(
            string action,
            IUrlHelper urlHelper)
            => _redirectUrl = urlHelper.Action(action);

        public HandleInvalidModelWithRedirectActionFilterAttribute(
            string action,
            object values,
            IUrlHelper urlHelper)
            => _redirectUrl = urlHelper.Action(action, values);

        public HandleInvalidModelWithRedirectActionFilterAttribute(
            string action,
            string controller,
            IUrlHelper urlHelper)
            => _redirectUrl = urlHelper.Action(action, controller);

        public HandleInvalidModelWithRedirectActionFilterAttribute(
            string action,
            string controller,
            object values,
            IUrlHelper urlHelper)
            => _redirectUrl = urlHelper.Action(action, controller, values);

        public HandleInvalidModelWithRedirectActionFilterAttribute(
            string action,
            string controller,
            object values,
            string protocol,
            IUrlHelper urlHelper)
            => _redirectUrl = urlHelper.Action(action, controller, values, protocol);

        public HandleInvalidModelWithRedirectActionFilterAttribute(string action,
            string controller, object values,
            string protocol,
            string host,
            IUrlHelper urlHelper)
            => _redirectUrl = urlHelper.Action(action, controller, values, protocol, host);

        public HandleInvalidModelWithRedirectActionFilterAttribute(
            string action,
            string controller,
            object values,
            string protocol,
            string host,
            string fragment,
            IUrlHelper urlHelper)
            => _redirectUrl = urlHelper.Action(action, controller, values, protocol, host, fragment);

        public override Task OnActionWithInvalidModelStateExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            context.Result = new RedirectResult(_redirectUrl, false);
            return Task.CompletedTask;
        }
    }
}