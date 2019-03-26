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
    public class TM_InFormService : ITM_InForm
    {
        private ToolManagementEntities _db = new ToolManagementEntities();

        void ITM_InForm.KnifeInFormCreate(KnifeInFormViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            for (var i = 0; i < viewModel.InForm_Quality; i++)
            {
                //新增刀具入庫單
                KnifeDetail KnifeDetail = new Common().GetKnifeOutDetailID(viewModel.Master_ID);
                var entry = new Inform
                {
                    Inform_ID = viewModel.InForm_ID,
                    DetailID_Type = "Knife",
                    Detail_Status = viewModel.DetailID_Status,
                    In_DT = viewModel.In_DT,
                    In_EmpID = viewModel.In_EmpID,
                    Master_ID = KnifeDetail.KnifeDetail_ID.Split('-')[0],
                    Confirm_EmpID = viewModel.Confirm_EmpID,
                    Detail_ID = KnifeDetail.KnifeDetail_ID,                    
                    Inform_Create_DT = CreateTime,
                    Inform_Modify_DT = CreateTime,
                    Inform_Create_ID = viewModel.InForm_Create_ID,
                    Inform_Modify_ID = viewModel.InForm_Modify_ID
                };

                _db.Informs.Add(entry);
                _db.SaveChanges();

                //寫入庫存表
                // 1:正常入庫 = 1,維修入庫 = 2,
                if (entry.Detail_Status == "1" || entry.Detail_Status == "2")
                {
                    StockDetailViewModel svm = new StockDetailViewModel()
                    {
                        Detail_ID = entry.Detail_ID,
                        Bound_Type = 1,  // 1:入庫 2:出庫 3:報廢
                        MasterID_Type = entry.DetailID_Type,
                        Master_ID = viewModel.Master_ID,
                        Memo = entry.Inform_ID,
                        StockDetail_Create_ID = viewModel.In_EmpID,
                        StockDetail_Create_Name = new Common().GetEmployName(viewModel.In_EmpID),
                        StockDetail_Create_DT = DateTime.Parse(viewModel.In_DT)
                    };
                    ITM_Stock svc = new TM_StockService();
                    svc.Create(svm);
                }
                // 9:報廢
                else if (entry.Detail_Status == "9")
                {
                    StockDetailViewModel svm = new StockDetailViewModel()
                    {
                        Detail_ID = entry.Detail_ID,
                        Bound_Type = 3,  // 1:入庫 2:出庫 3:報廢
                        MasterID_Type = entry.DetailID_Type,
                        Master_ID = viewModel.Master_ID,
                        Memo = entry.Inform_ID,
                        StockDetail_Create_ID = viewModel.In_EmpID,
                        StockDetail_Create_Name = new Common().GetEmployName(viewModel.In_EmpID),
                        StockDetail_Create_DT = DateTime.Parse(viewModel.In_DT)
                    };
                    ITM_Stock svc = new TM_StockService();
                    svc.Create(svm);
                }


            }
        }

        void ITM_InForm.KnifeInFormDelete(KnifeInFormViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //刪除入庫單
            var data = (from p in _db.Informs
                        where p.Inform_ID == viewModel.InForm_ID && p.Detail_ID.Contains(viewModel.Master_ID)
                        select new InFormViewModel
                        {
                            Detail_ID = p.Detail_ID,
                            InForm_ID = p.Inform_ID,
                            In_DT = p.In_DT
                        }).ToList();

            for (int i = 0; i < data.Count(); i++)
            {
                var entity = new Inform();
                entity.Inform_ID = data[i].InForm_ID;
                entity.Detail_ID = data[i].Detail_ID;
                entity.In_DT = data[i].In_DT;
                _db.Informs.Attach(entity);
                _db.Informs.Remove(entity);
                _db.SaveChanges();
            }

            //刪除庫存表
            var q = (from v in _db.StockDetails
                     where v.Memo.Contains(viewModel.InForm_ID) && v.Detail_ID.Contains(viewModel.Master_ID)
                     select                      
                         v.Sno
                     ).ToList();
            for (int i = 0; i < q.Count(); i++)
            {
                var entity = new StockDetail();
                entity.Sno = q[i];
                _db.StockDetails.Attach(entity);
                _db.StockDetails.Remove(entity);
                _db.SaveChanges();
            }
          

        }

        public DataSourceResult KnifeInFormGridSearch(DataSourceRequest request,string InForm_ID)
        {
            
            var result = (from c in _db.vKnifeInForms where c.Inform_ID.EndsWith(InForm_ID)
                          join e1 in _db.Employes on c.In_EmpID equals e1.Emp_ID
                          join e2 in _db.Employes on c.Confirm_EmpID equals e2.Emp_ID
                          select new KnifeInFormViewModel
                          {

                              Master_ID = c.Master_ID,
                              Knife_Name = c.Knife_Name,
                              Confirm_EmpID = c.Confirm_EmpID,
                              DetailID_Status  = c.DetailID_Status,
                              InForm_ID = c.Inform_ID,
                              InForm_Quality = c.InForm_Quality==null?0: (long)c.InForm_Quality,
                              DetailID_UseTime =c.DetailID_UseTime,
                              Unit = c.unit,
                              In_EmpID = c.In_EmpID
                          }).ToDataSourceResult(request);


            return result;
        }

        //入庫作業不在異動,更新刀具狀態
        void ITM_InForm.KnifeStatusSave(string InForm_ID)
        {
            var informs = (from c in _db.Informs
                           where c.Inform_ID == InForm_ID
                           select new InFormViewModel
                           {
                               DetailID_Status = c.Detail_Status,
                               Detail_ID = c.Detail_ID,
                               In_DT = c.In_DT,
                               In_EmpID = c.In_EmpID
                           }).ToList();
            for (var i = 0; i < informs.Count(); i++)
            {
                //更新刀具狀態為入庫
                KnifeDetailViewModel kdvm = new KnifeDetailViewModel()
                {
                    IsNewKnife = "N",
                    KnifeDetail_ID = informs[i].Detail_ID,
                    KnifeDetail_Status = informs[i].DetailID_Status,
                    KnifeDetail_Modify_ID = informs[i].In_EmpID,
                    KnifeDetail_Modify_DT = DateTime.Now
                };
                ITM_KnifeDetail KnifeDetailSvc = new TM_KnifeDetailService();
                KnifeDetailSvc.Update(kdvm);
            }
        }


        void ITM_InForm.HiltInFormCreate(HiltInFormViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            for (var i = 0; i < viewModel.InForm_Quality; i++)
            {
                //新增刀把入庫單
                HiltDetail Detail = new Common().GetHiltOutDetailID(viewModel.Master_ID);
                var entry = new Inform
                {
                    Inform_ID = viewModel.InForm_ID,
                    DetailID_Type = "Hilt",
                    Detail_Status = viewModel.DetailID_Status,
                    In_DT = viewModel.In_DT,
                    In_EmpID = viewModel.In_EmpID,
                    Master_ID = HiltDetail.HiltDetail_ID.Split('-')[0],
                    Confirm_EmpID = viewModel.Confirm_EmpID,
                    Detail_ID = HiltDetail.HiltDetail_ID,
                    Inform_Create_DT = CreateTime,
                    Inform_Modify_DT = CreateTime,
                    Inform_Create_ID = viewModel.InForm_Create_ID,
                    Inform_Modify_ID = viewModel.InForm_Modify_ID
                };

                _db.Informs.Add(entry);
                _db.SaveChanges();

                //寫入庫存表
                // 1:正常入庫 = 1,維修入庫 = 2,
                if (entry.Detail_Status == "1" || entry.Detail_Status == "2")
                {
                    StockDetailViewModel svm = new StockDetailViewModel()
                    {
                        Detail_ID = entry.Detail_ID,
                        Bound_Type = 1,  // 1:入庫 2:出庫 3:報廢
                        MasterID_Type = entry.DetailID_Type,
                        Master_ID = viewModel.Master_ID,
                        Memo = entry.Inform_ID,
                        StockDetail_Create_ID = viewModel.In_EmpID,
                        StockDetail_Create_Name = new Common().GetEmployName(viewModel.In_EmpID),
                        StockDetail_Create_DT = DateTime.Parse(viewModel.In_DT)
                    };
                    ITM_Stock svc = new TM_StockService();
                    svc.Create(svm);
                }
                // 9:報廢
                else if (entry.Detail_Status == "9")
                {
                    StockDetailViewModel svm = new StockDetailViewModel()
                    {
                        Detail_ID = entry.Detail_ID,
                        Bound_Type = 3,  // 1:入庫 2:出庫 3:報廢
                        MasterID_Type = entry.DetailID_Type,
                        Master_ID = viewModel.Master_ID,
                        Memo = entry.Inform_ID,
                        StockDetail_Create_ID = viewModel.In_EmpID,
                        StockDetail_Create_Name = new Common().GetEmployName(viewModel.In_EmpID),
                        StockDetail_Create_DT = DateTime.Parse(viewModel.In_DT)
                    };
                    ITM_Stock svc = new TM_StockService();
                    svc.Create(svm);
                }


            }
        }

        void ITM_InForm.HiltInFormDelete(HiltInFormViewModel viewModel)
        {
            DateTime CreateTime = DateTime.Now;

            //刪除入庫單
            var data = (from p in _db.Informs
                        where p.Inform_ID == viewModel.InForm_ID && p.Detail_ID.Contains(viewModel.Master_ID)
                        select new InFormViewModel
                        {
                            Detail_ID = p.Detail_ID,
                            InForm_ID = p.Inform_ID,
                            In_DT = p.In_DT
                        }).ToList();

            for (int i = 0; i < data.Count(); i++)
            {
                var entity = new Inform();
                entity.Inform_ID = data[i].InForm_ID;
                entity.Detail_ID = data[i].Detail_ID;
                entity.In_DT = data[i].In_DT;
                _db.Informs.Attach(entity);
                _db.Informs.Remove(entity);
                _db.SaveChanges();
            }

            //刪除庫存表
            var q = (from v in _db.StockDetails
                     where v.Memo.Contains(viewModel.InForm_ID) && v.Detail_ID.Contains(viewModel.Master_ID)
                     select
                         v.Sno
                     ).ToList();
            for (int i = 0; i < q.Count(); i++)
            {
                var entity = new StockDetail();
                entity.Sno = q[i];
                _db.StockDetails.Attach(entity);
                _db.StockDetails.Remove(entity);
                _db.SaveChanges();
            }


        }

        public DataSourceResult HiltInFormGridSearch(DataSourceRequest request, string InForm_ID)
        {

            var result = (from c in _db.vHiltInForms
                          where c.Inform_ID.EndsWith(InForm_ID)
                          join e1 in _db.Employes on c.In_EmpID equals e1.Emp_ID
                          join e2 in _db.Employes on c.Confirm_EmpID equals e2.Emp_ID
                          select new HiltInFormViewModel
                          {

                              Master_ID = c.Master_ID,
                              Hilt_Name = c.Hilt_Name,
                              Confirm_EmpID = c.Confirm_EmpID,
                              DetailID_Status = c.DetailID_Status,
                              InForm_ID = c.Inform_ID,
                              InForm_Quality = c.InForm_Quality == null ? 0 : (long)c.InForm_Quality,
                              DetailID_UseTime = c.DetailID_UseTime,
                              Unit = c.unit,
                              In_EmpID = c.In_EmpID
                          }).ToDataSourceResult(request);


            return result;
        }

        //入庫作業不在異動,更新刀把狀態
        void ITM_InForm.HiltStatusSave(string InForm_ID)
        {
            var informs = (from c in _db.Informs
                           where c.Inform_ID == InForm_ID
                           select new InFormViewModel
                           {
                               DetailID_Status = c.Detail_Status,
                               Detail_ID = c.Detail_ID,
                               In_DT = c.In_DT,
                               In_EmpID = c.In_EmpID
                           }).ToList();
            for (var i = 0; i < informs.Count(); i++)
            {
                //更新刀把狀態為入庫
                HiltDetailViewModel kdvm = new HiltDetailViewModel()
                {
                    IsNewHilt = "N",
                    HiltDetail_ID = informs[i].Detail_ID,
                    HiltDetail_Status = informs[i].DetailID_Status,
                    HiltDetail_Modify_ID = informs[i].In_EmpID,
                    HiltDetail_Modify_DT = DateTime.Now
                };
                ITM_HiltDetail HiltDetailSvc = new TM_HiltDetailService();
                HiltDetailSvc.Update(kdvm);
            }
        }
    }
 }

