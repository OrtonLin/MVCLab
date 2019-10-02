using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCLab.Utility
{
    public class TaskUtility
    {
        public static void RunAndForget(Func<Task> fn)
        {
            Task.Run(fn).ConfigureAwait(false);
        }
    }
}