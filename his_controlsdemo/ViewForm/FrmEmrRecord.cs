﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EFWCoreLib.WinformFrame.Controller;

namespace TestControls
{
    public partial class FrmEmrRecord : BaseForm
    {
        public FrmEmrRecord()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //new TestEmrDbHelper(),new TestEmrDataSource()
            emrRecord1.InitLoad(new TestEmrWriteDbHelper());
            //emrRecord1.SetPatientEmrData(new EMR.Controls.Action.EmrBindKeyData());
        }

    }
}
