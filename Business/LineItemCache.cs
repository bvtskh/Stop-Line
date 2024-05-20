using SMT.MaterialWebService;
using SMT.ServiceInstance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.Business
{
    public class LineItemCache
    {
        public static Dictionary<string, MATERIAL_ORDER_ITEMSEntity[]> _cache;
        private static LineItemCache _instance;

        protected LineItemCache()
        {
        }

        public static LineItemCache Instance()
        {
            if (_instance == null)
            {
                _instance = new LineItemCache();
            }
            return _instance;
        }
        public static void AddCache(string lineID)
        {
            _cache.Add(lineID, SingletonHelper.MaterialInstance.FindMaterialOrderItem(lineID));
        }

        public static void RemoveCache(string lineID)
        {
        }
    }
}
