using Newtonsoft.Json.Linq;
using SMT.Business;
using SMT.Common;
using SMT.DAL;
using SMT.Entities;
using SMT.MaterialWebService;
using SMT.ServiceInstance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace SMT
{
    public class Repository : IDisposable
    {
        ConfigContext configContext = new ConfigContext();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool UpdateInfo(MachineIOT entity)
        {
            try
            {
                var exist = configContext.MachineIOTs.Find(entity.MAC_ADDRESS);
                if (exist == null)
                {
                    configContext.MachineIOTs.Add(entity);
                    configContext.SaveChanges();
                }
                else
                {
                    exist.HOST_NAME = entity.HOST_NAME;
                    exist.USER = entity.USER;
                    exist.IP_ADDRESS = entity.IP_ADDRESS;
                    exist.LOCATION = entity.LOCATION;
                    exist.UPDATE_TIME = entity.UPDATE_TIME;
                    exist.SLEEP_TIME = entity.SLEEP_TIME;
                    exist.VERSION = entity.VERSION;
                    exist.WINDOWS_EDITION = entity.WINDOWS_EDITION;
                    exist.IS_WINDOWS_64 = entity.IS_WINDOWS_64;
                    exist.IS_WINDOWS_ACTIVE = entity.IS_WINDOWS_ACTIVE;
                    configContext.Entry(exist).State = EntityState.Modified;
                    configContext.SaveChanges();
                }

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return false;
            }
        }

        public LineSetting GetLineSetting(string lineID)
        {
            LineSetting result = null;
            result = configContext.LineSettings.Find(lineID);
            return result;
        }

        public bool LineAddOrUpdate(LineSetting lineInfo)
        {

            try
            {

                var lineExist = configContext.LineSettings.Find(lineInfo.LINE_ID);
                if (lineExist == null)
                {
                    configContext.LineSettings.Add(lineInfo);
                    configContext.SaveChanges();
                    return true;
                }
                lineExist.FEEDER_DAY_USE = lineInfo.FEEDER_DAY_USE;
                lineExist.IS_CHECK_FEEDER = lineInfo.IS_CHECK_FEEDER;
                lineExist.IS_CHECK_RELOAD = lineInfo.IS_CHECK_RELOAD;
                lineExist.IS_CONFIRM_TOKUSAI = lineInfo.IS_CONFIRM_TOKUSAI;
                lineExist.IS_CHECK_VERIFY = lineInfo.IS_CHECK_VERIFY;
                lineExist.UPDATE_TIME = lineInfo.UPDATE_TIME;
                lineExist.UPDATER = lineInfo.UPDATER;
                configContext.Entry<LineSetting>(lineExist).State = EntityState.Modified;
                configContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public List<LineSetting> GetAllLineSetting()
        {
            using (var db = new ConfigContext())
            {
                return db.LineSettings.ToList();
            }
        }


        public void CheckRankLedConfirm(string lineId, MaterialWebService.MATERIAL_ORDERSEntity materialOrder)
        {
            if (Program.lineState != State.NG)
            {
                if (!RankledConfirm(materialOrder.PRODUCTION_ORDER_ID))
                {
                    Program.lineState = State.NG;
                }
                if (Program.lineState == State.NG)
                {
                    Program.FuncNG += "CheckRankLedConfirm";
                }
            }
        }
        private bool RankledConfirm(string orderNo)
        {
            return SingletonHelper.ErpInstance.RankledConfirm(orderNo);
        }
        public MaterialWebService.MATERIAL_ORDERSEntity GetListMaterialOrder(string lineId)
        {
            return SingletonHelper.MaterialInstance.FindMaterialOrder(lineId);
        }
        public Tuple<List<MATERIAL_VIEW>, LineSetting> GetListView(MATERIAL_ORDERSEntity materialOrder, string lineId)
        {
            List<MATERIAL_VIEW> sourceView = new List<MATERIAL_VIEW>();
            var lineConfig = GetLineSetting(lineId);
            if (lineConfig == null) return new Tuple<List<MATERIAL_VIEW>, LineSetting>(sourceView, null);
            if (materialOrder == null)
            {
                return new Tuple<List<MATERIAL_VIEW>, LineSetting>(sourceView, lineConfig);
            }
            var orderItems = SingletonHelper.MaterialInstance.FindMaterialOrderItem(lineConfig.LINE_ID);

            sourceView = orderItems.Select(
            r => new MATERIAL_VIEW()
            {
                UPN_ID = r.UPN_ID,
                MACHINE_SLOT = r.MACHINE_SLOT,
                PART_ID = r.PART_ID,
                FEEDER_ID = r.FEEDER_ID,
                IS_LOADED = r.IS_LOADED == true ? "Yes" : "No",
                TASK = "Load Machine Part",
                MACHINE_ID = r.MACHINE_ID
            }).ToList();
            if (lineConfig.IS_CHECK_FEEDER)
            {
                sourceView.Where(r => r.FEEDER_ID == null && r.MACHINE_SLOT != 999 && r.MACHINE_SLOT != 0).ToList().ForEach(r =>
                {
                    r.IS_LOADED = "No";
                    r.TASK = "Not use feeder!";
                });
            }
            var operationLog = SingletonHelper.MaterialInstance.OperationLogBest(materialOrder.ID, materialOrder.PRODUCT_ID, materialOrder.CUSTOMER_ID, lineConfig.LINE_ID, materialOrder.PRODUCTION_ORDER_ID).ToList();
            foreach (var item in operationLog.Where(r => r.IS_FAILED == true))
            {
                sourceView.Add(new MATERIAL_VIEW()
                {
                    FEEDER_ID = item.FEEDER_ID,
                    MACHINE_ID = item.MACHINE_ID,
                    MACHINE_SLOT = item.MACHINE_SLOT,
                    PART_ID = item.PART_ID,
                    UPN_ID = item.UPN_ID,
                    IS_LOADED = "No",
                    TASK = item.FAULT_REASON
                });
            }
            var feederNg = GetFeederNg(lineConfig.LINE_ID);
            sourceView.AddRange(feederNg);
            var rankledNg = FindRankledNg(materialOrder.PRODUCTION_ORDER_ID);
            if (rankledNg != null)
            {
                sourceView.Add(rankledNg);
            }
            var lstTokusaiNg = FindTokusaiNG(lineConfig.LINE_ID, materialOrder.ID);
            sourceView.AddRange(lstTokusaiNg);

            // Tokusai, ECO
            if (lineConfig.IS_CONFIRM_TOKUSAI)
            {
                var lstTokusaiNotConfirm = FindTokusaiNotConfirm(materialOrder.PRODUCTION_ORDER_ID);
                sourceView.AddRange(lstTokusaiNotConfirm);
            }

            //Not verified
            var lstNotVerified = FindLineNotVerified(lineId);
            sourceView.AddRange(lstNotVerified);

            sourceView = sourceView.OrderBy(r => r.IS_LOADED).ThenBy(h => h.TASK).ToList();
            List<MATERIAL_ORDERSEntity> lstMaterialOrder = new List<MATERIAL_ORDERSEntity>() { materialOrder };
            return new Tuple<List<MATERIAL_VIEW>, LineSetting>(sourceView, lineConfig);
        }

        private bool FeederNotFound(MATERIAL_ORDER_ITEMSEntity[] materialItems)
        {
            return materialItems.Any(r => r.MACHINE_SLOT != 999 && r.MACHINE_SLOT != 0 && string.IsNullOrEmpty(r.FEEDER_ID));
        }
        private int CheckFeederExpried(string lineId, int dayExpried)
        {
            var feederLast = configContext.FeederAlarms.Where(r => r.LINE_ID == lineId).OrderByDescending(h => h.STATE).FirstOrDefault();
            return feederLast == null ? 1 : feederLast.STATE;

        }
        public void CheckTokusai(MaterialWebService.MATERIAL_ORDER_ITEMSEntity[] materialItems, MaterialWebService.MATERIAL_ORDERSEntity materialOrder)
        {
            if (Program.lineState == State.NG)
            {
                return;
            }
            if (materialItems == null || materialItems.Count() == 0 || materialOrder == null)
            {
                Program.lineState = State.NG;
                return;
            }
            Program.lineState = FindTokusaiNG(materialOrder.LINE_ID, materialOrder.ID).Count() != 0 ? State.NG : State.OK;
            if(Program.lineState == State.NG)
            {
                Program.FuncNG += "CheckTokusai";
            }
        }

        public void CheckFeeder(MaterialWebService.MATERIAL_ORDER_ITEMSEntity[] materialItems, LineSetting config)
        {
            if (Program.lineState != State.NG)
            {
                if (config.IS_CHECK_FEEDER)
                {
                    if (FeederNotFound(materialItems))
                    {
                        Program.lineState = State.NG;
                        log.DebugFormat("{0}: Không bắn Feeder", config.LINE_ID);
                    }
                    else
                    {
                        int feederState = CheckFeederExpried(config.LINE_ID, config.FEEDER_DAY_USE);
                        Program.lineState = feederState == 3 ? State.NG : feederState == 2 ? State.WR : State.OK;
                        if (Program.lineState == State.NG)
                        {
                            log.DebugFormat("{0}: Feeder quá hạn bảo dưỡng", config.LINE_ID);
                        }
                    }
                    if (Program.lineState == State.NG)
                    {
                        Program.FuncNG += "CheckFeeder";
                    }
                }
            }
        }

        public void CheckReload(MaterialWebService.MATERIAL_ORDERSEntity materialOrder, LineSetting config)
        {
            if (Program.lineState != State.NG)
            {
                if (config.IS_CHECK_RELOAD && Program.lineState != State.NG)
                {
                    // Kiểm tra trạng thái Check New Part (Operation = 7)
                    var flag = SingletonHelper.OperationLogFailed(materialOrder.ID, materialOrder.PRODUCT_ID, materialOrder.CUSTOMER_ID, config.LINE_ID, materialOrder.PRODUCTION_ORDER_ID);
                    if (flag)
                    {
                        Program.lineState = State.NG;
                        log.DebugFormat("{0}: NG thay nối linh kiện", config.LINE_ID);
                    }
                    if (config.IS_CHECK_FEEDER && Program.lineState != State.NG)
                    {
                        int feederState = CheckFeederExpried(config.LINE_ID, config.FEEDER_DAY_USE);
                        Program.lineState = feederState == 3 ? State.NG : feederState == 2 ? State.WR : State.OK;
                        if (Program.lineState == State.NG)
                        {
                            log.DebugFormat("{0}: Feeder quá hạn bảo dưỡng", config.LINE_ID);
                        }
                    }
                    if (Program.lineState == State.NG)
                    {
                        Program.FuncNG += "CheckReload";
                    }
                }
            }
        }


        public void CheckTokusaiConfirm(MaterialWebService.MATERIAL_ORDERSEntity materialOrder, LineSetting config)
        {
            if (Program.lineState != State.NG)
            {
                if (config.IS_CONFIRM_TOKUSAI)
                {
                    var sql = $@"SELECT t1.WO, t2.DEPT,t2.UPD_TIME
                              FROM [SMT].[dbo].[Tokusai_LineHistory] t1
                              LEFT JOIN [SMT].[dbo].[Tokusai_LineConfirm] t2 ON t2.ID_HISTORY = t1.ID
                              WHERE t1.CHANGE_ID IN ('0','1') AND t1.IS_CONFIRM = '0' AND t1.WO = '{materialOrder.PRODUCTION_ORDER_ID}'";
                    var res = configContext.Database.SqlQuery<LineConfirm>(sql).ToList();
                    var listDeptConfirm = res.Select(r => r.DEPT);
                    if (res.Count > 0)
                    {
                        var flag = listDeptConfirm.Contains("PD") && listDeptConfirm.Contains("TE");
                        if (!flag)
                        {
                            Program.lineState = State.NG;
                        }
                        else
                        {
                            var lastConfirm = res.OrderByDescending(r => r.UPD_TIME).FirstOrDefault();
                            if(lastConfirm.UPD_TIME is DateTime dt)
                            {
                                var time = DateTime.Now - dt;
                                if (time.TotalMinutes >= 60)
                                {
                                    Program.lineState = State.NG;
                                }
                            }
                           
                        }
                    }
                    if (Program.lineState == State.NG)
                    {
                        Program.FuncNG += "CheckTokusaiConfirm";
                    }
                }
            }
        }
        private List<MATERIAL_VIEW> FindTokusaiNG(string lineID, string materialId)
        {
            var lst = configContext.TokusaiItems.Where(r => r.LINE_ID == lineID)
                .Where(r => r.MATERIAL_ORDER_ID == materialId)
                .Where(r => r.IS_FAILED == true)
                .Select(r => new MATERIAL_VIEW()
                {
                    UPN_ID = r.UPN_ID,
                    MACHINE_ID = r.MACHINE_ID,
                    MACHINE_SLOT = r.MACHINE_SLOT,
                    IS_LOADED = "No",
                    PART_ID = r.PART_ID,
                    TASK = r.ERR_TYPE == 1 ? "Linh kiện Tokusai không được sử dụng cho Model này (2020-Ms Huế)!" : "Cần sử dụng hết linh kiện Tokusai trước!"
                }).ToList();
            return lst;
        }


        private List<MATERIAL_VIEW> FindTokusaiNotConfirm(string orderNo)
        {

            var sql = $@"SELECT DISTINCT t1.PART_ID, t1.CHANGE_NAME as 'TASK',t1.MACHINE_ID, t1.MACHINE_SLOT,
                                  CASE 
                                  WHEN t1.IS_CONFIRM ='0' THEN 'No'
                                  ELSE 'Yes'
                                  END as 'IS_LOADED'
                                  FROM [SMT].[dbo].[Tokusai_LineHistory] t1
                                  LEFT JOIN  [SMT].[dbo].[Tokusai_LineConfirm] t2 ON t2.ID_HISTORY = t1.ID
                                  where WO = '{orderNo}' AND IS_CONFIRM = '0'";
            var res = configContext.Database.SqlQuery<MATERIAL_VIEW>(sql).ToList();
            return res.Count == 0 ? new List<MATERIAL_VIEW>() : res;
        }
        public List<MATERIAL_VIEW> GetFeederNg(string lineId)
        {
            List<MATERIAL_VIEW> res = new List<MATERIAL_VIEW>();
            configContext.FeederAlarms.Where(r => r.LINE_ID == lineId && r.STATE == 3).ToList().ForEach(r =>
            {
                res.Add(new MATERIAL_VIEW()
                {
                    FEEDER_ID = r.FEEDER_ID,
                    MACHINE_ID = r.MACHINE_ID,
                    MACHINE_SLOT = r.MACHINE_SLOT,
                    PART_ID = "",
                    UPN_ID = "",
                    IS_LOADED = "No",
                    TASK = r.ABOUT
                });

            });
            return res;
        }
        private MATERIAL_VIEW FindRankledNg(string orderNo)
        {
            MATERIAL_VIEW res = null;
            if (!RankledConfirm(orderNo))
            {
                res = new MATERIAL_VIEW()
                {
                    FEEDER_ID = "",
                    IS_LOADED = "No",
                    MACHINE_ID = "",
                    MACHINE_SLOT = 0,
                    PART_ID = "",
                    TASK = "Chưa xác nhận Rank Led",
                    UPN_ID = ""
                };
            }
            return res;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (disposing)
            {
                configContext.Dispose();
                // Dispose other managed resources.
            }
            //release unmanaged resources.
        }

        internal void CheckVerifiedOrderItem(string lineID, MATERIAL_ORDERSEntity materialOrder, LineSetting lineConfig)
        {
            if (Program.lineState == State.NG) return;
            if (!lineConfig.IS_CHECK_VERIFY) return;
            Program.lineState = FindLineNotVerified(materialOrder.LINE_ID).Count() != 0 ? State.NG : Program.lineState;
            if (Program.lineState == State.NG)
            {
                Program.FuncNG += "CheckVerifiedOrderItem";
            }
        }

        private List<MATERIAL_VIEW> FindLineNotVerified(string lineId)
        {
            using (var db = new ConfigContext())
            {
                DateTime currentTime = SingletonHelper.PVSInstance.GetDateTime();

                var dayShift = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 8, 00, 0);
                if(dayShift.DayOfWeek == DayOfWeek.Monday)
                {
                    dayShift = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 6, 00, 0);
                }
                var dayShift1 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 8, 50, 0);
                var nightShift = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 20, 00, 0);
                var nightShift1 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 20, 50, 0);

                if ((currentTime > dayShift && currentTime < dayShift1)
                    || (currentTime > nightShift && currentTime < nightShift1))
                {
                    return new List<MATERIAL_VIEW>();
                }

                var sql = $@"SELECT [PART_ID]
                                  ,[MACHINE_ID]
                                  ,[MACHINE_SLOT]
                                  ,[UPD_TIME]
                                  ,[PRODUCT_ID]
                                  ,[IS_VERIFIED]
                                  ,[PRODUCTION_ORDER_ID]
                                  ,[IS_VERIFIED]
                              FROM [SMT].[dbo].[LoadedOrderItem] where IS_VERIFIED = 0 and LINE_ID = '{lineId}' ";
                var res = db.Database.SqlQuery<VerifiedLoadedEntity>(sql)
                     .Select(r => new MATERIAL_VIEW()
                     {
                         UPN_ID = "",
                         MACHINE_ID = r.MACHINE_ID,
                         MACHINE_SLOT = r.MACHINE_SLOT,
                         IS_LOADED = "Yes",
                         PART_ID = r.PART_ID,
                         TASK = TEXT.TASK_NOT_VERIFIED,
                     }).ToList();
                return res.Count == 0 ? new List<MATERIAL_VIEW>() : res;
            }

        }

    }
}
