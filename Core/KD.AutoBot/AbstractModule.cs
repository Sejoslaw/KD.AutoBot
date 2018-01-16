using System;

namespace KD.AutoBot
{
    /// <summary>
    /// Abstract implementation of <see cref="IModule"/>.
    /// </summary>
    public abstract class AbstractModule : BasicDataHolder, IModule
    {
        public IAutoBot Bot { get; }

        public event EventHandler OnPreInitialization;
        public event EventHandler OnPostInitialization;

        protected AbstractModule(IAutoBot bot)
        {
            this.Bot = bot;
        }

        public virtual void Initialize()
        {
            this.OnPreInitialization(this, EventArgs.Empty);
            this.OnPostInitialization(this, EventArgs.Empty);
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
    }
}