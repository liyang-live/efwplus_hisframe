using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EFWCoreLib.CoreFrame.Business;
using base_businessremind.Entity;
using base_businessremind.Dao;

namespace base_businessremind.ObjectModel
{
    public class Message : AbstractObjectModel
    {
        /// <summary>
        /// 获取消息有效时间类型数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetLimitTimeType()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", Type.GetType("System.String"));
            table.Columns.Add("Name", Type.GetType("System.String"));
            DataRow row = table.NewRow();
            row["Id"] = "D";
            row["Name"] = "天";
            table.Rows.Add(row);
            row = table.NewRow();
            row["Id"] = "H";
            row["Name"] = "小时";
            table.Rows.Add(row);
            row = table.NewRow();
            row["Id"] = "M";
            row["Name"] = "分钟";
            table.Rows.Add(row);
            row = table.NewRow();
            row["Id"] = "Y";
            row["Name"] = "无";
            table.Rows.Add(row);
            return table;
        }

        public List<BaseMessageType> GetMessageType()
        {
            return NewObject<BaseMessageType>().getlist<BaseMessageType>();
        }

        public void SaveMessageType(BaseMessageType type)
        {
            type.save();
        }

        public void DeleteMessageType(int typeId)
        {
            NewObject<BaseMessageType>().delete(typeId);
        }


        public List<BaseMessage> GetNotReadMessages(int userId, int deptId, int workId)
        {
            return NewDao<MessageDao>().GetNotReadMessages(userId, deptId, workId);
        }

        public List<BaseMessage> GetIsReadMessages(int userId,DateTime date)
        {
            return NewDao<MessageDao>().GetIsReadMessages(userId,date);
        }

        public List<BaseMessage> GetSendMessages(int userId, DateTime date)
        {
            return NewDao<MessageDao>().GetSendMessages(userId,date);
        }

        
        /// <summary>
        /// 获取消息有效时间的数据库表示字段
        /// </summary>
        /// <returns></returns>
        private DateTime GetLimitTime(string typecode)
        {
            DateTime message_limittime = DateTime.Now.AddDays(1);
            try
            {
                string _limittime = NewDao<MessageDao>().GetLimitTime(typecode);
                int timenum = Convert.ToInt32(_limittime.Substring(0, _limittime.Length - 1));
                string timetype = _limittime.Substring(_limittime.Length - 1);
                switch (timetype)
                {
                    case "D":
                        message_limittime = DateTime.Now.AddDays(timenum);
                        break;
                    case "H":
                        message_limittime = DateTime.Now.AddHours(timenum);
                        break;
                    case "M":
                        message_limittime = DateTime.Now.AddMinutes(timenum);
                        break;
                    case "Y":
                        message_limittime = DateTime.Now.AddYears(100);
                        break;
                    default:
                        break;
                }
            }
            catch
            { }
            return message_limittime;
        }

        private string ReplaceParams(string _tpl, params string[] param)
        {
            string tpl = _tpl;
            for (int i = 0; i < param.Length; i++)
            {
                tpl = tpl.Replace("#value" + (i + 1).ToString() + "#", param[i]);
            }
            return tpl;
        }

        public string GetMessageTitle(string typecode, params string[] value)
        {
            string tpltitle = NewDao<MessageDao>().GetMessageType(typecode).titletpl;
            return ReplaceParams(tpltitle, value);
        }

        public string GetMessageContent(string typecode, params string[] value)
        {
            string tpltitle = NewDao<MessageDao>().GetMessageType(typecode).texttpl;
            return ReplaceParams(tpltitle, value);
        }

        public void SendMessage(BaseMessage message)
        {
            message.Limittime = GetLimitTime(message.MessageType);
            message.save();
        }

        public void MessageRead(int messageId, int userId)
        {
            NewDao<MessageDao>().MessageRead(messageId, userId);
        }


       
    }
}
