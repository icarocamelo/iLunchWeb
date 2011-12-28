using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace iLunchWeb.Infrastructure
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public ControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (requestContext.HttpContext.Request.Path.Contains("ico"))
                return null;

            if (controllerType == null)
            {
                throw new HttpException(404,
                                        string.Format("Controller para o caminho '{0}' não foi encontrado.",
                                                      requestContext.HttpContext.Request.Path));
            }

            try
            {
                var controller = _kernel.Resolve(controllerType);
                return (IController) controller;
            }
            catch (Exception ex)
            {
                throw new HttpException(404,
                                           string.Format("Controller para o caminho '{0}' não foi encontrado.",
                                                         requestContext.HttpContext.Request.Path));
            }
        }
    }
}