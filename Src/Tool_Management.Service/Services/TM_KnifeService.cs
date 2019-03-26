using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Tool_Management.DataAccess;
using Tool_Management.Service.Interfaces;
using Tool_Management.Service.ViewModels;
using Tool_Management.Service.Utils;
using Kendo.Mvc.Extensions;

namespace Tool_Management.Service.Services
{
    public class TM_KnifeMasterService : ITM_KnifeMaster
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_KnifeMaster.Create(KnifeMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            var entry = new KnifeMaster
            {
                KnifeMaster_ID = viewModel.KnifeMaster_ID,
                Knife_Brand = viewModel.Knife_Brand,
                Knife_Name = viewModel.Knife_Name,
                Knife_CabinID = viewModel.Knife_CabinID,
                Knife_Spec = viewModel.Knife_Spec,
                Knife_Quality = viewModel.Knife_Quality,
                Knife_Kind = viewModel.Knife_Kind,
                Knife_Model = viewModel.Knife_Model,
                KnifeMaster_Create_DT = CreateTime,
                KnifeMaster_Modify_DT = CreateTime,
                KnifeMaster_Create_ID = viewModel.KnifeMaster_Create_ID,
                KnifeMaster_Modify_ID = viewModel.KnifeMaster_Modify_ID

            };
            _db.KnifeMasters.Add(entry);
            _db.SaveChanges();

            //insert KnifeDetail
            int no;
            var result = _db.KnifeDetails.OrderByDescending(x => x.KnifeDetail_ID.Contains(viewModel.KnifeMaster_ID)).FirstOrDefault();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.KnifeDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Knife_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new KnifeDetail
                {
                    KnifeDetail_ID = viewModel.KnifeMaster_ID + "-" + sn,
                    KnifeMaster_ID = viewModel.KnifeMaster_ID,
                    IsNewKnife = "Y",
                    NewEnter_DT = CreateTime,
                    KnifeDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    KnifeDetail_Create_DT = CreateTime,
                    KnifeDetail_Modify_DT = CreateTime,
                    KnifeDetail_Create_ID = viewModel.KnifeMaster_Create_ID,
                    KnifeDetail_Modify_ID = viewModel.KnifeMaster_Modify_ID
                };
                _db.KnifeDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_KnifeMaster.Update(KnifeMasterViewModel viewModel)
        {
            
            var q = from p in _db.KnifeMasters
                    where p.KnifeMaster_ID == viewModel.KnifeMaster_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.Knife_Name = viewModel.Knife_Name;
                    p.Knife_CabinID = viewModel.Knife_CabinID;
                    p.Knife_Spec = viewModel.Knife_Spec;
                    p.Knife_Brand = viewModel.Knife_Brand;                    
                    p.KnifeMaster_Modify_DT = System.DateTime.Now;
                    p.KnifeMaster_Modify_ID = viewModel.KnifeMaster_Modify_ID;
                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.KnifeMasters
                        join e1 in _db.Employes on c.KnifeMaster_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.KnifeMaster_Modify_ID equals e2.Emp_ID
                        select new KnifeMasterViewModel
                        {

                            KnifeMaster_ID = c.KnifeMaster_ID,
                            Knife_Brand = c.Knife_Brand,
                            Knife_Name = c.Knife_Name,
                            Knife_Spec = c.Knife_Spec,
                            Knife_CabinID = c.Knife_CabinID,
                            
                            KnifeMaster_Create_DT = c.KnifeMaster_Create_DT,
                            KnifeMaster_Modify_DT = c.KnifeMaster_Modify_DT,
                            KnifeMaster_Create_Name =e1.Emp_Name,
                            KnifeMaster_Create_ID = c.KnifeMaster_Create_ID,
                            KnifeMaster_Modify_Name = e2.Emp_Name,
                            KnifeMaster_Modify_ID = c.KnifeMaster_Modify_ID
                        }).ToDataSourceResult(request);


            return result;
        }

        KnifeMasterViewModel ITM_KnifeMaster.Get(string id)
        {
            var result = (from c in _db.KnifeMasters
                          join e1 in _db.Employes on c.KnifeMaster_Create_ID equals e1.Emp_ID
                          join e2 in _db.Employes on c.KnifeMaster_Modify_ID equals e2.Emp_ID
                          where c.KnifeMaster_ID == id
                          select new KnifeMasterViewModel
                          {
                              KnifeMaster_ID = c.KnifeMaster_ID,
                              Knife_Brand = c.Knife_Brand,
                              Knife_CabinID = c.Knife_CabinID,
                              Knife_Kind = c.Knife_Kind,
                              Knife_Model = c.Knife_Model,
                              Knife_Name = c.Knife_Name,
                              Knife_Quality = c.Knife_Quality,
                              Knife_Spec = c.Knife_Spec,
                              KnifeMaster_Create_DT = c.KnifeMaster_Create_DT,
                              KnifeMaster_Create_ID = c.KnifeMaster_Create_ID,
                              KnifeMaster_Create_Name =e1.Emp_Name,
                              KnifeMaster_Modify_DT = c.KnifeMaster_Modify_DT,
                              KnifeMaster_Modify_ID = c.KnifeMaster_Modify_ID,
                              KnifeMaster_Modify_Name = e2.Emp_Name

                          }).FirstOrDefault();

            return result;
        }

    }

    public class TM_KnifeDetailService : ITM_KnifeDetail
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_KnifeDetail.Create(KnifeMasterViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //insert KnifeDetail
            int no;
            var result = _db.KnifeDetails.OrderByDescending(x => x.KnifeDetail_ID.Contains(viewModel.KnifeMaster_ID)).First();
            if (result == null)
                no = 1;
            else
                no = int.Parse(result.KnifeDetail_ID.Split('-')[1]) + 1;

            for (int i = 0; i < viewModel.Knife_Quality; i++)
            {
                string sn = "000000" + (no + i).ToString();
                sn = sn.Substring(sn.Length - 6);
                var k = new KnifeDetail
                {
                    KnifeDetail_ID = viewModel.KnifeMaster_ID + "-" + sn,
                    KnifeMaster_ID = viewModel.KnifeMaster_ID,
                    IsNewKnife = "Y",
                    NewEnter_DT = CreateTime,
                    KnifeDetail_Status = ((int)SysCode.Status.正常入庫).ToString(),
                    KnifeDetail_Create_DT = CreateTime,
                    KnifeDetail_Modify_DT = CreateTime,
                    KnifeDetail_Create_ID = viewModel.KnifeMaster_Create_ID,
                    KnifeDetail_Modify_ID = viewModel.KnifeMaster_Modify_ID
                };
                _db.KnifeDetails.Add(k);
                _db.SaveChanges();
            }
        }

        void ITM_KnifeDetail.Update(KnifeDetailViewModel viewModel)
        {

            var q = from p in _db.KnifeDetails
                    where p.KnifeDetail_ID == viewModel.KnifeDetail_ID
                    select p;
            if (q.FirstOrDefault() != null)
            {
                foreach (var p in q)
                {
                    p.IsNewKnife = viewModel.IsNewKnife;
                    p.KnifeDetail_Status = viewModel.KnifeDetail_Status;
                    p.KnifeDetail_Modify_ID = viewModel.KnifeDetail_Modify_ID;
                    p.KnifeDetail_Modify_DT = viewModel.KnifeDetail_Modify_DT;

                }
                _db.SaveChanges();
            }
        }

        public DataSourceResult GridSearch(DataSourceRequest request)
        {

            var result = (from c in _db.KnifeDetails
                        join e1 in _db.Employes on c.KnifeDetail_Create_ID equals e1.Emp_ID
                        join e2 in _db.Employes on c.KnifeDetail_Modify_ID equals e2.Emp_ID
                        select new KnifeDetailViewModel
                        {

                            KnifeDetail_ID = c.KnifeDetail_ID,
                            KnifeDetail_Status = c.KnifeDetail_Status,
                            IsNewKnife = c.IsNewKnife,
                            NewEnter_DT = c.NewEnter_DT,
                             
                            KnifeDetail_Create_DT = c.KnifeDetail_Create_DT,
                            KnifeDetail_Modify_DT = c.KnifeDetail_Modify_DT,
                            KnifeDetail_Create_Name = e1.Emp_Name,
                            KnifeDetail_Create_ID = c.KnifeDetail_Create_ID,
                            KnifeDetail_Modify_Name = e2.Emp_Name,
                            KnifeDetail_Modify_ID = c.KnifeDetail_Modify_ID
                        }).ToDataSourceResult(request);

            return result;
        }

    }


}
