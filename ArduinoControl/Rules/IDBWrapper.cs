using Anotar.NLog;

namespace ArduinoControl.Rules
{
    public interface IDbWrapper<T> where T : class
    {
        #region Public Methods

        /// <summary>
        /// Deletes the record.
        /// </summary>
        /// <param name="iD">The i d.</param>
        /// <returns></returns>
        bool DeleteRecord(int iD);

        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <param name="iD">The i d.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        T GetRecord(int iD);

        /// <summary>
        /// Gets the record count.
        /// </summary>
        /// <returns></returns>
        [LogToErrorOnException]
        int GetRecordCount();

        /// <summary>
        /// Adds the record.
        /// </summary>
        /// <param name="record">The record to be added.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        bool AddRecord(ref T record);

        /// <summary>
        /// Updates the record.
        /// </summary>
        /// <param name="record">The record to be updated.</param>
        /// <returns></returns>
        [LogToErrorOnException]
        bool UpdateRecord(ref T record);

        #endregion Public Methods
    }
}