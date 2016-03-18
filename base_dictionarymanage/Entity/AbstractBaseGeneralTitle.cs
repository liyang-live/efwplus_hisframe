using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace base_dictionarymanage.Entity
{
    [Serializable]
    [Table(TableName = "BaseGeneralTitle", EntityType = EntityType.Table, IsGB = true)]
    public class BaseGeneralTitle : AbstractEntity
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

        private string  _tablename;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "TableName", DataKey = false,  Match = "", IsInsert = true)]
        public string TableName
        {
            get { return  _tablename; }
            set {  _tablename = value; }
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
