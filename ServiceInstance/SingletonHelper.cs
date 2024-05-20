using SMT.Business;
using SMT.DAL;
using SMT.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.ServiceInstance
{
    public class SingletonHelper
    {
        private static volatile PVSServiceReference.PVSWebServiceSoapClient _pvs_service;
        private static volatile MaterialWebService.MaterialWebServiceSoapClient _material_service;
        private static volatile UsapService.USAPWebServiceSoapClient _usap_service;
        private static volatile ErpService.ERPWebServiceSoapClient _erp_service;
        private static object sync = new object();
        public static PVSServiceReference.PVSWebServiceSoapClient PVSInstance
        {
            get
            {
                if (_pvs_service == null)
                {
                    lock (sync)
                    {
                        if (_pvs_service == null)
                        {
                            _pvs_service = new PVSServiceReference.PVSWebServiceSoapClient();
                        }
                    }
                }
                return _pvs_service;
            }
        }

        public static MaterialWebService.MaterialWebServiceSoapClient MaterialInstance
        {
            get
            {
                if (_material_service == null)
                {
                    lock (sync)
                    {
                        if (_material_service == null)
                        {
                            _material_service = new MaterialWebService.MaterialWebServiceSoapClient();
                        }
                    }
                }
                return _material_service;
            }
        }

        public static UsapService.USAPWebServiceSoapClient UsapInstance
        {
            get
            {
                if (_usap_service == null)
                {
                    lock (sync)
                    {
                        if (_usap_service == null)
                        {
                            _usap_service = new UsapService.USAPWebServiceSoapClient();
                        }
                    }
                }
                return _usap_service;
            }
        }

        public static ErpService.ERPWebServiceSoapClient ErpInstance
        {
            get
            {
                if (_erp_service == null)
                {
                    lock (sync)
                    {
                        if (_erp_service == null)
                        {
                            _erp_service = new ErpService.ERPWebServiceSoapClient();
                        }
                    }
                }
                return _erp_service;
            }
        }

        public static DateTime GetDateTime()
        {
            DateTime dateTime;
            try
            {
                dateTime = PVSInstance.GetDateTime();
            }
            catch
            {

                dateTime = DateTime.Now;
            }
            return dateTime;
        }

        public static PVSServiceReference.USERSEntity GetUserLogin(string username, string password)
        {
            return PVSInstance.CheckUserLogin(username, password);
        }

        public static bool IsAdmin(string userId)
        {
            var roleMember = PVSInstance.GetRoleMember(userId);
            var isAdmin = roleMember.Any(r => r.ROLE_ID.Contains("ADMINISTRATORS")) ? true : false;
            return isAdmin;
        }

        public static void SaveModel(MaterialWebService.MATERIAL_ORDERSEntity materialOrder)
        {
            if (materialOrder == null)
            {
                return;
            }
            var model = SingletonHelper.PVSInstance.GetModelInfo(materialOrder.PRODUCT_ID);
            if (model == null)
            {
                var entity = new PVSServiceReference.Base_ModelsEntity()
                {
                    Product_Id = materialOrder.PRODUCT_ID,
                    Customer = materialOrder.CUSTOMER_ID,
                    Component_Id = materialOrder.PRODUCT_ID,
                    Check_First = false,
                    Content = "",
                    Des = "",
                    Is_Wip = true,
                    Pcb = 1,
                    Group_Id = "",
                    Pcb_Label = 1,
                    Location = 1,
                    Is_Hexa = false,
                    Is_SubBoard = false
                };
                SingletonHelper.PVSInstance.SaveModelInfo(entity, "");
            }
            else if (model.Customer != materialOrder.CUSTOMER_ID)
            {
                model.Customer = materialOrder.CUSTOMER_ID;
                SingletonHelper.PVSInstance.SaveModelInfo(model, model.Product_Id);
            }
        }

        public static bool OperationLogFailed(string materialId, string productId, string customer, string lineId, string orderNo)
        {
            var operationLog = SingletonHelper.MaterialInstance.OperationLogBest(materialId, productId, customer, lineId, orderNo);
            return operationLog.Any(r => r.IS_FAILED);
        }

        //public static string GetSqueegeeNo(string lineId)
        //{
        //    var sqeege = SingletonHelper.MaterialInstance.FindSqueege(lineId);
        //    var value = sqeege is null ? "" : sqeege.SQUEEGEE_NO;
        //    return value;
        //}
        public static List<string> GetAllLine()
        {
            var allLine = SingletonHelper.MaterialInstance.MaterialLines().Select(r => r.LINE_ID.ToUpper()).Distinct().ToList();
            allLine.Sort();
            return allLine;
        }
        //public static List<MATERIAL_VIEW> GetListNg(LineSetting lineConfig)
        //{
        //    List<MATERIAL_VIEW> sourceView = new List<MATERIAL_VIEW>();
        //    var materialOrder = SingletonHelper.MaterialInstance.GetLineStartByLineId(lineConfig.LINE_ID);
        //    if (materialOrder != null)
        //    {
        //        if (lineConfig != null)
        //        {
        //            MaterialWebService.MATERIAL_ORDER_ITEMSEntity[] orderItems = null;
        //            orderItems = SingletonHelper.MaterialInstance.GetListOrderItemsById(materialOrder.ID);
        //            sourceView = orderItems.Select(r => new MATERIAL_VIEW() { UPN_ID = r.UPN_ID, MACHINE_SLOT = r.MACHINE_SLOT, PART_ID = r.PART_ID, FEEDER_ID = r.FEEDER_ID, IS_LOADED = r.IS_LOADED == true ? "Yes" : "No", TASK = "Load Machine Part", MACHINE_ID = r.MACHINE_ID }).ToList();
        //            var operationLog = SingletonHelper.MaterialInstance.OperationLogBest(materialOrder.ID, materialOrder.PRODUCT_ID, materialOrder.CUSTOMER_ID, lineConfig.LINE_ID, materialOrder.PRODUCTION_ORDER_ID).ToList();
        //            var opeNg = operationLog.Where(r => r.IS_FAILED == true).ToList();
        //            foreach (var item in opeNg)
        //            {
        //                sourceView.Add(new MATERIAL_VIEW()
        //                {
        //                    FEEDER_ID = item.FEEDER_ID,
        //                    MACHINE_ID = item.MACHINE_ID,
        //                    MACHINE_SLOT = item.MACHINE_SLOT,
        //                    PART_ID = item.PART_ID,
        //                    UPN_ID = item.UPN_ID,
        //                    IS_LOADED = "No",
        //                    TASK = item.FAULT_REASON
        //                });
        //            }
        //            if (lineConfig.IS_CHECK_FEEDER)
        //            {
        //                var feeders = orderItems.Where(r => r.MACHINE_SLOT != 999 && r.MACHINE_SLOT != 0 && r.FEEDER_ID != "").ToList();
        //                var feederNG = Repository.GetFeederNgMaterialOrderItem(feeders, lineConfig.LINE_ID, lineConfig.FEEDER_DAY_USE).Where(r => r.STATE == 3);
        //                foreach (var item in feederNG)
        //                {
        //                    sourceView.Add(new MATERIAL_VIEW()
        //                    {
        //                        FEEDER_ID = item.FEEDER_ID,
        //                        MACHINE_ID = item.MACHINE_ID,
        //                        MACHINE_SLOT = item.MACHINE_SLOT,
        //                        PART_ID = "",
        //                        UPN_ID = "",
        //                        IS_LOADED = "No",
        //                        TASK = item.ABOUT
        //                    });
        //                }
        //            }

        //            var flg = !Repository.IsRankledNg(lineConfig.LINE_ID, materialOrder.PRODUCTION_ORDER_ID);
        //            if (flg)
        //            {
        //                sourceView.Add(new MATERIAL_VIEW()
        //                {
        //                    FEEDER_ID = "",
        //                    IS_LOADED = "No",
        //                    MACHINE_ID = "",
        //                    MACHINE_SLOT = 0,
        //                    PART_ID = "",
        //                    TASK = "Chưa xác nhận Rank Led",
        //                    UPN_ID = ""
        //                });
        //            }
        //            var lstTokusaiNg = tokusaiService.CheckTokusai(orderItems, materialOrder.PRODUCT_ID);
        //            foreach (var item in lstTokusaiNg)
        //            {
        //                sourceView.Add(new MATERIAL_VIEW()
        //                {
        //                    FEEDER_ID = item.FEEDER_ID,
        //                    IS_LOADED = "No",
        //                    MACHINE_ID = item.MACHINE_ID,
        //                    MACHINE_SLOT = item.MACHINE_SLOT,
        //                    PART_ID = item.PART_ID,
        //                    TASK = "Linh kiện Tokusai không được sử dụng cho Model này",
        //                    UPN_ID = item.UPN_ID
        //                });
        //            }
        //            sourceView = sourceView.OrderBy(r => r.IS_LOADED).ThenBy(h => h.TASK).ToList();
        //        }
        //    }
        //    return sourceView;
        //}


        //public static MaterialWebService.MATERIAL_ORDER_ITEMSEntity[] GetMaterialOrderItem(string id)
        //{
        //    var materialItems = SingletonHelper.MaterialInstance.GetListOrderItemsById(id);
        //    return materialItems;
        //}
        //public static List<ErpService.WH_TokusaiEntity> FindPartTokusai(string partTo)
        //{
        //    if (string.IsNullOrEmpty(partTo))
        //    {
        //        return null;
        //    }
        //    return SingletonHelper.ErpInstance.FindPartTokusai(partTo).ToList();
        //}
    }
}
