﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        ApplicationEntities dbContext=new ApplicationEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Emp emp=new Emp();
                emp.Name = txtName.Text;
                emp.Salary=Convert.ToInt32(txtSalary.Text);
                emp.DeptName=txtDeptName.Text;
                dbContext.Emps.Add(emp);
                dbContext.SaveChanges();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                Emp emp = dbContext.Emps.Find(Convert.ToInt32(txtId.Text));
                if (emp != null)
                {
                    emp.Name = txtName.Text;
                    emp.Salary = Convert.ToInt32(txtSalary.Text);
                    emp.DeptName=txtDeptName.Text;  
                    dbContext.Emps.Add(emp);
                    dbContext.SaveChanges();
                    MessageBox.Show("Updated");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {


                Emp emp = dbContext.Emps.Find(Convert.ToInt32(txtId.Text));
                if (emp != null)
                {
                   
                    dbContext.Emps.Add(emp);
                    dbContext.SaveChanges();
                    MessageBox.Show("deleted");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                Emp emp = dbContext.Emps.Find(Convert.ToInt32(txtId.Text));
                if (emp != null)
                {
                    txtName.Text = emp.Name;
                    txtSalary.Text = emp.Salary.ToString();

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = dbContext.Emps.ToList();

        }

    }

}
