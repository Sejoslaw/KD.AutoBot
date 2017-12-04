namespace KD.AutoBot
{
    /// <summary>
    /// Storage for AutoBot internal data.
    /// </summary>
    public interface IDataStorage : IModule
    {
        /// <summary>
        /// Reads data from specified source.
        /// </summary>
        void ReadData<TStorageType>(TStorageType source);
        /// <summary>
        /// Writes given data to specified destination.
        /// </summary>
        void WriteData<TStorageType, TDataType>(TStorageType destination, TDataType[] data);
    }
}