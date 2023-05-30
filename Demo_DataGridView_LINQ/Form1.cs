﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_DataGridView_LINQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //LoadDataSourceForDataGridView();
        }

        private void LoadDataSourceForDataGridView()
        {
            using (MyDataClassesDataContext db = new MyDataClassesDataContext())
            {
                //dataGridView1.DataSource = from emp in db.Employees
                //                           from profile in db.EmployeeProfiles
                //                           where emp.Id == profile.EmployeeId
                //                           select new
                //                           {
                //                               Employee_Name = emp.Name,
                //                               Date_Of_Birth = emp.DateOfBirth,
                //                               Sex = (bool)emp.Sex ? "Male" : "Female",
                //                               Informarion = profile.Info
                //                           };

                dataGridView1.DataSource = from emp in db.Employees
                                           select emp;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            using (MyDataClassesDataContext db = new MyDataClassesDataContext())
            {
                dataGridView1.DataSource = from emp in db.Employees
                                           select emp;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (MyDataClassesDataContext db = new MyDataClassesDataContext())
            {
                int id = (int)dataGridView1.SelectedCells[0].OwningRow.Cells["Id"].Value;
                Employee deletedEmp = db.Employees.Where(p => p.Id == id).SingleOrDefault();
                db.Employees.DeleteOnSubmit(deletedEmp);
                db.SubmitChanges();
                //MessageBox.Show("An employee was deleted from database.");

                // Re-load database
                btnView_Click(sender, e);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtKey.Text;
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter an id into text box");
                return;
            }
            else
            {
                using (MyDataClassesDataContext db = new MyDataClassesDataContext())
                {
                    int searchedId = Convert.ToInt32(id);
                    dataGridView1.DataSource = db.Employees.Where(p => p.Id == searchedId);
                }
                
            }
        }

        // TESTING
        //private void btnView_Click(object sender, EventArgs e)
        //{
        //    using (MyDataClassesDataContext db = new MyDataClassesDataContext())
        //    {
        //        dataGridView1.DataSource = from emp in db.Employees
        //                                   select emp;

        //        //dataGridView1.DataSource = db.Employees.Select(p => p);
        //        //dataGridView1.DataSource =
        //        //    db.Employees
        //        //    .Where(p => p.Id > 1)
        //        //    .OrderBy(p => p.Sex);

        //        //dataGridView1.DataSource =
        //        //    from emp in db.Employees
        //        //    where emp.Id > 1
        //        //    orderby emp.Id descending
        //        //    select emp;

        //        //dataGridView1.DataSource =
        //        //    from emp in db.Employees
        //        //    from profile in db.EmployeeProfiles
        //        //    where emp.Id == profile.EmployeeId
        //        //    select profile;

        //        //dataGridView1.DataSource =
        //        //    from emp in db.Employees
        //        //    from profile in db.EmployeeProfiles
        //        //    where emp.Id == profile.EmployeeId
        //        //    select new { 
        //        //        Id = emp.Id,
        //        //        EmployeeName = emp.Name,
        //        //        Info = profile.Info
        //        //    };

        //        //dataGridView1.DataSource =
        //        //    from emp in db.Employees
        //        //    from profile in db.EmployeeProfiles
        //        //    where emp.Id == profile.EmployeeId
        //        //    select new
        //        //    {
        //        //        Id = emp.Id,
        //        //        EmployeeName = emp.Name,
        //        //        Info = profile.Info
        //        //    } into newSelect 
        //        //        where newSelect.Id == 1 
        //        //        select newSelect;
        //    }
        //}
    }
}
