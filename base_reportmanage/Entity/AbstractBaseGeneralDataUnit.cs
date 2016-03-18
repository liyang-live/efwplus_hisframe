using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace base_reportmanage.Entity
{
    [Serializable]
    [Table(TableName = "BaseGeneralDataUnit", EntityType = EntityType.Table, IsGB = true)]
    public class BaseGeneralDataUnit : AbstractEntity
    {
        private int  _dataunitid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "DataUnitId", DataKey = true,  Match = "", IsInsert = false)]
        public int DataUnitId
        {
            get { return  _dataunitid; }
            set {  _dataunitid = value; }
        }

        private int  _punitid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PUnitId", DataKey = false,  Match = "", IsInsert = true)]
        public int PUnitId
        {
            get { return  _punitid; }
            set {  _punitid = value; }
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

        private int  _isunit;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "IsUnit", DataKey = false,  Match = "", IsInsert = true)]
        public int IsUnit
        {
            get { return  _isunit; }
            set {  _isunit = value; }
        }

        private string  _unitsql;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "UnitSQL", DataKey = false,  Match = "", IsInsert = true)]
        public string UnitSQL
        {
            get { return  _unitsql; }
            set {  _unitsql = value; }
        }

    }
}
