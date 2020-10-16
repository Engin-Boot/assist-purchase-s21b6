using System;
using System.Collections.Generic;

namespace Init
{
    public class Init
    {
        Dictionary<string, Description> ProductDescription { get; set; }
        public Init()
        {
            var filePath = GetExcelFilePath();
            Reader = new ExcelReader(filePath);
            ProductDescription = GetProductsFromExcel();
        }

        public Dictionary<string, Description> GetDs()
        {
            return ProductDescription;
        }

        private Dictionary<string, Description> GetProductsFromExcel()
        {
            Reader.SetExcelSheetNumber(1);
            _numberOfRows = Reader.GetNumberOfRowsInSheet();
            var products = new Dictionary<string, Description>();
            for (int i = 2; i <= _numberOfRows; i++)
            {
                var oneProduct = GetOneProductFromExcel(i);
                if (oneProduct != null)
                    products.Add(oneProduct.ProductId, oneProduct);
            }
            Reader.CloseWorkBook();
            return products;
        }

        private Description GetOneProductFromExcel(int rowNumber)
        {
            Description description = new Description();
            if (Reader.ReadCell(rowNumber, 13).Equals("No", StringComparison.InvariantCultureIgnoreCase))
            {
                description.ProductId = Reader.ReadCell(rowNumber, 1);
                description.ModelNumber = Reader.ReadCell(rowNumber, 2);
                description.ProductName = Reader.ReadCell(rowNumber, 3);
                description.Dimensions.Height = Convert.ToDouble(Reader.ReadCell(rowNumber, 4));
                description.Dimensions.Length = Convert.ToDouble(Reader.ReadCell(rowNumber, 5));
                description.Dimensions.Width = Convert.ToDouble(Reader.ReadCell(rowNumber, 6));
                description.Weight = Convert.ToDouble(Reader.ReadCell(rowNumber, 7));
                description.IsCeCertified = Convert.ToBoolean(Reader.ReadCell(rowNumber, 8));
                description.HasHandle = Convert.ToBoolean(Reader.ReadCell(rowNumber, 9));
                description.IsTouchScreen = Convert.ToBoolean(Reader.ReadCell(rowNumber, 10));
                description.ScreenType = Reader.ReadCell(rowNumber, 11);
                description.HasBattery = Convert.ToBoolean(Reader.ReadCell(rowNumber, 12));
                return description;
            }
            else
            {
                return null;
            }
        }
        private static string GetExcelFilePath()
        {
            const string fileName = @"Products.xlsx";
            var filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;
            return filePath;
        }

        private ExcelReader Reader { get; set; }
        private int _numberOfRows;

    }
}
