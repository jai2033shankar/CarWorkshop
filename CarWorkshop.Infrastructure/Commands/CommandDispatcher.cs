using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {

        private readonly Container _container;
        public CommandDispatcher(Container container)
        {
            _container = container;
        }
        public async Task Dispatch<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                    $"Command: '{typeof(T).Name}' can't be null.");
            }

            var handler = _container.GetInstance<ICommandHandler<T>>();
            await handler.Handle(command);

        }
    }
}
