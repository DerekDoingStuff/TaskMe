using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMe
{
    public class StateManager
    {
        public IState state;

        public void run()
        {
            while(state != null)
                state = state.run();
        }

        public StateManager(IState startingState)
        {
            state = startingState;
        }
    }
}
