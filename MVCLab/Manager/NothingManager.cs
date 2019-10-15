using MVCLab.Attributes;
using System;
using System.Diagnostics;

namespace MVCLab.Manager
{
    [Interceptor]
    public class NothingManager : ContextBoundObject 
    {
        [MethodLog]
        public void DoNothing()
        {
            Debug.WriteLine(nameof(DoNothing));
        }

        [MethodLog]
        public void DoNothing1()
        {
            Debug.WriteLine(nameof(DoNothing1));
        }
    }
}