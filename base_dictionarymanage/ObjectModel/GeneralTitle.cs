using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EFWCoreLib.CoreFrame.Business;
using base_dictionarymanage.Entity;
using base_dictionarymanage.Dao;
//using WinMainUIFrame.ObjectModel.UserLogin;

namespace base_dictionarymanage.ObjectModel
{
    public class GeneralTitle : AbstractBusines
    {

        public DataTable GetDbTables()
        {
            return NewDao<GeneralDao>().GetDbTables();
        }

        public List<BaseGeneralTitle> GetGroupTitleList(int groupId)
        {
            return NewDao<GeneralDao>().GetGroupTitleList(groupId);
        }

        public List<BaseGeneralTitle> GetUserTitleList(int userId)
        {
            //if (NewObject<User>().IsAdmin(userId))
            //{
            //    return NewObject<BaseGeneralTitle>().getlist<BaseGeneralTitle>();
            //}
            //else
            //{
                return NewDao<GeneralDao>().GetUserTitleList(userId);
            //}
        }

        public void SetGroupTitle(int groupId, int[] titleIds)
        {
            NewDao<GeneralDao>().DeleteGroupTitle(groupId);
            for (int i = 0; i < titleIds.Length; i++)
            {
                NewDao<GeneralDao>().SaveGroupTitle(groupId, titleIds[i]);
            }
        }
    }
}
