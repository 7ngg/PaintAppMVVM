using BoardApp.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardApp.Infrastructure.Commands
{
    internal class LambdaCommand : MyCommand
    {
        private readonly Action<object> _action;
        private readonly Func<object, bool> _canExecute;

        public LambdaCommand(Action<object> action, Func<object, bool> canExecute = null)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object? parameter)
        {
            _action(parameter);
        }
    }
}
