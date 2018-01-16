using System;
using System.Collections.Generic;
using KD.AutoBot.AI;
using KD.AutoBot.Connection;
using KD.AutoBot.Input;
using KD.AutoBot.Storage;

namespace KD.AutoBot
{
    /// <summary>
    /// Abstract implementation of <see cref="IAutoBot"/>.
    /// </summary>
    public abstract class AbstractAutoBot : BasicDataHolder, IAutoBot
    {
        public Guid Id { get; private set; }
        public IDataStorage Storage { get; protected set; }
        public IInputHandler InputHandler { get; protected set; }
        public IConnectionHandler ConnectionHandler { get; protected set; }
        public ILearningModule LearningModule { get; protected set; }
        public ICollection<IModule> Modules { get; protected set; }

        public event EventHandler OnPreStart;
        public event EventHandler OnPostStart;
        public event EventHandler OnPrePause;
        public event EventHandler OnPostPause;
        public event EventHandler OnPreStop;
        public event EventHandler OnPostStop;
        public event EventHandler OnPreRestart;
        public event EventHandler OnPostRestart;
        public event EventHandler OnPreInitialization;
        public event EventHandler OnPostInitialization;

        /// <summary>
        /// Describes if an AutoBot is paused.
        /// </summary>
        protected bool IsPaused { get; set; }
        /// <summary>
        /// Describes if an AutoBot is stopped.
        /// </summary>
        protected bool IsStopped { get; set; }

        public AbstractAutoBot()
        {
            this.OnPreInitializationEvent(this, EventArgs.Empty);
            this.Id = Guid.NewGuid();
        }

        public virtual bool Equals(IAutoBot other)
        {
            return this.Id.Equals(other.Id);
        }

        #region Event Calls
        protected void OnPreStartEvent(object sender, EventArgs args)
        {
            if (this.OnPreStart != null)
            {
                this.OnPreStart(sender, args);
            }
        }

        protected void OnPostStartEvent(object sender, EventArgs args)
        {
            if (this.OnPostStart != null)
            {
                this.OnPostStart(sender, args);
            }
        }

        protected void OnPrePauseEvent(object sender, EventArgs args)
        {
            if (this.OnPrePause != null)
            {
                this.OnPrePause(sender, args);
            }
        }

        protected void OnPostPauseEvent(object sender, EventArgs args)
        {
            if (this.OnPostPause != null)
            {
                this.OnPostPause(sender, args);
            }
        }

        protected void OnPreStopEvent(object sender, EventArgs args)
        {
            if (this.OnPreStop != null)
            {
                this.OnPreStop(sender, args);
            }
        }

        protected void OnPostStopEvent(object sender, EventArgs args)
        {
            if (this.OnPostStop != null)
            {
                this.OnPostStop(sender, args);
            }
        }

        protected void OnPreRestartEvent(object sender, EventArgs args)
        {
            if (this.OnPreRestart != null)
            {
                this.OnPreRestart(sender, args);
            }
        }

        protected void OnPostRestartEvent(object sender, EventArgs args)
        {
            if (this.OnPostRestart != null)
            {
                this.OnPostRestart(sender, args);
            }
        }

        protected void OnPreInitializationEvent(object sender, EventArgs args)
        {
            if (this.OnPreInitialization != null)
            {
                this.OnPreInitialization(sender, args);
            }
        }

        protected void OnPostInitializationEvent(object sender, EventArgs args)
        {
            if (this.OnPostInitialization != null)
            {
                this.OnPostInitialization(sender, args);
            }
        }
        #endregion

        public abstract void PauseBot();
        public abstract void RestartBot();
        public abstract void StartBot();
        public abstract void StopBot();
    }
}