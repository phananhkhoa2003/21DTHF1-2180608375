using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab05.Model;
using Microsoft.Reporting.WinForms;

namespace Lab05
{
    public partial class Form1 : Form
    {
        StudentDBContext db = new StudentDBContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<Student> liststudents = db.Students.ToList();
            List<StudentReport> listreport = new List<StudentReport>();
            foreach (Student i in liststudents)
            {
                StudentReport temp = new StudentReport();
                temp.StudentID = i.StudentID;
                temp.FullName = i.FullName;
                temp.AverageScore= i.DiemTB.Value;
                temp.FacultyName = i.Faculty.FacultyName;
                listreport.Add(temp);
            }
            this.reportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            var ReportDataSource = new ReportDataSource("StudentDataSet", listreport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(ReportDataSource);
            this.reportViewer1.RefreshReport();
        }

        
    }
}
