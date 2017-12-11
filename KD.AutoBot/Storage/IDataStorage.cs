namespace KD.AutoBot.Storage
{
    /// <summary>
    /// Storage for AutoBot internal data.
    /// </summary>
    public interface IDataStorage<TStorageType> : IModule
    {
        /// <summary>
        /// Reads data from specified source.
        /// </summary>
        void ReadData(TStorageType source);
        /// <summary>
        /// Writes given data to specified destination.
        /// </summary>
        void WriteData<TDataType>(TStorageType destination, TDataType[] data);
    }
}