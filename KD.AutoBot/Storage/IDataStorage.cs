namespace KD.AutoBot.Storage
{
    /// <summary>
    /// Storage for AutoBot internal data.
    /// </summary>
    public interface IDataStorage : IModule
    {
        /// <summary>
        /// Reads data from specified source.
        /// </summary>
        void ReadData(object source);
        /// <summary>
        /// Writes given data to specified destination.
        /// </summary>
        void WriteData(object destination, object data);
    }
}