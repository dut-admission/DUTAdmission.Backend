using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.NewDatabase;
using DUTAdmissionSystem.NewDatabase.Schema.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DUTAdmissionSystem.Window
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            progressBar.Minimum = 2818;
            progressBar.Maximum = 2822;
            ImportSinhVien();
        }
        public void ImportSinhVien()
        {
            DataContext context = new DataContext();

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:/Users/Aiden/Documents/DUTAdmission/resources/DUTAdmission.Backend/DUTAdmissionSystem.Window/data/K2019.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = progressBar.Minimum; i <= progressBar.Maximum; i++)
            {
                progressBar.Value = i;
                percentageTxtBox.Text = $"{progressBar.Value}/{progressBar.Maximum}";

                try
                {
                    //var dateOfBirth = xlRange.Cells[i, 6].Value2.ToString();
                    //var dateArray = dateOfBirth.Split('/');
                    //int day = Convert.ToInt32(dateArray[0]);
                    //int month = Convert.ToInt32(dateArray[1]);
                    //int year = Convert.ToInt32(dateArray[2]);

                    var user = new UserInfo()
                    {
                        FirstName = xlRange.Cells[i, 4].Value2.ToString(),
                        LastName = xlRange.Cells[i, 3].Value2.ToString(),
                        IdentityNumber = xlRange.Cells[i, 5].Value2.ToString(),
                        DateOfBirth = new DateTime(2001, 1, 1),
                        PhoneNumber = xlRange.Cells[i, 8].Value2.ToString(),
                        EthnicId = 1,
                        NationalityId = 1,
                        ReligionId = 1,
                        DateOfIssue = new DateTime(2000, 1, 1)
                    };
                    var student = new Student()
                    {
                        UserInfo = user,
                        IdentificationNumber = xlRange.Cells[i, 2].Value2.ToString(),
                        ElectionTypeId = 3,
                        CircumstanceTypeId = 1,
                        EnrollmentAreaId = 1,
                        ClassId = Convert.ToInt32(xlRange.Cells[i, 7].Value2.ToString()),
                        DateOfJoiningYouthGroup = new DateTime(2000, 1, 1)
                    };

                    var account = new Account()
                    {
                        UserInfo = user,
                        Avatar = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT_S9DUg_S9CHf-DxgcNbxYzZmibzud95wxTQslnreREOxA1ch1",
                        AccountGroupId = 6,
                        UserName = xlRange.Cells[i, 2].Value2.ToString(),
                        Password = FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(xlRange.Cells[i, 2].Value2.ToString()))
                    };

                    context.Accounts.Add(account);
                    context.Students.Add(student);

                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    errorNumberLog.Text += $"    {i}";
                }
                
            }
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
