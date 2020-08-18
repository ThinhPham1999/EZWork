using EZWork.Core.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using EZWork.Core.DBContext;
using EZWork.Core.Entities;
using System.Web;
using System.Web.Mvc;

namespace EZWork.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        private void AddBindings()
        {
            kernel.Bind<IEZSellerRepository>().To<EFSellerRepository>();
        }
    }
}