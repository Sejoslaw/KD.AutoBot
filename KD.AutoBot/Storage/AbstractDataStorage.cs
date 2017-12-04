namespace KD.AutoBot.Storage
{
    /// <summary>
    /// Abstract implementation of <see cref="IDataStorage"/>.
    /// </summary>
    public abstract class AbstractDataStorage : AbstractModule, IDataStorage
    {
        public AbstractDataStorage(IAutoBot bot) :
            base(bot)
        {
        }

        public override void Initialize()
        {
        }

        public abstract void ReadData<TStorageType>(TStorageType source);
        public abstract void WriteData<TStorageType, TDataType>(TStorageType destination, TDataType[] data);
    }
}