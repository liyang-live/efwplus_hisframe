using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EFWCoreLib.CoreFrame.Business;
using base_reportmanage.Entity;
using base_reportmanage.Dao;
//using WinMainUIFrame.ObjectModel.UserLogin;

namespace base_reportmanage.ObjectModel
{
    public class ReportTitle : AbstractBusines
    {
        public DataTable GetDbProcedures()
        {
            return NewDao<ReportDao>().GetDbProcedures();
        }

        public List<BaseReportTitle> GetGroupTitleList(int groupId)
        {
            return NewDao<ReportDao>().GetGroupTitleList(groupId);
        }

        public List<BaseReportTitle> GetUserTitleList(int userId)
        {
            //if (NewObject<User>().IsAdmin(userId))
            //{
            //    return NewObject<BaseReportTitle>().getlist<BaseReportTitle>();
            //}
            //else
            //{
                return NewDao<ReportDao>().GetUserTitleList(userId);
            //}
        }

        public void SetGroupTitle(int groupId, int[] titleIds)
        {
            NewDao<ReportDao>().DeleteGroupTitle(groupId);
            for (int i = 0; i < titleIds.Length; i++)
            {
                NewDao<ReportDao>().SaveGroupTitle(groupId, titleIds[i]);
            }
        }
    }
}
