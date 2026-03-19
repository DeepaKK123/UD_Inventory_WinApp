using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using U2.Data.Client;
using Microsoft.Extensions.Configuration;

namespace UD_MV_DataHandler
{
    public partial class UD_MultiValue_Data_Frm : Form
    {
        public UD_MultiValue_Data_Frm()
        {
            InitializeComponent();
        }

        private static IConfigurationRoot LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            return builder.Build();
        }

        private U2Connection GetUniDataConnection()
        {
            var config = LoadConfiguration();
            string connectionString = config.GetConnectionString("UniData");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string for 'UniData' is not configured.");
            }

            var conn = new U2Connection(connectionString);
            conn.Open();
            return conn;
        }

        private DataTable GetOrders(string orderId = null)
        {

            using (var conn = GetUniDataConnection())
            {
                string query = "SELECT ID, ORD_DATE, CLIENT_NO, PRODUCT_NO, COLOR, QTY, PRICE FROM ORDERS";
                if (!string.IsNullOrEmpty(orderId))
                    query += $" WHERE ID = '{orderId}'";
                           


                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    DataSet ds = new DataSet();
                    U2DataAdapter da = new U2DataAdapter(cmd);
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];

                    DataTable flatTable = new DataTable();
                    flatTable.Columns.Add("OrderID");
                    flatTable.Columns.Add("OrderDate");
                    flatTable.Columns.Add("CustomerNo");
                    flatTable.Columns.Add("ProductID");
                    flatTable.Columns.Add("Color");
                    flatTable.Columns.Add("Quantity");
                    flatTable.Columns.Add("Price");

                    char VM = (char)253;
                    foreach (DataRow row in dt.Rows)
                    {
                        string orderID = row["ID"].ToString();
                        string orderDate = row["ORD_DATE"].ToString();
                        string customerNo = row["CLIENT_NO"].ToString();

                        // Add parent row (order-level)
                        flatTable.Rows.Add(orderID, orderDate, customerNo, "", "", "","");

                        string[] product_list = row["PRODUCT_NO"].ToString().Split(VM);
                        string[] color_list = row["COLOR"].ToString().Split(VM);
                        string[] qty_list = row["QTY"].ToString().Split(VM);
                        string[] price_list = row["PRICE"].ToString().Split(VM);

                        int maxCount = new[] { product_list.Length, color_list.Length, qty_list.Length }.Max();

                        for (int i = 0; i < maxCount; i++)
                        {
                            string productId = i < product_list.Length ? product_list[i] : string.Empty;
                            string color = i < color_list.Length ? color_list[i] : string.Empty;
                            string qty = i < qty_list.Length ? qty_list[i] : string.Empty;
                            string price = i < price_list.Length ? price_list[i] : string.Empty;

                            // Add child row (product-level), indent order columns for visual effect
                            flatTable.Rows.Add("   ", "", "", productId, color, qty,price);
                        }
                    }



                    return flatTable;
                }
            }

        }


        private DataTable SearchClients(string searchTerm)
        {
            using (var conn = GetUniDataConnection())
            {
                string query = $"SELECT * FROM CLIENTS WHERE ID = '{searchTerm}'";
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    var adapter = new U2DataAdapter(cmd as U2Command);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    DataTable flatTable = new DataTable();
                    flatTable.Columns.Add("ClientID");
                    flatTable.Columns.Add("Company");
                    flatTable.Columns.Add("FirstName");
                    flatTable.Columns.Add("LastName");
                    flatTable.Columns.Add("Address");
                    flatTable.Columns.Add("City");
                    flatTable.Columns.Add("State");
                    flatTable.Columns.Add("Country");
                    flatTable.Columns.Add("PhoneNum");
                    flatTable.Columns.Add("PhoneType");

                    char VM = (char)253;

                    foreach (DataRow row in dt.Rows)
                    {
                        string clientId = row["ID"].ToString();
                        string company = row["COMPANY"].ToString();
                        string fname = row["FNAME"].ToString();
                        string lname = row["LNAME"].ToString();
                        string address = row["ADDRESS"].ToString();
                        string city = row["CITY"].ToString();
                        string state = row["STATE"].ToString();
                        string country = row["COUNTRY"].ToString();

                        // Add parent row (client-level)
                        flatTable.Rows.Add(clientId, company, fname, lname, address, city, state, country, "", "");

                        string[] phoneNumList = row["PHONE_NUM"].ToString().Split(VM);
                        string[] phoneTypeList = row["PHONE_TYPE"].ToString().Split(VM);
                        int maxCount = Math.Max(phoneNumList.Length, phoneTypeList.Length);

                        for (int i = 0; i < maxCount; i++)
                        {
                            string phoneNum = i < phoneNumList.Length ? phoneNumList[i] : string.Empty;
                            string phoneType = i < phoneTypeList.Length ? phoneTypeList[i] : string.Empty;

                            // Add child row (phone-level), indent client columns for visual effect
                            flatTable.Rows.Add("   ", "", "", "", "", "", "", "", phoneNum, phoneType);
                        }
                    }

                    return flatTable;
                }
            }
        }

        private DataTable GetInventory(string productId = null)
        {
            using (var conn = GetUniDataConnection())
            {
                string query = "SELECT ID, PROD_NAME, FEATURES, INV_DATE, INV_TIME, COLOR, PRICE, QTY, REORDER FROM INVENTORY";
                if (!string.IsNullOrEmpty(productId))
                    query += $" WHERE ID = '{productId}'";

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    var adapter = new U2DataAdapter(cmd as U2Command);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    DataTable flatTable = new DataTable();
                    flatTable.Columns.Add("ProductID");
                    flatTable.Columns.Add("ProductName");
                    flatTable.Columns.Add("Features");
                    flatTable.Columns.Add("InventoryDate");
                    flatTable.Columns.Add("InventoryTime");
                    flatTable.Columns.Add("Color");
                    flatTable.Columns.Add("Price");
                    flatTable.Columns.Add("Quantity");
                    flatTable.Columns.Add("ReOrder");

                    char VM = (char)253;

                    foreach (DataRow row in dt.Rows)
                    {
                        string productID = row["ID"].ToString();
                        string productName = row["PROD_NAME"].ToString();
                        string features = row["FEATURES"].ToString();
                        string invDate = row["INV_DATE"].ToString();
                        string invTime = row["INV_TIME"].ToString();

                        // Add parent row (inventory-level)
                        flatTable.Rows.Add(productID, productName, features, invDate, invTime, "", "", "", "");

                        string[] colorList = row["COLOR"].ToString().Split(VM);
                        string[] priceList = row["PRICE"].ToString().Split(VM);
                        string[] qtyList = row["QTY"].ToString().Split(VM);
                        string[] reorderList = row["REORDER"].ToString().Split(VM);

                        int maxCount = new[] { colorList.Length, priceList.Length, qtyList.Length, reorderList.Length }.Max();

                        for (int i = 0; i < maxCount; i++)
                        {
                            string color = i < colorList.Length ? colorList[i] : string.Empty;
                            string price = i < priceList.Length ? priceList[i] : string.Empty;
                            string qty = i < qtyList.Length ? qtyList[i] : string.Empty;
                            string reorder = i < reorderList.Length ? reorderList[i] : string.Empty;

                            // Add child row (line-item), indent inventory columns for visual effect
                            flatTable.Rows.Add("   ", "", "", "", "", color, price, qty, reorder);
                        }
                    }

                    return flatTable;
                }
            }
        }

        private void btnLoadOrders_Click(object sender, EventArgs e)
        {
            string orderId = txtOrderId.Text.Trim();
            dgvOrders.DataSource = GetOrders(orderId);
            // For GET.ORDER.DETAILS
            // var (orderOutput, orderStatus) = CallUniBasicSubroutine("GET.ORDER.DETAILS", "ORDER789");
        }

        private void btnSearchClients_Click(object sender, EventArgs e)
        {
            string searchTerm = txtClientSearch.Text.Trim();
            dgvClients.DataSource = SearchClients(searchTerm);
            // For GET.CUSTOMER.INFO
            //var (customerOutput, customerStatus) = CallUniBasicSubroutine("GET.CUSTOMER.INFO", "CUST456");
        }

        private void btnLoadInventory_Click(object sender, EventArgs e)
        {
            string searchTerm = txtInventorySearch.Text.Trim();
            dgvInventory.DataSource = GetInventory(searchTerm);

            // For CHECK.INVENTORY
            // string searchTerm = txtInventorySearch.Text.Trim();
            //var (inventoryOutput, inventoryStatus) = CallUniBasicSubroutine("CHECK.INVENTORY", searchTerm);

        }


        private (string OutputData, string Status) CallUniBasicSubroutine(string subroutineName, string inputData)
        {
            using (var conn = GetUniDataConnection())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = subroutineName;

                // UniObjects for .NET uses positional parameters for subroutines
                var inputParam = cmd.CreateParameter();
                inputParam.Direction = ParameterDirection.Input;
                inputParam.Value = inputData;

                var outputParam = cmd.CreateParameter();
                outputParam.Direction = ParameterDirection.Output;
                outputParam.Size = 4000; // Adjust size as needed

                var statusParam = cmd.CreateParameter();
                statusParam.Direction = ParameterDirection.Output;
                statusParam.Size = 100; // Adjust size as needed

                cmd.Parameters.Add(inputParam);
                cmd.Parameters.Add(outputParam);
                cmd.Parameters.Add(statusParam);

                cmd.ExecuteNonQuery();

                string outputData = outputParam.Value?.ToString() ?? string.Empty;
                string status = statusParam.Value?.ToString() ?? string.Empty;

                return (outputData, status);
            }
        }
    }
}
