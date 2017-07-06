using System;
using System.Collections.Generic;
using System.Text;
using SimpleInjector;
using SimpleInjector.Packaging;
using CarWorkshop.Infrastructure.Commands;
using System.Reflection;

namespace CarWorkshop.Infrastructure.IoC
{
    public class CommandConfig : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register(typeof(ICommandHandler<>), new[] { typeof(ICommandHandler<>)
                .GetTypeInfo()
                .Assembly},Lifestyle.Scoped);

            container.Register<ICommandDispatcher, CommandDispatcher>(Lifestyle.Scoped);
        }
    }
}
