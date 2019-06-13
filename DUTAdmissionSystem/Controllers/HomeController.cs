using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.Database;
using DUTAdmissionSystem.Database.Schema.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;

namespace DUTAdmissionSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            // getExcelFile();
            addDocumentForStudent();
            return View();
        }
        public void getExcelFile()
        {
            DataContext context = new DataContext();

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\Aiden\Desktop\data.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= 50; i++)
            {
                var user = new UserInfo()
                {
                    FirstName = xlRange.Cells[i, 4].Value2.ToString(),
                    LastName = xlRange.Cells[i, 3].Value2.ToString(),
                    Avatar = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT_S9DUg_S9CHf-DxgcNbxYzZmibzud95wxTQslnreREOxA1ch1",
                    BirthInfo = new BirthInfo()
                    {
                        Sex = true,
                        DateOfBirth = DateTime.ParseExact(xlRange.Cells[i, 5].Value2.ToString(), "dd/MM/yyyy", null),
                        PlaceOfBirth = xlRange.Cells[i, 10].Value2.ToString()
                    },
                    ContactInfo = new ContactInfo()
                    {
                        Address = xlRange.Cells[i, 10].Value2.ToString(),
                        Email = xlRange.Cells[i, 8].Value2.ToString(),
                        PhoneNumber = xlRange.Cells[i, 7].Value2.ToString()
                    },
                    IdentityInfo = new IdentityInfo()
                    {
                        IdentityNumber = xlRange.Cells[i, 11].Value2.ToString(),
                        DateOfIssue = DateTime.Now,
                        PlaceOfIssue = "Việt Nam"
                    }
                };

                var student = new Student()
                {
                    UserInfo = user,
                    IdentificationNumber = xlRange.Cells[i, 2].Value2.ToString(),
                    HightSchoolName = "THPT",
                    ElectionTypeId = 1,
                    YouthGroupInfo = null,
                    CircumstanceTypeId = 1,
                    EnrollmentAreaId = Convert.ToInt32(xlRange.Cells[i, 9].Value2.ToString()),
                    ClassId = Convert.ToInt32(xlRange.Cells[i, 1].Value2.ToString()),
                    PersonalInfo = new PersonalInfo()
                    {
                        EthnicId = 1,
                        NationalityId = 1,
                        ReligionId = 1,
                        PermanentResidence = xlRange.Cells[i, 10].Value2.ToString()
                    },
                };

                var account = new Account()
                {
                    UserInfo = user,
                    AccountGroupId = 2,
                    Token = "",
                    UserName = xlRange.Cells[i, 2].Value2.ToString(),
                    Password = FunctionCommon.GetMd5(FunctionCommon.GetSimpleMd5(xlRange.Cells[i, 2].Value2.ToString()))
                };

                context.Accounts.Add(account);
                context.Students.Add(student);
            }

            context.SaveChanges();
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

        public void addDocumentForStudent()
        {
            DataContext context = new DataContext();
            var students = context.Students.Where(x => !x.DelFlag).Select(x => x).ToList();
            var documentTypes = context.DocumentTypes.Where(x => !x.DelFlag).Select(x => x).ToList();
            foreach (var student in students)
            {
                foreach (var doc in documentTypes)
                {
                    student.Documents.Add(new Document()
                    {
                        StatusId = 1,
                        DocumentTypeId = doc.Id
                    });
                }
            }
            context.SaveChanges();
        }
    }
}
