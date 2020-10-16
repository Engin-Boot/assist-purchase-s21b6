using Microsoft.Office.Interop.Excel;

namespace Init
{
    public class ExcelReader
    {
        private readonly bool _hasInit;
        public ExcelReader(string fileName)
        {
            _excelApplication = new Application();
            _wb = _excelApplication.Workbooks.Open(fileName);
            _hasInit = true;
        }
        public string ReadCell(int i, int j)
        {
            string cellData;
            cellData = _ws.Cells[i, j].Value.ToString();
            if (cellData == null || cellData == "")
            {
                return "";
            }
            else
            {
                return cellData;
            }
        }
        public void CloseWorkBook()
        {
            _wb.Close();
            _excelApplication.Quit();
        }

        public int GetNumberOfRowsInSheet()
        {
            var range = _ws.UsedRange;
            return range.Rows.Count;
        }

        public int GetNumberOfColumnsInSheet()
        {
            var range = _ws.UsedRange;
            return range.Columns.Count;
        }

        public void SetExcelSheetNumber(int sheetNumber)
        {
            // ReSharper disable once RedundantBoolCompare
            if (_hasInit == true)
            {
                _ws = _wb.Worksheets[sheetNumber];
            }
        }

        private readonly _Application _excelApplication;
        private readonly Workbook _wb;
        private Worksheet _ws;
    }
}