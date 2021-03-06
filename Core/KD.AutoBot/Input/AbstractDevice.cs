﻿namespace KD.AutoBot.Input
{
    /// <summary>
    /// Abstract implementation of <see cref="IDevice"/>
    /// </summary>
    public abstract class AbstractDevice : BasicDataHolder, IDevice
    {
        public IInputHandler InputHandler { get; set; }

        protected AbstractDevice(IInputHandler inputHandler)
        {
            this.InputHandler = inputHandler;
        }

        public abstract void Initialize();
    }
}