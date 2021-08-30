using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;


namespace WebApplicationAPI
{
    class readExel
    {

        public string Path { get; set; }
        public void read() {
            _Application excel = new _Excel.Application();
            _Workbook wb;
            Worksheet ws;
            //wb = excel.Workbooks.Open(Path);
            //ws = (Worksheet)wb.Worksheets[1];


            // initialize the Excel Application class
            _Excel.ApplicationClass app = new ApplicationClass();
            // create the workbook object by opening the excel file.
            _Excel.Workbook workBook = app.Workbooks.Open(Path,
                                                         0,
                                                         true,
                                                         5,
                                                         "",
                                                         "",
                                                         true,
                                                         _Excel.XlPlatform.xlWindows,
                                                         "\t",
                                                         false,
                                                         false,
                                                         0,
                                                         true,
                                                         1,
                                                         0);
            // get the active worksheet using sheet name or active sheet
            _Excel.Worksheet workSheet = (_Excel.Worksheet)workBook.ActiveSheet;
            int index = 0; // This row,column index should be changed as per your need.
                           // i.e. which cell in the excel you are interesting to read.
            object rowIndex = 2;
            object colIndex1 = 1;
            object colIndex2 = 2;
            try
            {
                while (((_Excel.Range)workSheet.Cells[rowIndex, 1]).Value2 != null)
                {
                    
                    rowIndex = 2 + index;


                    if (((_Excel.Range)workSheet.Cells[rowIndex, 9]).Value2 == null)
                    {

                        ((_Excel.Range)workSheet.Rows[rowIndex, Type.Missing]).Delete(XlDeleteShiftDirection.xlShiftUp);

                       /// workBook.Save();
                        //workBook.Close(false);
                        //workBook.Application.Quit();
                        //_Excel.Range cells = (_Excel.Range)workSheet.Range["A1", Type.Missing];
                        //_Excel.Range del = cells.EntireRow;
                        //del.Delete();

                    }
                   
                    index++;
                }
            }
            catch (Exception ex)
            {
                app.Quit();
                Console.WriteLine(ex.Message);
            }
        }
        public readExel(string Path)
        {
            this.Path = Path;
              
            }
        }
    }
