using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.CoreFrame.Business;
using base_businessremind.Entity;

namespace base_businessremind.Dao
{
    [Serializable]
    public class MessageDao : AbstractDao
    {

        public List<BaseMessage> GetNotReadMessages(int userId, int deptId, int workId)
        {
            string strsql = @"select * from BaseMessage where (Limittime>getdate()) and MessageType in (
																		select Code from BaseMessageType a where  (select count(1) from BaseGroupUser  where GroupId in (a.ReceiveGroup) and userId={0})>0
																		)
                                and (id not in (select messageid from BaseMessageRead where userid={0})) 
                                and (ReceiveWork={2} or ReceiveWork=0)
                                and (ReceiveDept={1} or ReceiveDept=0)
                                and (ReceiveUser={0} or ReceiveUser=0)";
            strsql = string.Format(strsql, userId, deptId, workId);

            DataTable dt = oleDb.GetDataTable(strsql);
            if (dt.Rows.Count > 0)
                return ConvertExtend.ToList<BaseMessage>(dt, oleDb,_container,_cache, _pluginName,null);
            else
                return new List<BaseMessage>();
        }

        public List<BaseMessage> GetIsReadMessages(int userId, DateTime date)
        {
            string strsql = @"select * from BaseMessage where (id in (select messageid from BaseMessageRead where userid={0} and ReadTime='{1}'))";
            strsql = string.Format(strsql, userId,date.Date);

            DataTable dt = oleDb.GetDataTable(strsql);
            if (dt.Rows.Count > 0)
                return ConvertExtend.ToList<BaseMessage>(dt, oleDb,_container,_cache,_pluginName, null);
            else
                return new List<BaseMessage>();
        }

        public List<BaseMessage> GetSendMessages(int userId, DateTime date)
        {
            string strsql = @"select * from BaseMessage where SendUser={0} and SendTime='{1}'";
            strsql = string.Format(strsql, userId,date.Date);

            DataTable dt = oleDb.GetDataTable(strsql);
            if (dt.Rows.Count > 0)
                return ConvertExtend.ToList<BaseMessage>(dt, oleDb, _container,_cache,_pluginName, null);
            else
                return new List<BaseMessage>();
        }

        public string GetLimitTime(string typecode)
        {
            string strsql = @"select Limittime from BaseMessageType where Code='"+typecode+"'";
            return oleDb.GetDataResult(strsql).ToString();
        }

        public void MessageRead(int messageId, int userId)
        {
            string strsql = "select count(*) from BaseMessageRead where messageid={0} and userid={1}";
            strsql = string.Format(strsql, messageId, userId);
            if (Convert.ToInt32(oleDb.GetDataResult(strsql)) == 0)
            {
                strsql = "insert into BaseMessageRead(messageid,userid,readtime) values(" + messageId + "," + userId + ",'" + DateTime.Now.Date.ToString() + "')";
                oleDb.DoCommand(strsql);
            }
        }

        public BaseMessageType GetMessageType(string typecode)
        {
            string strsql = @"select * from BaseMessageType where Code='" + typecode + "'";
            DataTable dt = oleDb.GetDataTable(strsql);
            if (dt.Rows.Count > 0)
                return ConvertExtend.ToObject<BaseMessageType>(dt, 0, oleDb, _container,_cache,_pluginName, null);
            else
                return null;
        }
    }
}
