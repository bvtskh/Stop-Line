using SMT.ServiceInstance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.Business
{
    public static class UmeHelper
    {
        public static State State = State.OK;
        private static List<MaterialWebService.MATERIAL_ORDER_ITEMSEntity> _OderItems;
        public static List<MaterialWebService.MATERIAL_ORDER_ITEMSEntity> OderItems
        {
            get
            {
                return _OderItems;
            }
        }
        private static MaterialWebService.MATERIAL_ORDERSEntity _Oder;
        public static MaterialWebService.MATERIAL_ORDERSEntity Oder
        {
            get
            {
                return _Oder;
            }
        }
        public static void FindUmesInfo(string lineID)
        {
            _OderItems = SingletonHelper.MaterialInstance.FindMaterialOrderItem(lineID).ToList();
            if (_OderItems == null || _OderItems.Count == 0)
            {
                State = State.NG;
                return;
            }
            _Oder = SingletonHelper.MaterialInstance.FindMaterialOrder(lineID);
            if (_Oder == null)
            {
                State = State.NG;
            }
        }
    }
}
