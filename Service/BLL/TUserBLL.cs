﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL;
using Model;

namespace BLL
{
    public class TUserBLL : IGridData, IUploadData
    {

        private TUserDAL dal;

        public TUserBLL()
        {
            this.dal = new TUserDAL();
        }

        public TUserBLL(string dbKey)
        {
            this.dal = new TUserDAL(dbKey);
        }

        #region CommonMethods

        public List<TUserModel> GetModelList()
        {
            return this.dal.GetModelList();
        }

        public List<TUserModel> GetModelList(Expression<Func<TUserModel, bool>> predicate)
        {
            return this.dal.GetModelList(predicate);
        }

        public TUserModel GetModel(int id)
        {
            return this.dal.GetModel(id);
        }

        public TUserModel GetModel(Expression<Func<TUserModel, bool>> predicate)
        {
            return this.dal.GetModel(predicate);
        }

        public TUserModel Insert(TUserModel model)
        {
            return this.dal.Insert(model);
        }

        public int Update(TUserModel model)
        {
            return this.dal.Update(model);
        }

        public int Delete(TUserModel model)
        {
            return this.dal.Delete(model);
        }

        #endregion

        public void ResetIndex()
        {
            this.dal.ResetIndex();
        }

        public object GetGridData()
        {
            return this.dal.GetGridData();
        }


        public bool IsBasic
        {
            get { return true; }
        }

        public int ProcessInsertData(int areaCode, string targetDbName)
        {
            try
            {
                var sList = new TUserDAL(areaCode.ToString()).GetModelList(c => c.sysFlag == 0).ToList();
                sList.ForEach(s =>
                {
                    s.areaCode = areaCode;
                    s.areaId = s.ID;
                });
                var dal = new TUserDAL(targetDbName);
                var odal = new TUserDAL(areaCode.ToString());
                foreach (var s in sList)
                {
                    dal.Insert(s);
                    s.ID = s.areaId;
                    s.sysFlag = 2;
                    odal.Update(s);
                }
                return sList.Count;
            }
            catch
            {
                return -1;
            }
        }

        public int ProcessUpdateData(int areaCode, string targetDbName)
        {
            try
            {
                var sdal = new TUserDAL(areaCode.ToString());
                var tdal = new TUserDAL(targetDbName);
                var sList = sdal.GetModelList(p => p.sysFlag == 1);
                foreach (var s in sList)
                {
                    var id = s.ID;
                    var nData = tdal.GetModelList(p => p.areaCode == areaCode && p.areaId == s.ID).FirstOrDefault();
                    if (nData == null)
                    {
                        s.areaCode = areaCode;
                        s.areaId = s.ID;
                        tdal.Insert(s);
                        s.ID = s.areaId;
                        s.sysFlag = 2;
                        sdal.Update(s);
                    }
                    else
                    {
                        var data = s;
                        data.ID = nData.ID;
                        data.areaCode = nData.areaCode;
                        data.areaId = nData.areaId;
                        tdal.Update(data);
                        s.sysFlag = 2;
                        s.ID = id;
                        sdal.Update(s);
                    }
                }
                return sList.Count;
            }
            catch
            {
                return -1;
            }
        }

        public int ProcessDeleteData(int areaCode, string targetDbName)
        {
            return 0;
        }
    }
}
