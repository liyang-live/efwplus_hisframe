using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.CoreFrame.Business;
using base_reportmanage.Entity;


namespace base_reportmanage.Dao
{
    public class ReportDao : AbstractDao
    {
        public DataTable GetDbProcedures()
        {
            string strsql = "select  routine_name as  spname   from   INFORMATION_SCHEMA.ROUTINES where routine_name like 'SP_Rpt_%'";
            return oleDb.GetDataTable(strsql);
        }

        public List<BaseReportField> GetFieldList(int titleId)
        {
            string strsql = @"select * from BaseReportField where TitleId={0} order by SortId";
            strsql = String.Format(strsql, titleId);
            DataTable dt = oleDb.GetDataTable(strsql);
            if (dt.Rows.Count > 0)
                return ConvertExtend.ToList<BaseReportField>(dt, oleDb, _container,_cache,_pluginName, null);
            else
                return new List<BaseReportField>();
        }

        public void DeleteField(int titleId)
        {
            string strsql = @"delete from BaseReportField where TitleId=" + titleId;
            oleDb.DoCommand(strsql);
        }

        public DataTable GetProFields(string ProcedureName)
        {
            string strsql = @"select  
                                    substring(a.name,2,len(a.name)-1) as parmname, max_length as length
                                    ,(select top 1 name from sys.types where system_type_id=a.system_type_id) as typename
                                    , 'P' as rowtype   from   sys.parameters a 
                                    left join sys.procedures b on a.object_id=b.object_id 
                                    where b.type='P' and b.name='{0}'
                                    order by a.parameter_id";
            strsql = String.Format(strsql, ProcedureName);

            return oleDb.GetDataTable(strsql);
        }

        public List<BaseReportTitle> GetGroupTitleList(int groupId)
        {
            string strsql = @"select b.* from BaseReportGroupTitle a left join BaseReportTitle b on a.TitleId=b.TitleId
                                where a.GroupId=" + groupId;
            DataTable dt = oleDb.GetDataTable(strsql);
            if (dt.Rows.Count > 0)
                return ConvertExtend.ToList<BaseReportTitle>(dt, oleDb, _container,_cache,_pluginName, null);
            else
                return new List<BaseReportTitle>();
        }

        public List<BaseReportTitle> GetUserTitleList(int userId)
        {
            string strsql = @"select b.* from BaseReportGroupTitle a 
                                left join BaseReportTitle b on a.TitleId=b.TitleId
                                left join BaseGroupUser c on a.GroupId=c.GroupId
                                where c.UserId=" + userId;
            DataTable dt = oleDb.GetDataTable(strsql);
            if (dt.Rows.Count > 0)
                return ConvertExtend.ToList<BaseReportTitle>(dt, oleDb,_container,_cache,_pluginName, null);
            else
                return new List<BaseReportTitle>();
        }

        public void DeleteGroupTitle(int groupId)
        {
            string strsql = @"delete from BaseReportGroupTitle where GroupId=" + groupId + "";
            oleDb.DoCommand(strsql);
        }

        public void SaveGroupTitle(int groupId, int titleId)
        {
            BaseReportGroupTitle grouptitile = NewObject<BaseReportGroupTitle>();
            grouptitile.GroupId = groupId;
            grouptitile.TitleId = titleId;
            grouptitile.save();
        }

        public DataTable GetUnitData(int unitId, string unitSql)
        {
            string SQL = unitSql;
            if (SQL == "")
            {
                SQL = "select DataVal as code,DataName as name from BaseGeneralStaticdData where DataUnitId=" + unitId;
            }
            return oleDb.GetDataTable(SQL);
        }

        public System.Data.DataTable GetResultDynamicSQLData(int fieldId)
        {
            string strsql = @"select DataUnitId,DynamicSQL from BaseReportField where FieldId={0} ";
            strsql = String.Format(strsql, fieldId);
            DataTable dt = oleDb.GetDataTable(strsql);
            int unitId = Convert.ToInt32(dt.Rows[0]["DataUnitId"]);
            string SQL = dt.Rows[0]["DynamicSQL"].ToString();
            return GetUnitData(unitId, SQL);
        }
    }
}
