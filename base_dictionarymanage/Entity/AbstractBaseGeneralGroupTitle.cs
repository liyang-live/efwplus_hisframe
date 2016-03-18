using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace base_dictionarymanage.Entity
{
    [Serializable]
    [Table(TableName = "BaseGeneralGroupTitle", EntityType = EntityType.Table, IsGB = true)]
    public class BaseGeneralGroupTitle : AbstractEntity
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

        private int  _groupid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "GroupId", DataKey = false,  Match = "", IsInsert = true)]
        public int GroupId
        {
            get { return  _groupid; }
            set {  _groupid = value; }
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

    }
}
