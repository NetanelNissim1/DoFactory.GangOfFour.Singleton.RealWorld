using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoFactory.GangOfFour.Singleton.RealWorld
{
    class LoadBalancer
    {
        private static LoadBalancer _instance;
        private Random _random = new Random();
        private List<Server> _servers;
        // Lock synchronization object
        private static object syncLock = new object();

        // Constructor (protected)
        protected LoadBalancer()
        {
            // Load list of available servers
            _servers = new List<Server>
        {
         new Server{ Name = "ServerI  ", IP = "120.14.220.18" },
         new Server{ Name = "ServerII ", IP = "120.14.220.19" },
         new Server{ Name = "ServerIII", IP = "120.14.220.20" },
         new Server{ Name = "ServerIV ", IP = "120.14.220.21" },
         new Server{ Name = "ServerV  ", IP = "120.14.220.22" },
        };

        }

        public static LoadBalancer GetLoadBalancer()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoadBalancer();
                    }
                }
            }

            return _instance;
        }

        // Simple, but effective random load balancer
        /// <summary>
        /// 
        /// </summary>
        public Server NextServer
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }
}
