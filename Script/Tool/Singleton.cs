using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terric.Tool
{
    public class Singleton<T> where T : class, new()
    {
        private static T _instance;
        private static readonly object _instanceLock = new object();

        public static T Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                        _instance = new T();
                    return _instance;
                }
            }
        }
    }
}
