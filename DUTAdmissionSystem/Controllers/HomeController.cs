using DUTAdmissionSystem.Commons;
using DUTAdmissionSystem.NewDatabase;
using DUTAdmissionSystem.NewDatabase.Schema.Entity;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;

namespace DUTAdmissionSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        private void TestFileExcel(string envoiceFilePath, string docsFilePath)
        {
            FileInfo envoiceFile = new FileInfo(Server.MapPath("~/App_Resources/Data/Envoice.xlsx"));
            using (ExcelPackage package = new ExcelPackage(envoiceFile))
            {
                package.SaveAs(new FileInfo(Server.MapPath(envoiceFilePath)));
            }
            FileInfo docsFile = new FileInfo(Server.MapPath("~/App_Resources/Data/AdmittedDocs.xlsx"));
            using (ExcelPackage package = new ExcelPackage(docsFile))
            {
                package.SaveAs(new FileInfo(Server.MapPath(docsFilePath)));
            }

        }

        public void ImportSinhVien()
        {
            DataContext context = new DataContext();

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:/Users/Aiden/Documents/DUTAdmission/resources/DUTAdmission.Backend/DUTAdmissionSystem/App_Resources/Data/TuyenThang.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 2; i <= 106; i++)
            {
                var user = new UserInfo()
                {
                    FirstName = xlRange.Cells[i, 2].Value2.ToString(),
                    LastName = xlRange.Cells[i, 1].Value2.ToString(),
                };

                var student = new Student()
                {
                    UserInfo = user,
                    IdentificationNumber = xlRange.Cells[i, 4].Value2.ToString(),
                    ElectionTypeId = 1,
                    CircumstanceTypeId = 1,
                    EnrollmentAreaId = Convert.ToInt32(xlRange.Cells[i, 9].Value2.ToString()),
                    ClassId = Convert.ToInt32(xlRange.Cells[i, 1].Value2.ToString())
                };

                var account = new Account()
                {
                    UserInfo = user,
                    AccountGroupId = 2,
                    UserName = xlRange.Cells[i, 4].Value2.ToString(),
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