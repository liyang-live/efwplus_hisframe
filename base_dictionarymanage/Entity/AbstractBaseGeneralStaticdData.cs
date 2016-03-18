using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace base_dictionarymanage.Entity
{
    [Serializable]
    [Table(TableName = "BaseGeneralStaticdData", EntityType = EntityType.Table, IsGB = true)]
    public class BaseGeneralStaticdData : AbstractEntity
    {
        private int  _staticdataid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "StaticDataId", DataKey = true,  Match = "", IsInsert = false)]
        public int StaticDataId
        {
            get { return  _staticdataid; }
            set {  _staticdataid = value; }
        }

        private int  _dataunitid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DataUnitId", DataKey = false,  Match = "", IsInsert = true)]
        public int DataUnitId
        {
            get { return  _dataunitid; }
            set {  _dataunitid = value; }
        }

        private string  _dataname;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DataName", DataKey = false,  Match = "", IsInsert = true)]
        public string DataName
        {
            get { return  _dataname; }
            set {  _dataname = value; }
        }

        private string  _dataval;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DataVal", DataKey = false,  Match = "", IsInsert = true)]
        public string DataVal
        {
            get { return  _dataval; }
            set {  _dataval = value; }
        }

    }
}
