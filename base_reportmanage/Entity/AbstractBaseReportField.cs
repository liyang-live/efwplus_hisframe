using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace base_reportmanage.Entity
{
    [Serializable]
    [Table(TableName = "BaseReportField", EntityType = EntityType.Table, IsGB = false)]
    public class BaseReportField : AbstractEntity
    {
        private int  _fieldid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "FieldId", DataKey = true,  Match = "", IsInsert = false)]
        public int FieldId
        {
            get { return  _fieldid; }
            set {  _fieldid = value; }
        }

        private int  _titleid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "TitleId", DataKey = false,  Match = "", IsInsert = true)]
        public int TitleId
        {
            get { return  _titleid; }
            set {  _titleid = value; }
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

        private string  _colname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ColName", DataKey = false,  Match = "", IsInsert = true)]
        public string ColName
        {
            get { return  _colname; }
            set {  _colname = value; }
        }

        private int  _collength;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "ColLength", DataKey = false,  Match = "", IsInsert = true)]
        public int ColLength
        {
            get { return  _collength; }
            set {  _collength = value; }
        }

        private string  _datatype;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DataType", DataKey = false,  Match = "", IsInsert = true)]
        public string DataType
        {
            get { return  _datatype; }
            set {  _datatype = value; }
        }

        private int  _uitype;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UiType", DataKey = false,  Match = "", IsInsert = true)]
        public int UiType
        {
            get { return  _uitype; }
            set {  _uitype = value; }
        }

        private string  _dynamicsql;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DynamicSQL", DataKey = false,  Match = "", IsInsert = true)]
        public string DynamicSQL
        {
            get { return  _dynamicsql; }
            set {  _dynamicsql = value; }
        }

        private string  _dataunitid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DataUnitId", DataKey = false,  Match = "", IsInsert = true)]
        public string DataUnitId
        {
            get { return  _dataunitid; }
            set {  _dataunitid = value; }
        }

        private int  _ismust;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "IsMust", DataKey = false,  Match = "", IsInsert = true)]
        public int IsMust
        {
            get { return  _ismust; }
            set {  _ismust = value; }
        }

        private string  _matchregular;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "MatchRegular", DataKey = false,  Match = "", IsInsert = true)]
        public string MatchRegular
        {
            get { return  _matchregular; }
            set {  _matchregular = value; }
        }

        private int  _sortid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "SortId", DataKey = false,  Match = "", IsInsert = true)]
        public int SortId
        {
            get { return  _sortid; }
            set {  _sortid = value; }
        }

        private int  _iskey;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "IsKey", DataKey = false,  Match = "", IsInsert = true)]
        public int IsKey
        {
            get { return  _iskey; }
            set {  _iskey = value; }
        }

    }
}
