using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.CoreFrame.Business;
using base_dictionarymanage.Entity;
using EFWCoreLib.CoreFrame.DbProvider.SqlPagination;

namespace base_dictionarymanage.Dao
{
    [Serializable]
    public class GeneralDao : AbstractDao
    {
        public DataTable GetDbTables()
        {
            string strsql = @"select   table_name as tabname   from   INFORMATION_SCHEMA.TABLES order by table_name";
            return oleDb.GetDataTable(strsql);
        }

        public DataTable GetDbFields(string tablename)
        {
            string strsql = @"select c.value as remarks,a.name as colname
                                    ,(select top 1 name from sys.types where system_type_id=a.system_type_id) as typename
                                    ,max_length as length
                                    ,(case when is_nullable=0 then 'N' else 'Y' end) nulls
                                    ,(case when is_identity=1 then 'Y' else 'N' end) as _identity 
                                    from sys.columns a  left join sys.objects b on a.object_id=b.object_id 
									left join sys.extended_properties c  on a.object_id=c.major_id and a.column_id=c.minor_id
                                    where b.type='U' and b.name='{0}'";

            strsql = String.Format(strsql, tablename);

            return oleDb.GetDataTable(strsql);
        }

        public List<BaseGeneralField> GetFieldList(int titleId)
        {
            string strsql = @"select * from BaseGeneralField where TitleId={0} order by SortOrder";
            strsql = String.Format(strsql, titleId);
            DataTable dt = oleDb.GetDataTable(strsql);
            if (dt.Rows.Count > 0)
                return ConvertExtend.ToList<BaseGeneralField>(dt, oleDb, _container,_cache,_pluginName, null);
            else
                return new List<BaseGeneralField>();
        }

        public void DeleteField(int titleId)
        {
            string strsql = @"delete from BaseGeneralField where TitleId="+titleId;
            oleDb.DoCommand(strsql);
        }

        public List<BaseGeneralTitle> GetGroupTitleList(int groupId)
        {
            string strsql = @"select b.* from BaseGeneralGroupTitle a left join BaseGeneralTitle b on a.TitleId=b.TitleId
                                where a.GroupId=" + groupId;
            DataTable dt = oleDb.GetDataTable(strsql);
            if (dt.Rows.Count > 0)
                return ConvertExtend.ToList<BaseGeneralTitle>(dt, oleDb, _container,_cache,_pluginName, null);
            else
                return new List<BaseGeneralTitle>();
        }

        public List<BaseGeneralTitle> GetUserTitleList(int userId)
        {
            string strsql = @"select b.* from BaseGeneralGroupTitle a 
                                left join BaseGeneralTitle b on a.TitleId=b.TitleId
                                left join BaseGroupUser c on a.GroupId=c.GroupId
                                where c.UserId="+userId;
            DataTable dt = oleDb.GetDataTable(strsql);
            if (dt.Rows.Count > 0)
                return ConvertExtend.ToList<BaseGeneralTitle>(dt, oleDb, _container,_cache,_pluginName, null);
            else
                return new List<BaseGeneralTitle>();
        }


        public void DeleteGroupTitle(int groupId)
        {
            string strsql = @"delete from BaseGeneralGroupTitle where GroupId=" + groupId + "";
            oleDb.DoCommand(strsql);
        }

        public void SaveGroupTitle(int groupId, int titleId)
        {
            BaseGeneralGroupTitle grouptitile = NewObject<BaseGeneralGroupTitle>();
            grouptitile.GroupId = groupId;
            grouptitile.TitleId = titleId;
            grouptitile.save();
        }

        public List<string> GetFieldNames(int titleId)
        {
            string strsql = @"select ColName from BaseGeneralField where titleid={0} order by FieldId";
            strsql = String.Format(strsql, titleId);
            List<string> names = new List<string>();
            System.Data.IDataReader idr = oleDb.GetDataReader(strsql);
            while (idr.Read())
            {
                names.Add(idr["ColName"].ToString());
            }
            return names;
        }

        public DataTable GetColDataDynamicSQL(int fieldId)
        {
            string strsql = @"select DataUnitId,DynamicSQL from BaseGeneralField WHERE FieldId={0}";
            strsql = string.Format(strsql, fieldId);
            DataTable dt = oleDb.GetDataTable(strsql);
            int unitId = Convert.ToInt32(dt.Rows[0]["DataUnitId"]);
            string SQL = dt.Rows[0]["DynamicSQL"].ToString();
            return GetUnitData(unitId, SQL);
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

        public DataTable GetFieldResultData(int titleId, string strWhere, PageInfo page)
        {
            string strsql = "";
            //得到表名
            strsql = @"select TableName from BaseGeneralTitle where TitleId={0}";
            strsql = String.Format(strsql, titleId);
            string tablename = oleDb.GetDataResult(strsql).ToString();

            //得到表的主键ID名
            strsql = @"select ColName from BaseGeneralField where TitleId={0} and iskey=1";
            strsql = String.Format(strsql, titleId);
            string keyname = oleDb.GetDataResult(strsql).ToString();


            if (page != null)
            {
                //得到总记录数
                strsql = @"select count(*) from {0} where 1=1 {1} ";
                strsql = String.Format(strsql, tablename, strWhere);
                page.totalRecord = Convert.ToInt32(oleDb.GetDataResult(strsql));

                //根据分页取值
                strsql = @"select * from 
                                (select TOP({1}) * FROM 
                                (SELECT TOP ({1}*{2}) * from {0} where 1=1 {3} ORDER BY {4} ASC ) 
                                as aSysTable ORDER BY {4} DESC ) 
                                as bSysTable ORDER BY {4} ASC";
                strsql = String.Format(strsql, tablename, page.pageSize, page.pageNo, strWhere, keyname);
            }
            else
            {
                strsql = @"select * from {0} where 1=1 {1}";
                strsql = String.Format(strsql, tablename, strWhere);
            }
            DataTable dt = oleDb.GetDataTable(strsql);
            dt.TableName = tablename;
            return dt;
        }

        public string getFieldKeyName(int titleId)
        {
            try
            {
                string strsql = @"select Top 1 ColName from BaseGeneralField where TitleId={0} and IsKey=1";
                strsql = string.Format(strsql, titleId);
                return oleDb.GetDataResult(strsql).ToString();
            }
            catch (Exception err)
            {
                throw new Exception("没有设置主键," + err.Message);
            }
        }

        ////把resultId字符字段加上单引号
        private string alterResultId(string resultId, int titleId, string keyName)
        {
            string strsql = @"select DataType from BaseGeneralField where TitleId={0} and ColName='{1}'";
            strsql = String.Format(strsql, titleId, keyName);

            string type = oleDb.GetDataResult(strsql).ToString().ToLower();
            //把resultId字符字段加上单引号

            resultId = "'" + resultId + "'";
            return resultId == "" ? "''" : resultId;
        }

        public string[] parseResultXml(int titleId, Dictionary<string, string> FormData)
        {
            Dictionary<string, string> list = FormData;
            string strname = null;
            string strvalue = null;
            string strset = null;

            foreach (KeyValuePair<string, string> val in list.ToList())
            {
                string colName = val.Key;
                string colValue = val.Value;

                colValue = alterResultId(colValue, titleId, colName);

                strname += colName + ",";
                strvalue += colValue + ",";
                strset += colName + "=" + colValue + ",";
            }

            strname = strname.Remove(strname.Length - 1);
            strvalue = strvalue.Remove(strvalue.Length - 1);
            strset = strset.Remove(strset.Length - 1);

            return new string[] { strname, strvalue, strset };
        }

        public int AddResultData(int titleId, Dictionary<string, string> FormData)
        {
            //得到表名
            string strsql = @"select TableName from BaseGeneralTitle where TitleId={0}";
            strsql = String.Format(strsql, titleId);
            string tablename = oleDb.GetDataResult(strsql).ToString();

            string keyName = getFieldKeyName(titleId);

            if (FormData[keyName].Trim() == "")//add
            {
                FormData.Remove(keyName);
                string[] strs = parseResultXml(titleId, FormData);
                strsql = @"insert into {0}({1}) values({2})";
                strsql = String.Format(strsql, tablename, strs[0], strs[1]);
                return oleDb.InsertRecord(strsql);
            }
            else//update
            {
                string keyValue = FormData[keyName];
                FormData.Remove(keyName);
                string[] strs = parseResultXml(titleId, FormData);
                strsql = @"update {0} set {1} where {2}={3} ";
                strsql = String.Format(strsql, tablename, strs[2], keyName, keyValue);
                return oleDb.DoCommand(strsql);
            }
        }

        private string deleteResultId(string resultId, int titleId, string keyName)
        {

            string strsql = @"select DataType from BaseGeneralField where TitleId={0} and ColName='{1}'";
            strsql = String.Format(strsql, titleId, keyName);

            string type = oleDb.GetDataResult(strsql).ToString().ToLower();
            //把resultId字符字段加上单引号

            string[] strs = resultId.Split(new char[] { ',' });
            resultId = "";
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i].Trim() != "")
                {
                    if (i != strs.Length - 1)
                        resultId += "'" + strs[i] + "'" + ",";
                    else
                        resultId += "'" + strs[i] + "'";
                }
            }

            return resultId == "" ? "''" : resultId;
        }

        public int DeleteResultData(string resultId, int titleId, string keyName)
        {
            string strsql = "";
            //得到表名
            strsql = @"select TableName from BaseGeneralTitle where TitleId={0}";
            strsql = String.Format(strsql, titleId);
            string tablename = oleDb.GetDataResult(strsql).ToString();


            resultId = deleteResultId(resultId, titleId, keyName);


            strsql = @"delete from {0} where {1} in ({2})";
            strsql = String.Format(strsql, tablename, keyName, resultId);
            return oleDb.DoCommand(strsql);
        }
    }
}
