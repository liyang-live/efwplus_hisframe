using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace base_reportmanage.Entity
{
    [Serializable]
    [Table(TableName = "BaseReportTitle", EntityType = EntityType.Table, IsGB = false)]
    public class BaseReportTitle : AbstractEntity
    {
        private int  _titleid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "TitleId", DataKey = true,  Match = "", IsInsert = false)]
        public int TitleId
        {
            get { return  _titleid; }
            set {  _titleid = value; }
        }

        private int  _layerid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "LayerId", DataKey = false,  Match = "", IsInsert = true)]
        public int LayerId
        {
            get { return  _layerid; }
            set {  _layerid = value; }
        }

        private string  _name;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Name", DataKey = false,  Match = "", IsInsert = true)]
        public string Name
        {
            get { return  _name; }
            set {  _name = value; }
        }

        private string  _proname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ProName", DataKey = false,  Match = "", IsInsert = true)]
        public string ProName
        {
            get { return  _proname; }
            set {  _proname = value; }
        }

        private int  _type;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Type", DataKey = false,  Match = "", IsInsert = true)]
        public int Type
        {
            get { return  _type; }
            set {  _type = value; }
        }

        private string  _rptfilename;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "RptFileName", DataKey = false,  Match = "", IsInsert = true)]
        public string RptFileName
        {
            get { return  _rptfilename; }
            set {  _rptfilename = value; }
        }

        private string  _memo;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Memo", DataKey = false,  Match = "", IsInsert = true)]
        public string Memo
        {
            get { return  _memo; }
            set {  _memo = value; }
        }

    }
}
