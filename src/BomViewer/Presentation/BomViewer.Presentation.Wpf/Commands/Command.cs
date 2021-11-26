#nullable enable
using System;
using System.Windows.Input;

namespace BomViewer.Presentation.Wpf.Commands
{
    /// <summary>
    /// Async command
    /// </summary>
    public class Command : ICommand
    {
        #region Fields

        private readonly Action _action;
        private readonly Func<bool> _canExecute;

        #endregion


        #region Events

        public event EventHandler? CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="action">Action to execution</param>
        public Command(Action action) : this(action, () => true)
        {
        }

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="action">Action to execution</param>
        /// <param name="canExecute">Can execute function</param>
        public Command(Action action, Func<bool> canExecute)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        #endregion


        #region Methods

        /// <summary>
        /// Can execute
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        /// <returns>All times true</returns>
        public bool CanExecute(object? parameter)
            => _canExecute();

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        public void Execute(object? parameter)
            => _action();

        #endregion
    }

    /// <summary>
    /// Async command
    /// </summary>
    public class Command<T> : ICommand
    {
        #region Fields

        private readonly Action<T> _action;
        private readonly Func<T, bool> _canExecute;

        #endregion


        #region Events

        public event EventHandler? CanExecuteChanged;

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="action">Action to execution</param>
        public Command(Action<T> action) : this(action, _ => true)
        {
        }

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="action">Action to execution</param>
        /// <param name="canExecute">Can execute function</param>
        public Command(Action<T> action, Func<T, bool> canExecute)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        #endregion


        #region Methods

        /// <summary>
        /// Can execute
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        /// <returns>All times true</returns>
        public bool CanExecute(object? parameter)
            => _canExecute(parameter is T typed ? typed : default!);

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="parameter">Command parameter</param>
        public void Execute(object? parameter)
            => _action(parameter is T typed ? typed : default!);

        #endregion
    }
}