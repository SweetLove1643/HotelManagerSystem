﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKS.Resources
{
    public partial class RoomUC : UserControl
    {
        public RoomUC()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            addBtn.Visible = true;
            updateBtn.Visible = true;
            deleteBtn.Visible = true;
            confirmBtn.Visible = false;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            addBtn.Visible = false;
            updateBtn.Visible = false;
            deleteBtn.Visible = false;
            confirmBtn.Visible = true;
        }
    }
}
