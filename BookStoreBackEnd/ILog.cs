using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepositoryLayer.Logger
{
    public interface ILog
    {
        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}
