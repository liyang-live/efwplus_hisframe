using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace base_reportmanage.Entity
{
    [Serializable]
    [Table(TableName = "BaseReportLayer", EntityType = EntityType.Table, IsGB = false)]
    public class BaseReportLayer : AbstractEntity
    {
        private int  _layerid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "LayerId", DataKey = true,  Match = "", IsInsert = false)]
        public int LayerId
        {
            get { return  _layerid; }
            set {  _layerid = value; }
        }

        private int  _playerid;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "PLayerId", DataKey = false,  Match = "", IsInsert = true)]
        public int PLayerId
        {
            get { return  _playerid; }
            set {  _playerid = value; }
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
