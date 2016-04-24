using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFWCoreLib.WinformFrame.Controller;

namespace his_controlsdemo.ViewForm
{
    public partial class FrmCustomControls : BaseForm
    {
        public FrmCustomControls()
        {
            InitializeComponent();
        }

        private void FrmCustomControls_OpenWindowBefore(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            switch (frmName)
            {
                case "DataGrid":
                    panel1.Visible = true;
                    panel1.Dock = DockStyle.Fill;

                    dataGrid1.DataSource=(DataTable)InvokeController("GetBooks");
                    break;
                case "GridBoxCard":
                    panel2.Visible = true;
                    panel2.Dock = DockStyle.Fill;
                    break;
                case "TextboxCard":
                    panel3.Visible = true;
                    panel3.Dock = DockStyle.Fill;
                    break;
                case "MultiSelectText":
                    panel4.Visible = true;
                    panel4.Dock = DockStyle.Fill;
                    break;
                case "StatDateTime":
                    panel5.Visible = true;
                    panel5.Dock = DockStyle.Fill;
                    break;
                case "Popup":
                    panel6.Visible = true;
                    panel6.Dock = DockStyle.Fill;
                    break;
            }
        }
    }
}
