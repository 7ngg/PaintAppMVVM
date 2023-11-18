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
        private readonly Delegate? _action;
        private readonly Delegate? _canExecute;

        public LambdaCommand(Action<object?> action, Func<object?, bool>? canExecute = null)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _canExecute = canExecute;
        }

        public LambdaCommand(Action action, Func<bool>? canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public LambdaCommand(Action action, Func<object?, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public LambdaCommand(Action<object?> action, Func<bool>? canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object? parameter)
        {
            return _canExecute switch
            {
                null                            => true,
                Func<bool> canExecute           => canExecute(),
                Func<object, bool> canExecute   => canExecute(parameter),
                _                               => throw new InvalidOperationException()
            };
        }

        public override void Execute(object? parameter)
        {
            switch (_action)
            {
                case Action execute:
                    execute();
                    break;

                case Action<object?> execute:
                    execute(parameter);
                    break;

                case null:
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
