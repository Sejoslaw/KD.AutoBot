namespace KD.AutoBot.Storage
{
    /// <summary>
    /// Abstract implementation of <see cref="IDataStorage"/>.
    /// </summary>
    public abstract class AbstractDataStorage<TStorageType> : AbstractModule, IDataStorage<TStorageType>
    {
        protected AbstractDataStorage(IAutoBot bot) :
            base(bot)
        {
        }

        public override void Initialize()
        {
        }

        public abstract void ReadData(TStorageType source);
        public abstract void WriteData<TDataType>(TStorageType destination, TDataType[] data);
    }
}