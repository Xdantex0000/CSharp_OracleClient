using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace BDLab3_4
{
class Program
    {
        // Declaring Stage zone
        public static int Counter = 1;

        public static List<OVD> Ovd_List = new List<OVD>();

        public static List<Data> Data_List = new List<Data>();

        public static List<Series> Series_List = new List<Series>();

        public static List<Status> Status_List = new List<Status>();

        public static List<Types> Types_List = new List<Types>();

        // Declaring methods for adding data to Stage zone
        static void GetOVDLists(List<Stage_zone> In_List)
        {
            List<string> TempList = new List<string>();
            OVD TempOvd = new OVD();

            foreach (var item in In_List)
            {
                TempList.Add(item.OVD);
            }
            foreach (var item in TempList.Distinct())
            {
                TempOvd.ID_OVD = Counter.ToString();
                TempOvd.OVD_DATA = item;
                Ovd_List.Add(TempOvd);
                TempOvd = new OVD();
                Counter++;
            }
            Counter=1;
        }
        static void GetSeriesLists(List<Stage_zone> In_List)
        {
            List<string> TempList = new List<string>();
            Series TempOvd = new Series();

            foreach (var item in In_List)
            {
                TempList.Add(item.D_SERIES);
            }
            foreach (var item in TempList.Distinct())
            {
                TempOvd.ID_D_SERIES = Counter.ToString();
                TempOvd.D_SERIES = item;
                Series_List.Add(TempOvd);
                TempOvd = new Series();
                Counter++;
            }
            Counter = 1;
        }
        static void GetStatusLists(List<Stage_zone> In_List)
        {
            List<string> TempList = new List<string>();
            Status TempOvd = new Status();

            foreach (var item in In_List)
            {
                TempList.Add(item.D_STATUS);
            }
            foreach (var item in TempList.Distinct())
            {
                TempOvd.ID_D_STATUS = Counter.ToString();
                TempOvd.D_STATUS = item;
                Status_List.Add(TempOvd);
                TempOvd = new Status();
                Counter++;
            }
            Counter = 1;
        }
        static void GetDataLists(List<Stage_zone> In_List)
        {
            Data TempOvd = new Data();

            foreach (var item in In_List)
            {
                TempOvd.ID_DATA = Counter.ToString();
                TempOvd.INSERT_DATE = item.INSERT_DATE;
                TempOvd.THEFT_DATA = item.THEFT_DATA;
                Data_List.Add(TempOvd);
                TempOvd = new Data();
                Counter++;
            }
            Counter = 1;
        }
        static void GetTypesLists(List<Stage_zone> In_List)
        {
            List<string> TempList = new List<string>();
            Types TempOvd = new Types();

            foreach (var item in In_List)
            {
                TempList.Add(item.D_TYPE);
            }
            foreach (var item in TempList.Distinct())
            {
                TempOvd.ID_D_TYPE = Counter.ToString();
                TempOvd.D_TYPE = item;
                Types_List.Add(TempOvd);
                TempOvd = new Types();
                Counter++;
            }
            Counter = 1;
        }
        static void Main(string[] args)
        {
            int ID_Check = 0;
            string Json_Data;
            List<Stage_zone> myNewObject = new List<Stage_zone>();
            
            // Reading JSON File
            using (StreamReader sr = new StreamReader(@"mvswantedpassport.json"))
            {
                Json_Data = sr.ReadToEnd();
            }
            try
            {
                // Deserializing from JSON to List<Stage_zone>
                myNewObject = JsonConvert.DeserializeObject<List<Stage_zone>>(Json_Data);

                // Add user id, password, and data source
                string conString = "User Id=TASK2;Password=OLAP;Data Source=DESKTOP-7MDILIE;";

                // Connect and open a database connection
                OracleConnection con = new OracleConnection(conString);
                con.Open();
                // Reading data to stage zone
                GetOVDLists(myNewObject);
                GetDataLists(myNewObject);
                GetStatusLists(myNewObject);
                GetTypesLists(myNewObject);
                GetSeriesLists(myNewObject);
                //// Inserting data to main storage
                //#region OVD
                //// OVD adding
                //foreach (var item in Ovd_List)
                //{
                //    OracleCommand cmd = con.CreateCommand();
                //    cmd.CommandText = "INSERT INTO OVD (ID_OVD, OVD) VALUES (:pID_OVD, :pOVD)";
                //    cmd.CommandType = CommandType.Text;

                //    cmd.Parameters.Add(":pID_OVD", OracleDbType.Varchar2, item.ID_OVD, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pOVD", OracleDbType.Varchar2, item.OVD_DATA, ParameterDirection.Input);

                //    cmd.ExecuteNonQuery();
                //    cmd.Cancel();
                //}
                //#endregion
                //#region Status
                //// Status adding
                //foreach (var item in Status_List)
                //{
                //    OracleCommand cmd = con.CreateCommand();
                //    cmd.CommandText = "INSERT INTO Status (ID_D_STATUS, D_STATUS) VALUES (:pID_D_STATUS, :pD_STATUS)";
                //    cmd.CommandType = CommandType.Text;

                //    cmd.Parameters.Add(":pID_D_STATUS", OracleDbType.Varchar2, item.ID_D_STATUS, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pD_STATUS", OracleDbType.Varchar2, item.D_STATUS, ParameterDirection.Input);

                //    cmd.ExecuteNonQuery();
                //    cmd.Cancel();
                //}
                //#endregion
                //#region Types
                //// Types adding
                //foreach (var item in Types_List)
                //{
                //    OracleCommand cmd = con.CreateCommand();
                //    cmd.CommandText = "INSERT INTO Types (ID_D_TYPE, D_TYPE) VALUES (:pID_D_TYPE, :pD_TYPE)";
                //    cmd.CommandType = CommandType.Text;

                //    cmd.Parameters.Add(":pID_D_TYPE", OracleDbType.Varchar2, item.ID_D_TYPE, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pD_TYPE", OracleDbType.Varchar2, item.D_TYPE, ParameterDirection.Input);

                //    cmd.ExecuteNonQuery();
                //    cmd.Cancel();
                //}
                //#endregion
                //#region Data
                //// Data adding
                //foreach (var item in Data_List)
                //{
                //    if (item.ID_DATA == "10000") break;
                //    OracleCommand cmd = con.CreateCommand();
                //    cmd.CommandText = "INSERT INTO Data (ID_DATA, THEFT_DATA, INSERT_DATA) VALUES (:pID_DATA, :pTHEFT_DATA, :pINSERT_DATA)";
                //    cmd.CommandType = CommandType.Text;

                //    cmd.Parameters.Add(":pID_DATA", OracleDbType.Varchar2, item.ID_DATA, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pTHEFT_DATA", OracleDbType.Varchar2, item.THEFT_DATA, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pINSERT_DATA", OracleDbType.Varchar2, item.INSERT_DATE, ParameterDirection.Input);

                //    cmd.ExecuteNonQuery();
                //    cmd.Cancel();
                //}
                //#endregion
                //#region Series
                //// Series adding
                //foreach (var item in Series_List)
                //{
                //    OracleCommand cmd = con.CreateCommand();
                //    cmd.CommandText = "INSERT INTO Series (ID_D_SERIES, D_SERIES) VALUES (:pID_D_SERIES, :pD_SERIES)";
                //    cmd.CommandType = CommandType.Text;

                //    cmd.Parameters.Add(":pID_D_SERIES", OracleDbType.Varchar2, item.ID_D_SERIES, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pD_SERIES", OracleDbType.Varchar2, item.D_SERIES, ParameterDirection.Input);

                //    cmd.ExecuteNonQuery();
                //    cmd.Cancel();
                //}
                //#endregion
                //#region MainTable
                //// Adding the main table
                //foreach (var item in myNewObject)
                //{
                //    if (Counter == 10000) break;
                //    OracleCommand cmd = con.CreateCommand();
                //    cmd.CommandText = "INSERT INTO PASPORT_LOST_1 (ID, ID_OVD, ID_D_SERIES, D_NUMBER, ID_D_TYPE, ID_D_STATUS, ID_DATA) VALUES (:1, :2, :3, :4, :5, :6, :7)";
                //    cmd.CommandType = CommandType.Text;

                //    cmd.Parameters.Add("1", OracleDbType.Varchar2, item.ID, ParameterDirection.Input);
                //    foreach (var temp in Ovd_List) {
                //        if (temp.OVD_DATA == item.OVD)
                //        {
                //            cmd.Parameters.Add("2", OracleDbType.Varchar2, temp.ID_OVD, ParameterDirection.Input);
                //            break;
                //        }
                //    }
                //    foreach (var temp in Series_List)
                //    {
                //        if (temp.D_SERIES == item.D_SERIES)
                //        {
                //            cmd.Parameters.Add("3", OracleDbType.Varchar2, temp.ID_D_SERIES, ParameterDirection.Input);
                //            break;
                //        }
                //    }
                //    cmd.Parameters.Add("4", item.D_NUMBER);
                //    foreach (var temp in Types_List)
                //    {
                //        if (temp.D_TYPE == item.D_TYPE)
                //        {
                //            cmd.Parameters.Add("5", OracleDbType.Varchar2, "1", ParameterDirection.Input);
                //            break;
                //        }

                //    }
                //    foreach (var temp in Status_List)
                //    {
                //        if (temp.D_STATUS == item.D_STATUS)
                //        {
                //            cmd.Parameters.Add("6", OracleDbType.Varchar2, temp.ID_D_STATUS, ParameterDirection.Input);
                //            break;
                //        }
                //    }
                //    foreach (var temp in Data_List)
                //    {
                //        if (temp.THEFT_DATA == item.THEFT_DATA)
                //        {
                //            cmd.Parameters.Add("7", temp.ID_DATA);
                //            break;
                //        }
                //    }
                //    Counter++;
                //    cmd.ExecuteNonQuery();
                //}
                //Counter = 1;
                //#endregion

                //// Test JSON Insert
                //foreach (var item in myNewObject)
                //{
                //    if (ID_Check == 10000) break;
                //    // Insert JSON data into database
                //    OracleCommand cmd = con.CreateCommand();
                //    cmd.CommandText = "INSERT INTO PASPORT_LOST_1 (ID) " +
                //                                          "VALUES (:pID)";
                //    cmd.CommandType = CommandType.Text;
                //    cmd.Parameters.Add(":pID", OracleDbType.Varchar2, item.ID, ParameterDirection.Input);
                //    cmd.ExecuteNonQuery();
                //    ID_Check++;
                //}

                //// Default Insert
                //foreach (var item in myNewObject)
                //{
                //    if (ID_Check == 10000) break;
                //    // Insert JSON data into database
                //    OracleCommand cmd = con.CreateCommand();
                //    cmd.CommandText = "INSERT INTO PASPORT_LOST_1 (ID, OVD, D_SERIES, D_NUMBER, D_TYPE, D_STATUS, THEFT_DATA, INSERT_DATE) " +
                //                                          "VALUES (:pID, :pOVD, :pD_SERIES, :pD_NUMBER, :pD_TYPE, :pD_STATUS, :pTHEFT_DATA, :pINSERT_DATE)";
                //    cmd.CommandType = CommandType.Text;
                //    cmd.Parameters.Add(":pID", OracleDbType.Varchar2, item.ID, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pOVD", OracleDbType.Varchar2, item.OVD, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pD_SERIES", OracleDbType.Varchar2, item.D_SERIES, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pD_NUMBER", OracleDbType.Varchar2, item.D_NUMBER, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pD_TYPE", OracleDbType.Varchar2, item.D_TYPE, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pD_STATUS", OracleDbType.Varchar2, item.D_STATUS, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pTHEFT_DATA", OracleDbType.Varchar2, item.THEFT_DATA, ParameterDirection.Input);
                //    cmd.Parameters.Add(":pINSERT_DATE", OracleDbType.Varchar2, item.INSERT_DATE, ParameterDirection.Input);
                //    cmd.ExecuteNonQuery();
                //    ID_Check++;
                //}


                //Console.WriteLine("JSON inserted.");
                //Console.WriteLine();

                string Type_old = "Паспорт громадянина Росії";
                string Type = "ПАСПОРТ ГРОМАДЯНИНА УКРАЇНИ";
                // Query JSON from database
                OracleCommand cmd_main = con.CreateCommand();
                OracleCommand types_main = con.CreateCommand();

                cmd_main.CommandText = "Update Types set D_Type = :p1 Where D_Type = :p2";
                types_main.CommandText = "SELECT * FROM Types";

                cmd_main.Parameters.Add("1", Type);
                cmd_main.Parameters.Add("2", Type_old);

                cmd_main.ExecuteNonQuery();
                Console.WriteLine("Data Updated");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }




            //XDocument doc = XDocument.Load("XMLFile1.xml");

            //    Stage_zone.obls = doc.Descendants("OBL_NAME");
            //    Stage_zone.regions = doc.Descendants("REGION_NAME");
            //    Stage_zone.cities = doc.Descendants("CITY_NAME");
            //    Stage_zone.city_regions = doc.Descendants("CITY_REGION_NAME");
            //    Stage_zone.streets = doc.Descendants("STREET_NAME");

            //    foreach (var street in Stage_zone.streets) Console.WriteLine($"Street: {street.Value}");

            Console.ReadKey();

        }
    }
}
