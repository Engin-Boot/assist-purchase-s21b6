using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace SQLiteOps
{
    public class ProductsProvider
    {
        #region ctor

        public ProductsProvider(string filePath)
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
                        var description = new Description
                        {
                            ProductId = result.GetString(0),
                            ModelNumber = result.GetString(1),
                            ProductName = result.GetString(2),
                            IsCeCertified = result.GetBoolean(7),
                            Weight = result.GetDouble(6),
                            HasHandle = result.GetBoolean(8),
                            IsTouchScreen = result.GetBoolean(9),
                            HasBattery = result.GetBoolean(10),
                            ScreenType = result.GetString(11)
                        };
                        if (description.ProductDimensions != null)
                        {
                            description.ProductDimensions.Height = result.GetDouble(3);
                            description.ProductDimensions.Length = result.GetDouble(4);
                            description.ProductDimensions.Width = result.GetDouble(5);
                        }


                        dict.Add(description.ProductId, description);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw (new FileNotFoundException("Database not found"));
                }

                finally
                {
                    CloseDb();
                }
            }

            return dict;
        }

        public static string GetDbPath()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dbPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\Products.db"));
            return dbPath;
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

    }
}
