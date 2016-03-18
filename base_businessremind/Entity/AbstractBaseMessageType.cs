using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace base_businessremind.Entity
{
    [Serializable]
    [Table(TableName = "BaseMessageType", EntityType = EntityType.Table, IsGB = false)]
    public class BaseMessageType : AbstractEntity
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

        private string  _code;
        /// <summary>
        /// 消息类型编号
        /// </summary>
        [Column(FieldName = "Code", DataKey = false,  Match = "", IsInsert = true)]
        public string Code
        {
            get { return  _code; }
            set {  _code = value; }
        }

        private string  _name;
        /// <summary>
        /// 消息类型名称
        /// </summary>
        [Column(FieldName = "Name", DataKey = false,  Match = "", IsInsert = true)]
        public string Name
        {
            get { return  _name; }
            set {  _name = value; }
        }

        private int  _workflag;
        /// <summary>
        /// 接收系统模块
        /// </summary>
        [Column(FieldName = "WorkFlag", DataKey = false,  Match = "", IsInsert = true)]
        public int WorkFlag
        {
            get { return  _workflag; }
            set {  _workflag = value; }
        }

        private int  _deptflag;
        /// <summary>
        /// 接收菜单模块
        /// </summary>
        [Column(FieldName = "DeptFlag", DataKey = false,  Match = "", IsInsert = true)]
        public int DeptFlag
        {
            get { return  _deptflag; }
            set {  _deptflag = value; }
        }

        private string  _sendgroup;
        /// <summary>
        /// 接收科室
        /// </summary>
        [Column(FieldName = "SendGroup", DataKey = false,  Match = "", IsInsert = true)]
        public string SendGroup
        {
            get { return  _sendgroup; }
            set {  _sendgroup = value; }
        }

        private string  _receivegroup;
        /// <summary>
        /// 接收人
        /// </summary>
        [Column(FieldName = "ReceiveGroup", DataKey = false,  Match = "", IsInsert = true)]
        public string ReceiveGroup
        {
            get { return  _receivegroup; }
            set {  _receivegroup = value; }
        }

        private string  _limittime;
        /// <summary>
        /// 格式为数字加后缀（D表示天，H表示小时，M表示分钟），如1D
        /// </summary>
        [Column(FieldName = "Limittime", DataKey = false,  Match = "", IsInsert = true)]
        public string Limittime
        {
            get { return  _limittime; }
            set {  _limittime = value; }
        }

        private string  _memo;
        /// <summary>
        /// 消息类型说明
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false,  Match = "", IsInsert = true)]
        public string Memo
        {
            get { return  _memo; }
            set {  _memo = value; }
        }

        private string  _titletpl;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "titletpl", DataKey = false,  Match = "", IsInsert = true)]
        public string titletpl
        {
            get { return  _titletpl; }
            set {  _titletpl = value; }
        }

        private string  _texttpl;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "texttpl", DataKey = false,  Match = "", IsInsert = true)]
        public string texttpl
        {
            get { return  _texttpl; }
            set {  _texttpl = value; }
        }

        private int  _link_moduleid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "link_moduleid", DataKey = false,  Match = "", IsInsert = true)]
        public int link_moduleid
        {
            get { return  _link_moduleid; }
            set {  _link_moduleid = value; }
        }

        private int  _link_menuid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "link_menuid", DataKey = false,  Match = "", IsInsert = true)]
        public int link_menuid
        {
            get { return  _link_menuid; }
            set {  _link_menuid = value; }
        }

        private string  _link_name;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "link_name", DataKey = false,  Match = "", IsInsert = true)]
        public string link_name
        {
            get { return  _link_name; }
            set {  _link_name = value; }
        }

        private string  _link_url;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "link_url", DataKey = false,  Match = "", IsInsert = true)]
        public string link_url
        {
            get { return  _link_url; }
            set {  _link_url = value; }
        }

    }
}
