using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DemoTask_GridSerialization.MainForm; 

namespace DemoTask_GridSerialization
{
    public partial class AddForm : Form
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public int index { get; set; }
        public Operations Operations_sub { get; set; }

        public AddForm(Operations op)
        {
            InitializeComponent();
            Operations_sub = op;
        }
        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        public void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Operations_sub.Selected_Operation == "update")
                {
                    Operations_sub.Staff.Remove(Operations_sub.Staff[index]);

                    Operations_sub.Staff.Insert(index, new Employee()
                    {
                        EmployeeId = int.Parse(txtID.Text),
                        EmployeeName = txtName.Text,
                        Age = int.Parse(txtAge.Text),
                        Experience = int.Parse(txtExp.Text),
                        Salary = int.Parse(txtSalary.Text)
                    });
                }
                else
                {
                    Operations_sub.Staff.Add(new Employee()
                    {
                        EmployeeId = int.Parse(txtID.Text),
                        EmployeeName = txtName.Text,
                        Age = int.Parse(txtAge.Text),
                        Experience = int.Parse(txtExp.Text),
                        Salary = int.Parse(txtSalary.Text)
                    });
                }
                this.Close();
                Operations_sub.MyDelegate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddData(int Id, string Name, int age, int experience, int salary)
        {
            try
            {
                this.txtID.Text = Convert.ToString(Id);
                this.txtName.Text = Name;
                this.txtAge.Text = Convert.ToString(age);
                this.txtExp.Text = Convert.ToString(experience);
                this.txtSalary.Text = Convert.ToString(salary);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
