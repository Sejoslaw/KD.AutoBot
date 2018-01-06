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

        public AbstractAutoBot()
        {
            this.Id = Guid.NewGuid();
        }

        public virtual bool Equals(IAutoBot other)
        {
            return this.Id.Equals(other.Id);
        }

        public abstract void PauseBot();
        public abstract void RestartBot();
        public abstract void StartBot();
        public abstract void StopBot();
    }
}