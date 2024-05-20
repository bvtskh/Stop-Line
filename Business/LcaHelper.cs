using SMT.Common;
using SMT.DAL;
using SMT.ServiceInstance;
using System;
using System.Data.Entity;
using System.Linq;

namespace SMT.Business
{
    public class LcaHelper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void UpdateIOT2021(string lineId, MaterialWebService.MATERIAL_ORDERSEntity entity)
        {
            try
            {
                bool flag = !NetworkHelper.CheckConnect(Constant.IOT_SERVER);
                if (flag)
                {
                    log.DebugFormat("{0}: Connection IOT Server Error !!!", entity.LINE_ID);
                    return;
                }
                if (Program.lineState != State.NG)
                {
                    //var meshNo1 = SingletonHelper.GetSteelMesh(lineId);
                    var meshNo = SingletonHelper.MaterialInstance.GetMeshNo(entity.ID.ToString());
                    var squeegeeNo = SingletonHelper.MaterialInstance.GetSqueegeeNo(entity.ID.ToString());
                    using (IOT2021Context iotContext = new IOT2021Context())
                    {
                        var exist = iotContext.PDAInfo_Ver2.FirstOrDefault(r => r.Line == lineId);
                        if (exist is null)
                        {
                            var iotEntity = new PDAInfo_Ver2()
                            {
                                Line = lineId,
                                MaterialOrderId = entity.ID,
                                Model = entity.COMPONENT_ID,
                                TimePDA = SingletonHelper.GetDateTime(),
                                WO = entity.PRODUCTION_ORDER_ID,
                                PlanWO = Convert.ToInt32(entity.QUANTITY),
                                CodePatternPrint = meshNo,
                                MaThanhQuet = squeegeeNo
                            };
                            iotContext.PDAInfo_Ver2.Add(iotEntity);
                            iotContext.SaveChanges();
                        }
                        else if (exist.MaterialOrderId != entity.ID || (exist.MaterialOrderId == entity.ID && exist.WO != entity.PRODUCTION_ORDER_ID))
                        {
                            exist.Line = lineId;
                            exist.MaterialOrderId = entity.ID;
                            exist.Model = entity.COMPONENT_ID;
                            exist.WO = entity.PRODUCTION_ORDER_ID;
                            exist.TimePDA = SingletonHelper.GetDateTime();
                            exist.PlanWO = Convert.ToInt32(entity.QUANTITY);
                            exist.CodePatternPrint = meshNo;
                            exist.MaThanhQuet = squeegeeNo;
                            iotContext.Entry<PDAInfo_Ver2>(exist).State = EntityState.Modified;
                            iotContext.SaveChanges();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(meshNo) || !string.IsNullOrEmpty(squeegeeNo))
                            {
                                string sqlQuery = $@"UPDATE [IOT2021].[dbo].[PDAInfo_Ver2]
                                                SET CodePatternPrint = '{meshNo}',MaThanhQuet = '{squeegeeNo}'
                                                WHERE MaterialOrderId = '{entity.ID}'";
                                int update = iotContext.Database.ExecuteSqlCommand(sqlQuery);
                            }
                            else
                            {
                                //Console.WriteLine($"======> {lineId}");
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("Save IOT Error: ", ex);
            }

        }
    }
}
