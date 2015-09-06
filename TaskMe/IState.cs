using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskMe
{
    public interface IState
    {
        /// <summary>
        /// returns the next state to run as
        /// </summary>
        IState run();
    }
}
