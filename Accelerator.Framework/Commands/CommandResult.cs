using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Framework.Commands
{
    /// <summary>
    /// CommandResult
    /// every commandHandler will return this class
    /// </summary>
    public class CommandResult
    {
        /// <summary>
        /// The message that needs to be provided to the user.
        /// </summary>
        public string? Message { get; set; }
        /// <summary>
        /// The result of the operation is returned with the help of this variable.
        /// </summary>
        public bool IsSuccess { get; set; }
        private readonly List<string> _errors = new List<string>();
        /// <summary>
        /// If there is a logical and operational error during the operation, it is recorded in this variable.
        /// </summary>
        public IEnumerable<string> Errors => _errors;
        /// <summary>
        /// Adds an error to the list of errors.
        /// </summary>
        /// <param name="error"></param>
        internal void AddError(string error)
        {
            IsSuccess = false;
            _errors.Add(error);
        }
        /// <summary>
        /// Clears the list of recorded errors
        /// </summary>
        internal void ClearErrors()
        {
            _errors.Clear();
        }
    }
}
