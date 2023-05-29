using System;
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

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

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
