namespace KD.AutoBot.Storage
{
    /// <summary>
    /// Abstract implementation of <see cref="IDataStorage"/>.
    /// </summary>
    public abstract class AbstractDataStorage : AbstractModule, IDataStorage
    {
        protected AbstractDataStorage(IAutoBot bot) :
            base(bot)
        {
        }

        public override void Initialize()
        {
        }

        public abstract void ReadData(object source);
        public abstract void WriteData(object destination, object data);
    }
}