using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Tool_Management.Service.Interfaces;
using Tool_Management.Service.Utils;
using Tool_Management.Service.ViewModels;
using Tool_Management.DataAccess;
using System.Web.Util;

namespace Tool_Management.Service.Services
{
    public class TM_KnifeListService : ITM_KnifeList
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        public void CreateATC(KnifeListViewModel viewModel)
        {
            DateTime CreateTime = System.DateTime.Now;
           
             var entry = new KnifeList
            {
                KnifeList_ID = viewModel.KnifeList_ID,
                ATC_ID = viewModel.ATC_ID,
                D = viewModel.D,
                CL = viewModel.CL,
                FL = viewModel.FL,
                L = viewModel.L,
                Deep = viewModel.Deep,
                SZ = viewModel.SZ,
                EZ = viewModel.EZ,
                R = viewModel.R,
                Program_No = viewModel.Program_No,
                Reserved = viewModel.Reserved,
                Way = viewModel.Way,
                Time = viewModel.Time,
                Memo = viewModel.Memo,
                KnifeList_Create_DT = CreateTime,
                KnifeList_Modify_DT = CreateTime,
                KnifeList_Create_ID = viewModel.KnifeList_Create_ID,
                KnifeList_Modify_ID = viewModel.KnifeList_Modify_ID,
        };
            _db.KnifeLists.Add(entry);
            _db.SaveChanges();

            //var delentry = new KnifeList { KnifeList_ID = viewModel.KnifeList_ID };
            //using (var transaction = _db.Database.BeginTransaction())
            //{      
            //    _db.KnifeLists.Attach(delentry);
            //    _db.KnifeLists.Remove(delentry);
            //    _db.KnifeLists.Add(entry);
            //    try
            //    {
            //        var result = _db.SaveChanges();
            //        if (result == 0)
            //        {
            //            throw new Exception();
            //        }
            //        transaction.Commit();
            //    }
            //    catch (Exception e)
            //    {
            //        transaction.Rollback();
            //    }

            //}


        }

        public void Create(vKnifeListViewModel viewModel)
        {
            DateTime CreateTime = System.DateTime.Now;

            var entry = new KnifeList
            {
                KnifeList_ID = new Common().GetKnifeListID(),
                Good_ID = viewModel.Good_ID,
                Model_ID = viewModel.Model_ID,
                WorkStation_No = viewModel.WorkStation_No,
                KnifeList_Create_DT = CreateTime,
                KnifeList_Modify_DT = CreateTime,
                KnifeList_Create_ID = viewModel.KnifeList_Create_ID,
                KnifeList_Modify_ID = viewModel.KnifeList_Modify_ID,
            };
            _db.KnifeLists.Add(entry);
            _db.SaveChanges();

        }

        public void DeleteKnifeList(string id)
        {
            var entry = new KnifeList { KnifeList_ID = id };
            _db.KnifeLists.Attach(entry);
            _db.KnifeLists.Remove(entry);
            _db.SaveChanges();
        }

        public void DeleteATC(string id,string atc_id)
        {
            var entry = new KnifeList { KnifeList_ID = id,ATC_ID = atc_id  };
            _db.KnifeLists.Attach(entry);
            _db.KnifeLists.Remove(entry);
            _db.SaveChanges();
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.vKnifeLists 
                        select new vKnifeListViewModel
                        {
                            KnifeList_ID = c.KnifeList_ID,
                            Model_ID = c.Model_ID,
                            Model_Name = c.Model_Name,
                            Good_ID = c.Good_ID,
                            Good_Name = c.Good_Name,
                            WorkStation_No = c.WorkStation_No,
                            KnifeList_Create_DT = c.KnifeList_Create_DT,
                            KnifeList_Modify_DT =  c.KnifeList_Modify_DT ,
                            KnifeList_Create_Name = c.KnifeList_Create_Name,
                            KnifeList_Modify_Name = c.KnifeList_Modify_Name
                        }).ToDataSourceResult(request);


            return result;
        }


        public DataSourceResult GridATC(DataSourceRequest request,string id)
        {
            
            if (string.IsNullOrEmpty(id) == false)
            {
               var result = (from c in _db.KnifeLists
                          where c.KnifeList_ID == id && c.ATC_ID != null
                          select new KnifeListViewModel
                          {
                              KnifeList_ID = c.KnifeList_ID,
                              ATC_ID = c.ATC_ID,
                              KnifeDetail_ID = c.KnifeDetail_ID,
                              HiltDetail_ID = c.HiltDetail_ID,
                              NailDetail_ID = c.NailDetail_ID,
                              ExtRodDetail_ID = string.IsNullOrEmpty(c.ExtRodDetail_ID) ? "" : c.ExtRodDetail_ID,
                              Collet1Detail_ID = string.IsNullOrEmpty(c.Collet1Detail_ID) ? "" : c.Collet1Detail_ID,
                              Collet2Detail_ID = string.IsNullOrEmpty(c.Collet2Detail_ID) ? "" : c.Collet2Detail_ID,
                              D = c.D,
                              L = c.L,
                              CL = c.CL,
                              FL = c.FL,
                              R = c.R,
                              SZ = c.SZ,
                              EZ = c.EZ,
                              Deep = c.Deep,
                              Memo = c.Memo,
                              Reserved = c.Reserved,
                              Program_No = c.Program_No,
                              Time = c.Time,
                              Way = c.Way
                          });
                if (result.Count() > 0)
                    return result.OrderBy(x => x.ATC_ID).ToDataSourceResult(request);
                else
                    return result.ToDataSourceResult(request);
            }
            else
            {
               
                var result = (from c in _db.KnifeLists
                              where c.ATC_ID != null
                              select new KnifeListViewModel
                              {
                                  KnifeList_ID = c.KnifeList_ID,
                                  ATC_ID = c.ATC_ID,
                                  KnifeDetail_ID = c.KnifeDetail_ID,
                                  HiltDetail_ID = c.HiltDetail_ID,
                                  NailDetail_ID = c.NailDetail_ID,
                                  ExtRodDetail_ID = string.IsNullOrEmpty(c.ExtRodDetail_ID) ? "" : c.ExtRodDetail_ID,
                                  Collet1Detail_ID = string.IsNullOrEmpty(c.Collet1Detail_ID) ? "" : c.Collet1Detail_ID,
                                  Collet2Detail_ID = string.IsNullOrEmpty(c.Collet2Detail_ID) ? "" : c.Collet2Detail_ID,
                                  D = c.D,
                                  L = c.L,
                                  CL = c.CL,
                                  FL = c.FL,
                                  R = c.R,
                                  SZ = c.SZ,
                                  EZ = c.EZ,
                                  Deep = c.Deep,
                                  Memo = c.Memo,
                                  Reserved = c.Reserved,
                                  Program_No = c.Program_No,
                                  Time = c.Time,
                                  Way = c.Way
                              });
                if (result.Count()>0)
                    return result.OrderBy(x => x.ATC_ID).ToDataSourceResult(request);
                else
                    return result.ToDataSourceResult(request);
            }
            
        }

        public void UpdateKnifeList(vKnifeListViewModel viewModel)
        {
            var q = from p in _db.KnifeLists
                    where p.KnifeList_ID == viewModel.KnifeList_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.Model_ID = viewModel.Model_ID;
                    p.Good_ID = viewModel.Good_ID;
                    p.WorkStation_No = viewModel.WorkStation_No;
                    p.KnifeList_Modify_DT = System.DateTime.Now;
                    p.KnifeList_Modify_ID = viewModel.KnifeList_Modify_ID;
                }
                _db.SaveChanges();
            }

        }

        public void UpdateATC(KnifeListViewModel viewModel)
        {
            var q = from p in _db.KnifeLists
                    where p.KnifeList_ID == viewModel.KnifeList_ID  && p.ATC_ID ==viewModel.ATC_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.KnifeDetail_ID = new Common().GetKnifeDetailID(viewModel.KnifeMaster_ID);
                    p.HiltDetail_ID = new Common().GetHiltDetailID(viewModel.HiltMaster_ID);
                    p.NailDetail_ID = new Common().GetNailDetailID(viewModel.NailDetail_ID);
                    p.ExtRodDetail_ID = string.IsNullOrEmpty(viewModel.ExtRodMaster_ID) ? "" : new Common().GetExtRodDetailID(viewModel.ExtRodMaster_ID);
                    p.Collet1Detail_ID = string.IsNullOrEmpty(viewModel.Collet1Master_ID) ? "" : new Common().GetCollet1DetailID(viewModel.Collet1Master_ID);
                    p.Collet2Detail_ID = string.IsNullOrEmpty(viewModel.Collet2Master_ID) ? "" : new Common().GetCollet2DetailID(viewModel.Collet2Master_ID);
                    p.NutDetail_ID = string.IsNullOrEmpty(viewModel.NutMaster_ID) ? "" : new Common().GetNutDetailID(viewModel.NutMaster_ID, viewModel.KnifeMaster_ID);
                    p.D = viewModel.D;
                    p.CL = viewModel.CL;
                    p.FL = viewModel.FL;
                    p.L = viewModel.L;
                    p.Deep = viewModel.Deep;
                    p.SZ = viewModel.SZ;
                    p.EZ = viewModel.EZ;
                    p.R = viewModel.R;
                    p.Program_No = viewModel.Program_No;
                    p.Reserved = viewModel.Reserved;
                    p.Way = viewModel.Way;
                    p.Time = viewModel.Time;
                    p.Memo = viewModel.Memo;
                    p.KnifeList_Modify_DT = System.DateTime.Now;
                    p.KnifeList_Modify_ID = viewModel.KnifeList_Modify_ID;
                }
                _db.SaveChanges();
            }

        }

        vKnifeListViewModel ITM_KnifeList.Get(string id)
        {
            var result = (from c in _db.vKnifeLists
                          where c.KnifeList_ID == id
                          select new vKnifeListViewModel
                          {
                                KnifeList_ID = c.KnifeList_ID,
                                Model_ID = c.Model_ID,
                                Model_Name = c.Model_Name,
                                Good_ID = c.Good_ID,
                                Good_Name = c.Good_Name,
                                WorkStation_No = c.WorkStation_No,
                                 KnifeList_Create_DT = c.KnifeList_Create_DT,
                                  KnifeList_Create_ID = c.KnifeList_Create_ID,
                                  KnifeList_Create_Name = c.KnifeList_Create_Name,
                                   KnifeList_Modify_DT = c.KnifeList_Modify_DT,
                                   KnifeList_Modify_ID = c.KnifeList_Modify_ID,
                                   KnifeList_Modify_Name = c.KnifeList_Modify_Name
                                
                          }).FirstOrDefault();

            return result;
        }

        KnifeListViewModel ITM_KnifeList.GetATC(string id,string atc_id)
        {
            var result = (from c in _db.KnifeLists
                          where c.KnifeList_ID == id && c.ATC_ID == atc_id
                          select new KnifeListViewModel
                          {
                              KnifeList_ID = c.KnifeList_ID,
                              Model_ID = c.Model_ID,                            
                              Good_ID = c.Good_ID,
                              WorkStation_No = c.WorkStation_No,
                              KnifeList_Create_DT = c.KnifeList_Create_DT,
                              KnifeList_Create_ID = c.KnifeList_Create_ID,
                              KnifeList_Modify_DT = c.KnifeList_Modify_DT,
                              KnifeList_Modify_ID = c.KnifeList_Modify_ID,
                              ATC_ID = c.ATC_ID,
                              KnifeDetail_ID  = c.KnifeDetail_ID,
                              KnifeMaster_ID = c.KnifeDetail_ID.Split('-')[0],
                              HiltDetail_ID = c.HiltDetail_ID,
                              HiltMaster_ID = c.HiltDetail_ID.Split('-')[0],
                              NailDetail_ID  = c.NailDetail_ID,
                              NailMaster_ID = c.NailDetail_ID.Split('-')[0],
                              ExtRodDetail_ID = c.ExtRodDetail_ID,
                              ExtRodMaster_ID = string.IsNullOrEmpty(c.ExtRodDetail_ID)?"":c.ExtRodDetail_ID.Split('-')[0],
                              Collet1Detail_ID = c.Collet1Detail_ID,
                              Collet1Master_ID = string.IsNullOrEmpty(c.Collet1Detail_ID)?"":c.Collet1Detail_ID.Split('-')[0],
                              Collet2Detail_ID = c.Collet2Detail_ID,
                              Collet2Master_ID = string.IsNullOrEmpty(c.Collet2Detail_ID)?"":c.Collet2Detail_ID.Split('-')[0],
                              NutDetail_ID  =  c.NutDetail_ID,
                              NutMaster_ID = string.IsNullOrEmpty(c.NutDetail_ID)?"":c.NutDetail_ID.Split('-')[0],
                              Program_No = c.Program_No,
                               CL = c.CL,
                                D = c.D,
                                 Deep = c.Deep,
                                  EZ = c.EZ,
                                   FL = c.FL,
                                    L = c.L,
                                     Memo = c.Memo,
                                      R = c.R,
                                       Reserved = c.Reserved,
                                        SZ = c.SZ,
                                         Time = c.Time,
                                          Way = c.Way  

                          }).FirstOrDefault();

            return result;
        }

        public IList<vKnifeListViewModel> GetKnifeList()
        {
            var result = _db.vKnifeLists.Select(s => new vKnifeListViewModel()
            {
                 Good_Name = s.Good_Name,
                 Model_ID = s.Model_ID,
                 Model_Name = s.Model_Name,
                 WorkStation_No = s.WorkStation_No,
                 KnifeList_ID = s.KnifeList_ID
            }).ToList();

            return result;
        }
    }


}
