using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EFWCoreLib.CoreFrame.Business;
using base_reportmanage.Entity;
using base_reportmanage.Dao;

namespace base_reportmanage.ObjectModel
{
    public class ReportField : AbstractBusines
    {


        //[AOP(typeof(AopTransaction))]
        public void InitFields(int titleId)
        {
            BaseReportTitle title = NewObject<BaseReportTitle>().getmodel(titleId) as BaseReportTitle;

            DataTable dt = NewDao<ReportDao>().GetProFields(title.ProName);

            List<BaseReportField> fields = new List<BaseReportField>();
            try
            {
                //先删除原来数据
                NewDao<ReportDao>().DeleteField(titleId);
                //循环添加字段
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BaseReportField field = NewObject<BaseReportField>();
                    field.FieldId = 0;
                    field.TitleId = titleId;
                    field.Name = dt.Rows[i]["parmname"].ToString();
                    field.ColName = dt.Rows[i]["parmname"].ToString();
                    field.ColLength = Convert.ToInt32(dt.Rows[i]["length"]);
                    field.DataType = dt.Rows[i]["typename"].ToString();
                    field.UiType = 0;
                    field.DynamicSQL = "";
                    field.DataUnitId = "-1";
                    field.IsMust = dt.Rows[i]["rowtype"].ToString() == "P" ? 0 : 1;
                    field.MatchRegular = "";
                    field.SortId = i;
                    field.save();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public List<BaseReportField> GetFieldList(int titleId)
        {
            return NewDao<ReportDao>().GetFieldList(titleId);
        }

        public void DeleteField(int titleId)
        {
            NewDao<ReportDao>().DeleteField(titleId);
        }
    }
}
