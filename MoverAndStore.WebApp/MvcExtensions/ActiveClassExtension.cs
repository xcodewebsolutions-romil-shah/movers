using Microsoft.AspNetCore.Mvc.Rendering;

namespace MoverAndStore.WebApp.MvcExtensions
{
    public static class ActiveClassExtension
    {
        public static string? ActiveMenu(this IHtmlHelper htmlHelper, string? controllers = null, string? cssClass = "active pcoded-trigger")
        {
            var currentController = htmlHelper?.ViewContext.RouteData.Values["controller"] as string;
            var acceptedControllers = (controllers ?? currentController ?? "").Split(',');
            return acceptedControllers.Contains(currentController) ? cssClass : "";
        }

        public static string? ActiveSubMenu(this IHtmlHelper htmlHelper, string? controllers = null, string? actions = null, string? cssClass = "active")
        {
            var currentController = htmlHelper?.ViewContext.RouteData.Values["controller"] as string;
            var currentAction = htmlHelper?.ViewContext.RouteData.Values["action"] as string;
            var acceptedControllers = (controllers ?? currentController ?? "").Split(',');
            var acceptedActions = (actions ?? currentAction ?? "").Split(',');
            return acceptedControllers.Contains(currentController) && acceptedActions.Contains(currentAction) ? cssClass : "";
        }
    }
}