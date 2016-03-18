using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace base_businessremind.Entity
{
    [Serializable]
    [Table(TableName = "BaseMessageRead", EntityType = EntityType.Table, IsGB = true)]
    public class BaseMessageRead : AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Id", DataKey = true,  Match = "", IsInsert = false)]
        public int Id
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _messageid;
        /// <summary>
        /// 消息ID
        /// </summary>
        [Column(FieldName = "MessageId", DataKey = false,  Match = "", IsInsert = true)]
        public int MessageId
        {
            get { return  _messageid; }
            set {  _messageid = value; }
        }

        private int  _userid;
        /// <summary>
        /// 人员ID
        /// </summary>
        [Column(FieldName = "UserId", DataKey = false,  Match = "", IsInsert = true)]
        public int UserId
        {
            get { return  _userid; }
            set {  _userid = value; }
        }

        private DateTime  _readtime;
        /// <summary>
        /// 读取时间
        /// </summary>
        [Column(FieldName = "ReadTime", DataKey = false,  Match = "", IsInsert = true)]
        public DateTime ReadTime
        {
            get { return  _readtime; }
            set {  _readtime = value; }
        }

    }
}
