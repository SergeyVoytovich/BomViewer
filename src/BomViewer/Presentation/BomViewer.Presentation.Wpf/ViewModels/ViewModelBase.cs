using System;
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

        #endregion


        #region Constructors

        /// <summary>
        /// Initialized new instance
        /// </summary>
        /// <param name="application">Application</param>
        protected ViewModelBase(IApplication application)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }

        #endregion
    }
}