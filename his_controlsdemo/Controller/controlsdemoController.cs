using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WinformFrame.Controller;
using TestControls;

namespace his_controlsdemo.Controller
{
    [WinformController]//在菜单上显示
    [WinformView(Name = "FrmBedCard", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmBedCard")]//控制器关联的界面
    [WinformView(Name = "FrmCustomDocument", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmCustomDocument")]//控制器关联的界面
    [WinformView(Name = "FrmEmrRecord", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmEmrRecord")]//控制器关联的界面
    [WinformView(Name = "FrmEmrRecord2", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmEmrRecord2")]//控制器关联的界面
    [WinformView(Name = "FrmEmrRecord3", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmEmrRecord3")]//控制器关联的界面
    [WinformView(Name = "FrmPrescription", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmPrescription")]//控制器关联的界面
    [WinformView(Name = "FrmTemperature", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmTemperature")]//控制器关联的界面
    [WinformView(Name = "FrmMRecordFirst", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmMRecordFirst")]//控制器关联的界面
    [WinformView(Name = "Form1", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.Form1")]//控制器关联的界面
    [WinformView(Name = "DataGrid", DllName = "his_controlsdemo.dll", ViewTypeName = "his_controlsdemo.ViewForm.FrmCustomControls")]//控制器关联的界面
    [WinformView(Name = "GridBoxCard", DllName = "his_controlsdemo.dll", ViewTypeName = "his_controlsdemo.ViewForm.FrmCustomControls")]//控制器关联的界面
    [WinformView(Name = "TextboxCard", DllName = "his_controlsdemo.dll", ViewTypeName = "his_controlsdemo.ViewForm.FrmCustomControls")]//控制器关联的界面
    [WinformView(Name = "MultiSelectText", DllName = "his_controlsdemo.dll", ViewTypeName = "his_controlsdemo.ViewForm.FrmCustomControls")]//控制器关联的界面
    [WinformView(Name = "StatDateTime", DllName = "his_controlsdemo.dll", ViewTypeName = "his_controlsdemo.ViewForm.FrmCustomControls")]//控制器关联的界面
    [WinformView(Name = "Popup", DllName = "his_controlsdemo.dll", ViewTypeName = "his_controlsdemo.ViewForm.FrmCustomControls")]//控制器关联的界面
    public class controlsdemoController : WinformController
    {
        [WinformMethod]
        public TestPrescripttionDbHelper NewTestPrescripttionDbHelper()
        {
            return new TestPrescripttionDbHelper(oleDb.ConnectionString);
        }
        [WinformMethod]
        public TestEmrTemplateDbHelper NewTestEmrTemplateDbHelper()
        {
            return new TestEmrTemplateDbHelper(oleDb.ConnectionString);
        }
        [WinformMethod]
        public TestEmrWriteDbHelper NewTestEmrWriteDbHelper()
        {
            return new TestEmrWriteDbHelper(oleDb.ConnectionString);
        }

        [WinformMethod]
        public DataTable GetBooks()
        {
            string strsql = @"select BookName,BuyPrice,BuyDate from books";
            return oleDb.GetDataTable(strsql);
        }
    }
}
