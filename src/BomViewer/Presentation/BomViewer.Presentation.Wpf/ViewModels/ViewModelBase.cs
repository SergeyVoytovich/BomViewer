using System;
using AutoMapper;
using BomViewer.Application;

namespace BomViewer.Presentation.Wpf.ViewModels
{
    /// <summary>
    /// Base view model
    /// </summary>
    public abstract class ViewModelBase : NotifyChangedBase
    {
        #region Properties

        /// <summary>
        /// Application
        /// </summary>
        protected IApplication Application { get; }

        /// <summary>
        /// Mapper
        /// </summary>
        protected IMapper Mapper { get; }

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="environment">The view model environment</param>
        protected ViewModelBase(ViewModelEnvironment environment)
        {
            Application = environment.Application ?? throw new ArgumentNullException(nameof(ViewModelEnvironment.Application));
            Mapper = environment.Mapper ?? throw new ArgumentNullException(nameof(ViewModelEnvironment.Mapper));
        }

        #endregion


        #region Methods

        protected virtual T ViewModel<T>(Func<ViewModelEnvironment, T> init)
            => init(new ViewModelEnvironment(Application, Mapper));

        #endregion
    }
}