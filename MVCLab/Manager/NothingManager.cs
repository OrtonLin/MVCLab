using MVCLab.Attribute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

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