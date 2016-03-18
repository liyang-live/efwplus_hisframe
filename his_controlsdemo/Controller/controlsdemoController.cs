using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WinformFrame.Controller;

namespace his_controlsdemo.Controller
{
    [WinformController]//在菜单上显示
    [WinformView(Name = "FrmBedCard", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmBedCard")]//控制器关联的界面
    [WinformView(Name = "FrmCustomDocument", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmCustomDocument")]//控制器关联的界面
    [WinformView(Name = "FrmEmrRecord", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmEmrRecord")]//控制器关联的界面
    [WinformView(Name = "FrmEmrRecord2", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmEmrRecord2")]//控制器关联的界面
    [WinformView(Name = "FrmEmrRecord3", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmEmrRecord3")]//控制器关联的界面
    [WinformView(Name = "FrmPrescription", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.FrmPrescription")]//控制器关联的界面
    [WinformView(Name = "Form1", DllName = "his_controlsdemo.dll", ViewTypeName = "TestControls.Form1")]//控制器关联的界面
    public class controlsdemoController : WinformController
    {
    }
}
