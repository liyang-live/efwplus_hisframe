using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace base_dictionarymanage.Entity
{
    [Serializable]
    [Table(TableName = "BaseGeneralLayer", EntityType = EntityType.Table, IsGB = true)]
    public class BaseGeneralLayer : AbstractEntity
    {
        private int  _glayerid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "GLayerId", DataKey = true,  Match = "", IsInsert = false)]
        public int GLayerId
        {
            get { return  _glayerid; }
            set {  _glayerid = value; }
        }

        private int  _pid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PId", DataKey = false,  Match = "", IsInsert = true)]
        public int PId
        {
            get { return  _pid; }
            set {  _pid = value; }
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

    }
}
