using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool_Management.DataAccess;

namespace Tool_Management.Service.Utils
{
  
    public class Common
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        //取刀具配置系統編號
        public string GetKnifeListID()
        {
            string yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");
            string sn = "";
            var result = _db.KnifeLists.OrderByDescending(x => x.KnifeList_ID.Contains(yyyyMMdd)).FirstOrDefault();
            if (result == null)
                sn = yyyyMMdd + "000001";
            else
                sn = (decimal.Parse(result.KnifeList_ID) + 1).ToString();
            return sn;
        }

        //取入庫單號
        public string GetInfromID()
        {
            string yyyyMMdd = DateTime.Now.ToString("yyyyMMdd");
            string sn = "";
            var result = _db.Informs.OrderByDescending(x => x.Inform_ID.Contains(yyyyMMdd)).FirstOrDefault();
            if (result == null)
                sn = yyyyMMdd + "000001";
            else
                sn = (decimal.Parse(result.Inform_ID) + 1).ToString();
            return sn;
        }


        //取已入庫的刀具編號KnifeDetail_ID
        public string GetKnifeDetailID(string KnifeMasterID)
        {
            string KnifeDetailIDs = "";
            if (KnifeMasterID.Contains("za0206933") || KnifeMasterID.Contains("za0206353")) //四刀具,四螺帽
            {
                var result = _db.KnifeDetails.OrderBy(x => x.KnifeMaster_ID.Equals(KnifeMasterID) && int.Parse(x.KnifeDetail_Status) < 3).Take(4).ToList();
                foreach(var i  in result)
                {
                    KnifeDetailIDs = KnifeDetailIDs +";" + i.KnifeDetail_ID;
                }
                return KnifeDetailIDs.Substring(1);
            }
            else if (KnifeMasterID.Contains("za0206513") || KnifeMasterID.Contains("za0205586")) //二刀具,二螺帽
            {
                var result = _db.KnifeDetails.OrderBy(x => x.KnifeMaster_ID.Equals(KnifeMasterID) && int.Parse(x.KnifeDetail_Status) < 3).Take(2).ToList();
                foreach (var i in result)
                {
                    KnifeDetailIDs = KnifeDetailIDs + ";" + i.KnifeDetail_ID;
                }
                return KnifeDetailIDs.Substring(1);
            }
            else {
                var result = _db.KnifeDetails.OrderBy(x => x.KnifeMaster_ID.Equals(KnifeMasterID) && int.Parse(x.KnifeDetail_Status) < 3).First();
                return result.KnifeDetail_ID;
            }
        }

        //取已出庫的刀具編號KnifeDetail_ID
        public KnifeDetail GetKnifeOutDetailID(string KnifeMasterID)
        {
            //string KnifeDetailIDs = "";
            //if (KnifeMasterID.Contains("za0206933") || KnifeMasterID.Contains("za0206353")) //四刀具,四螺帽
            //{
            //    var result = _db.KnifeDetails.OrderBy(x => x.KnifeMaster_ID.Equals(KnifeMasterID) && ( int.Parse(x.KnifeDetail_Status) == 3 || int.Parse(x.KnifeDetail_Status) == 4)).Take(4).ToList();
            //    foreach (var i in result)
            //    {
            //        KnifeDetailIDs = KnifeDetailIDs + ";" + i.KnifeDetail_ID;
            //    }
            //    return KnifeDetailIDs.Substring(1);
            //}
            //else if (KnifeMasterID.Contains("za0206513") || KnifeMasterID.Contains("za0205586")) //二刀具,二螺帽
            //{
            //    var result = _db.KnifeDetails.OrderBy(x => x.KnifeMaster_ID.Equals(KnifeMasterID) && (int.Parse(x.KnifeDetail_Status) == 3|| int.Parse(x.KnifeDetail_Status) == 4)).Take(2).ToList();
            //    foreach (var i in result)
            //    {
            //        KnifeDetailIDs = KnifeDetailIDs + ";" + i.KnifeDetail_ID;
            //    }
            //    return KnifeDetailIDs.Substring(1);
            //}
            //else
            //{
            var result = _db.KnifeDetails.OrderBy(x => x.KnifeMaster_ID.Equals(KnifeMasterID) && (x.KnifeDetail_Status.EndsWith("3") || x.KnifeDetail_Status.EndsWith("4"))).FirstOrDefault();
                return result;
            //}
        }

        //取已入庫的刀把編號HiltDetail_ID
        public string GetHiltDetailID(string HiltMasterID)
        {
            var result = _db.HiltDetails.OrderBy(x => x.HiltMaster_ID.Equals(HiltMasterID) && int.Parse(x.HiltDetail_Status) < 3).First();
            return result.HiltDetail_ID;
        }

        //取已出庫的刀把編號HiltDetail_ID
        public HiltDetail GetHiltOutDetailID(string HiltMasterID)
        {
            var result = _db.HiltDetails.OrderBy(x => x.HiltMaster_ID.Equals(HiltMasterID) && (x.HiltDetail_Status == "3" || x.HiltDetail_Status == "4")).FirstOrDefault();
            return result;
        }

        //取已入庫的拉丁編號NailDetail_ID
        public string GetNailDetailID(string NailMasterID)
        {
            var result = _db.NailDetails.OrderBy(x => x.NailMaster_ID.Equals(NailMasterID) && int.Parse(x.NailDetail_Status) < 3).First();
            return result.NailDetail_ID;
        }

        //取已出庫的拉丁編號NailDetail_ID
        public NailDetail GetNailOutDetailID(string NailMasterID)
        {
            var result = _db.NailDetails.OrderBy(x => x.NailMaster_ID.Equals(NailMasterID) && (int.Parse(x.NailDetail_Status) == 3 || int.Parse(x.NailDetail_Status) == 4)).FirstOrDefault();
            return result;
        }

        //取已入庫的機上量測編號MeasureDetail_ID
        public string GetMeasureDetailID(string MeasureMasterID)
        {
            var result = _db.MeasureDetails.OrderBy(x => x.MeasureMaster_ID.Equals(MeasureMasterID) && int.Parse(x.MeasureDetail_Status) < 3).First();
            return result.MeasureDetail_ID;
        }

        //取已出庫的機上量測編號MeasureDetail_ID
        public string GetMeasureOutDetailID(string MeasureMasterID)
        {
            var result = _db.MeasureDetails.OrderBy(x => x.MeasureMaster_ID.Equals(MeasureMasterID) && (int.Parse(x.MeasureDetail_Status) == 3 || int.Parse(x.MeasureDetail_Status) == 4)).First();
            return result.MeasureDetail_ID;
        }

        //取已入庫的延長桿編號ExtRodDetail_ID
        public string GetExtRodDetailID(string ExtRodMasterID)
        {
            var result = _db.ExtRodDetails.OrderBy(x => x.ExtRodMaster_ID.Equals(ExtRodMasterID) && int.Parse(x.ExtRodDetail_Status) < 3).First();
            return result.ExtRodDetail_ID;
        }

        //取已出庫的延長桿編號ExtRodDetail_ID
        public string GetExtRodOutDetailID(string ExtRodMasterID)
        {
            var result = _db.ExtRodDetails.OrderBy(x => x.ExtRodMaster_ID.Equals(ExtRodMasterID) && (int.Parse(x.ExtRodDetail_Status) == 3 || int.Parse(x.ExtRodDetail_Status) == 4)).First();
            return result.ExtRodDetail_ID;
        }

        //取已入庫的筒夾1編號Collet1Detail_ID
        public string GetCollet1DetailID(string Collet1MasterID)
        {
            var result = _db.Collet1Detail.OrderBy(x => x.Collet1Master_ID.Equals(Collet1MasterID) && int.Parse(x.Collet1Detail_Status) < 3).First();
            return result.Collet1Detail_ID;
        }

        //取已出庫的筒夾1編號Collet1Detail_ID
        public string GetCollet1OutDetailID(string Collet1MasterID)
        {
            var result = _db.Collet1Detail.OrderBy(x => x.Collet1Master_ID.Equals(Collet1MasterID) && (int.Parse(x.Collet1Detail_Status) == 3 || int.Parse(x.Collet1Detail_Status) == 4)).First();
            return result.Collet1Detail_ID;
        }

        //取已入庫的筒夾2編號Collet2Detail_ID
        public string GetCollet2DetailID(string Collet2MasterID)
        {
            var result = _db.Collet2Detail.OrderBy(x => x.Collet2Master_ID.Equals(Collet2MasterID) && int.Parse(x.Collet2Detail_Status) < 3).First();
            return result.Collet2Detail_ID;
        }

        //取已出庫的筒夾2編號Collet2Detail_ID
        public string GetCollet2OutDetailID(string Collet2MasterID)
        {
            var result = _db.Collet2Detail.OrderBy(x => x.Collet2Master_ID.Equals(Collet2MasterID) && (int.Parse(x.Collet2Detail_Status) == 3 || int.Parse(x.Collet2Detail_Status) == 4)).First();
            return result.Collet2Detail_ID;
        }

        //取已入庫的螺絲/刀頭編號NutDetail_ID
        public string GetNutDetailID(string NutMasterID,string KnifeMasterID)
        {
            string NutDetailIDs = "";
            if (KnifeMasterID.Contains("za0206933") || KnifeMasterID.Contains("za0206353")) //四刀具,四螺帽
            {
                var result = _db.NutDetails.OrderBy(x => x.NutMaster_ID.Equals(NutMasterID) && int.Parse(x.NutDetail_Status) < 3).Take(4).ToList();
                foreach (var i in result)
                {
                    NutDetailIDs = NutDetailIDs + ";" + i.NutDetail_ID;
                }
                return NutDetailIDs.Substring(1);
            }
            else if (KnifeMasterID.Contains("za0206513") || KnifeMasterID.Contains("za0205586")) //二刀具,二螺帽
            {
                var result = _db.NutDetails.OrderBy(x => x.NutMaster_ID.Equals(NutMasterID) && int.Parse(x.NutDetail_Status) < 3).Take(2).ToList();
                foreach (var i in result)
                {
                    NutDetailIDs = NutDetailIDs + ";" + i.NutDetail_ID;
                }
                return NutDetailIDs.Substring(1);
            }
            else
            {
                var result = _db.NutDetails.OrderBy(x => x.NutMaster_ID.Equals(NutMasterID) && int.Parse(x.NutDetail_Status) < 3).First();
                return result.NutDetail_ID;
            }

        }

        //取已出庫的螺絲/刀頭編號NutDetail_ID
        public string GetNutOutDetailID(string NutMasterID, string KnifeMasterID)
        {
            string NutDetailIDs = "";
            if (KnifeMasterID.Contains("za0206933") || KnifeMasterID.Contains("za0206353")) //四刀具,四螺帽
            {
                var result = _db.NutDetails.OrderBy(x => x.NutMaster_ID.Equals(NutMasterID) && (int.Parse(x.NutDetail_Status) == 3 || int.Parse(x.NutDetail_Status) == 4)).Take(4).ToList();
                foreach (var i in result)
                {
                    NutDetailIDs = NutDetailIDs + ";" + i.NutDetail_ID;
                }
                return NutDetailIDs.Substring(1);
            }
            else if (KnifeMasterID.Contains("za0206513") || KnifeMasterID.Contains("za0205586")) //二刀具,二螺帽
            {
                var result = _db.NutDetails.OrderBy(x => x.NutMaster_ID.Equals(NutMasterID) && (int.Parse(x.NutDetail_Status) == 3 || int.Parse(x.NutDetail_Status) == 4)).Take(2).ToList();
                foreach (var i in result)
                {
                    NutDetailIDs = NutDetailIDs + ";" + i.NutDetail_ID;
                }
                return NutDetailIDs.Substring(1);
            }
            else
            {
                var result = _db.NutDetails.OrderBy(x => x.NutMaster_ID.Equals(NutMasterID) && ( int.Parse(x.NutDetail_Status) == 3 || int.Parse(x.NutDetail_Status) == 4)).First();
                return result.NutDetail_ID;
            }

        }

        public string GetEmployName(string id)
        {
            var result = (from c in _db.Employes where c.Emp_ID == id
                          select c.Emp_Name).FirstOrDefault();
            return result;
        }

        public string GetGoodName(string id)
        {
            var result = (from c in _db.Goods
                          where c.Good_ID == id
                          select c.Good_Name).FirstOrDefault();
            return result;
        }

    }
}
