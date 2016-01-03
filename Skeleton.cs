using System;

using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI;

namespace Skeleton
{
    public abstract class Skeleton : IMyGridProgram
    {
        public Action<string> Echo
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public TimeSpan ElapsedTime
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IMyGridTerminalSystem GridTerminalSystem
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public bool HasMainMethod
        {
            get { throw new NotImplementedException(); }
        }

        public IMyProgrammableBlock Me
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Storage
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        void IMyGridProgram.Main(string argument)
        {
            throw new NotImplementedException();
        }
    }
}