using SMT.ServiceInstance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.Business
{
    public class UpnCache
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const int cacheLengt = 4500;
        private static void AddCache(string bcNo)
        {
            ClearCache();
            if (Program._upn_cache.All(r => r.BC_NO != bcNo))
            {
                var entity = SingletonHelper.UsapInstance.GetByBcNo(bcNo);
                if (entity != null)
                {
                    Program._upn_cache.Add(entity);
                    //Console.WriteLine("Add new: " + bcNo+ " Total Upn: " + Program._upn_cache.Count);
                }
            }
        }
        private static void ClearCache()
        {
            if (Program._upn_cache.Count >= cacheLengt)
            {
                Program._upn_cache.Clear();
               // Console.WriteLine("==================================== Clear Cache ======================");
                log.DebugFormat("{0} clear cache.", Environment.MachineName);
            }
        }
        public static UsapService.BCLBFLMEntity FindBc(string bcNo)
        {
            AddCache(bcNo);
            return Program._upn_cache.FirstOrDefault(r => r.BC_NO == bcNo);
        }
       
    }
}
