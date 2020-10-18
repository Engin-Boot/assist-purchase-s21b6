using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SQLiteOps
{
    public class ProductsFromDb
    {
        #region ctor

        public ProductsFromDb(string filePath)
        {
            var connectionPath = @"URI=file:" + filePath;
            try
            {
                _dbConnection = new SQLiteConnection(connectionPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        #endregion

        #region PublicMethods
        public Dictionary<string, Description> GetAllProductsFromDb()
        {
            _dbConnection.Open();
            var dict = new Dictionary<string, Description>();
            using (var command = _dbConnection.CreateCommand())
            {
                try
                {
                    command.CommandText = "Select * from Products;";
                    command.Prepare();
                    command.ExecuteNonQuery();

                    var result = command.ExecuteReader();
                    var hasRows = result.HasRows;
                    if (!hasRows)
                        return null;
                    while (result.Read())
                    {
                        var description = new Description();
                        description.ProductId = result.GetString(0);
                        description.ModelNumber = result.GetString(1);
                        description.ProductName = result.GetString(2);
                        description.ProductDimensions.Height = result.GetDouble(3);
                        description.ProductDimensions.Length = result.GetDouble(4);
                        description.ProductDimensions.Width = result.GetDouble(5);
                        description.Weight = result.GetDouble(6);
                        description.IsCeCertified = result.GetBoolean(7);
                        description.HasHandle = result.GetBoolean(8);
                        description.IsTouchScreen = result.GetBoolean(9);
                        description.HasBattery = result.GetBoolean(10);
                        description.ScreenType = result.GetString(11);

                        dict.Add(description.ProductId, description);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                finally
                {
                    CloseDb();
                }
            }

            return dict;
        }
        #endregion

        #region PrivateMethods
        private void CloseDb()
        {
            _dbConnection.Close();
        }
        #endregion

        #region PrivateVariables
        private readonly SQLiteConnection _dbConnection;
        #endregion


        #region Main

        public static void Main()
        {

        }

        #endregion
    }
}
