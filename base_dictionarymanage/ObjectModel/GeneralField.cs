using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EFWCoreLib.CoreFrame.Business;
using base_dictionarymanage.Entity;
using base_dictionarymanage.Dao;


namespace base_dictionarymanage.ObjectModel
{
    public class GeneralField : AbstractBusines
    {
        //[AOP(typeof(AopTransaction))]
        public void InitFields(int titleId)
        {
            BaseGeneralTitle title = NewObject<BaseGeneralTitle>().getmodel(titleId) as BaseGeneralTitle;

            DataTable dt = NewDao<GeneralDao>().GetDbFields(title.TableName);

            List<BaseGeneralField> fields = new List<BaseGeneralField>();
            try
            {
                //先删除原来数据
                NewDao<GeneralDao>().DeleteField(titleId);
                //循环添加字段
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BaseGeneralField field = NewObject<BaseGeneralField>();
                    field.FieldId = 0;
                    field.TitleId = titleId;
                    field.Name = dt.Rows[i]["remarks"] == DBNull.Value ? dt.Rows[i]["colname"].ToString() : dt.Rows[i]["remarks"].ToString();
                    field.ColName = dt.Rows[i]["colname"].ToString();
                    field.ColLength = Convert.ToInt32(dt.Rows[i]["length"]);
                    field.DataType = dt.Rows[i]["typename"].ToString();
                    field.UiType = 0;
                    field.DynamicSQL = "";
                    field.DataUnitId = "-1";
                    field.IsMust = dt.Rows[i]["nulls"].ToString() == "Y" ? 0 : 1;
                    field.MatchRegular = "";
                    field.SortOrder = i;
                    field.IsKey = dt.Rows[i]["_identity"].ToString() == "Y" ? 1 : 0;
                    field.save();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<BaseGeneralField> GetFieldList(int titleId)
        {
            return NewDao<GeneralDao>().GetFieldList(titleId);
        }

        public void DeleteField(int titleId)
        {
            NewDao<GeneralDao>().DeleteField(titleId);
        }
    }
}
