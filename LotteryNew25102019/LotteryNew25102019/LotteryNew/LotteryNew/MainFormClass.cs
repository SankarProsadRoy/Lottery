using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LotteryNew
{
    class MainFormClass
    {
        private string conString;
        private SqlConnection theConnection;
        private SqlCommand theCommand;
        private SqlDataAdapter theAdapter;

        public MainFormClass(string con)
        {
            conString = con;
        }

        public DataTable getallPrize()
        {
            DataTable prize;
            // Connection.
            theConnection = new SqlConnection();
            theConnection.ConnectionString = conString;

            // Command.
            theCommand = new SqlCommand();
            theCommand.Connection = theConnection;
            theCommand.CommandText = "SELECT distinct Prize_ID FROM Prize_List where Coupon_No is null order by Prize_ID";
            theCommand.CommandType = CommandType.Text;

            // Adapter.
            theAdapter = new SqlDataAdapter();
            theAdapter.SelectCommand = theCommand;

            // Datatable.
            prize = new DataTable();
            theAdapter.Fill(prize); // Fill data into data table.

            // Clean up.
            theConnection.Dispose();
            theCommand.Dispose();
            theAdapter.Dispose();

            return prize;
        }
        public DataTable GetSelectedPrize(string p_id)
        {
            DataTable prize;
            // Connection.
            theConnection = new SqlConnection();
            theConnection.ConnectionString = conString;

            // Command.
            theCommand = new SqlCommand();
            theCommand.Connection = theConnection;
            theCommand.CommandText = "SELECT * FROM Prize_List where  Status is null and Prize_ID='" + p_id + "'";
            theCommand.CommandType = CommandType.Text;

            // Adapter.
            theAdapter = new SqlDataAdapter();
            theAdapter.SelectCommand = theCommand;

            // Datatable.
            prize = new DataTable();
            theAdapter.Fill(prize); // Fill data into data table.

            // Clean up.
            theConnection.Dispose();
            theCommand.Dispose();
            theAdapter.Dispose();

            return prize;
        }

        public DataTable GetSelectCoupon(string C_id)
        {
            DataTable prize;
            // Connection.
            theConnection = new SqlConnection();
            theConnection.ConnectionString = conString;

            // Command.
            theCommand = new SqlCommand();
            theCommand.Connection = theConnection;
            //theCommand.CommandText = "SELECT * FROM Prize_List where  Status is null and Prize_ID='" + p_id + "'";

            theCommand.CommandText = "SELECT * FROM Coupon_ListDetails where COUPON_NO not in(select COUPON_NO from Prize_List where COUPON_NO is not null) and COUPON_NO='" + C_id + "' ";
            theCommand.CommandType = CommandType.Text;

            // Adapter.
            theAdapter = new SqlDataAdapter();
            theAdapter.SelectCommand = theCommand;

            // Datatable.
            prize = new DataTable();
            theAdapter.Fill(prize); // Fill data into data table.

            // Clean up.
            theConnection.Dispose();
            theCommand.Dispose();
            theAdapter.Dispose();

            return prize;
        }

        public DataTable GetCoupons()
        {
            DataTable prize;
            // Connection.
            theConnection = new SqlConnection();
            theConnection.ConnectionString = conString;

            // Command.
            theCommand = new SqlCommand();
            theCommand.Connection = theConnection;
            theCommand.CommandText = "SELECT * FROM Coupon_ListDetails where COUPON_NO not in(select COUPON_NO from Prize_List where COUPON_NO is not null) ";
            theCommand.CommandType = CommandType.Text;

            // Adapter.
            theAdapter = new SqlDataAdapter();
            theAdapter.SelectCommand = theCommand;

            // Datatable.
            prize = new DataTable();
            theAdapter.Fill(prize); // Fill data into data table.

            // Clean up.
            theConnection.Dispose();
            theCommand.Dispose();
            theAdapter.Dispose();

            return prize;
        }
        //ExcelData
        public DataTable ExcelData()
        {
            DataTable prize;
            // Connection.
            theConnection = new SqlConnection();
            theConnection.ConnectionString = conString;

            // Command.
            theCommand = new SqlCommand();
            theCommand.Connection = theConnection;
            theCommand.CommandText = "SELECT b.Prize_ID ,b.Prize_Name, a.COUPON_NO,a.FIRST_NAME,a.LAST_NAME,a.DEPARTMENT,a.LOCATION,a.COMPANY_GROUP_NAME from Coupon_ListDetails a,Prize_List b where a.COUPON_NO=b.coupon_no order by b.Prize_ID,a.COUPON_NO ";
            theCommand.CommandType = CommandType.Text;

            // Adapter.
            theAdapter = new SqlDataAdapter();
            theAdapter.SelectCommand = theCommand;

            // Datatable.
            prize = new DataTable();
            theAdapter.Fill(prize); // Fill data into data table.

            // Clean up.
            theConnection.Dispose();
            theCommand.Dispose();
            theAdapter.Dispose();

            return prize;
        }

        ///Insert_UpdateMessage
        ///
        public int Insert_UpdateMessage(string id,string cpn_no)
        {
            int flag = 0;
            try
            {
                // Connection.
                theConnection = new SqlConnection();
                if (conString != "")
                {
                    theConnection.ConnectionString = conString;
                    theConnection.Open();
                }

                // Command.
                theCommand = new SqlCommand();
                theCommand.Connection = theConnection;


                theCommand.CommandText = "update Prize_List set Status='Selected' ,Coupon_No='"+cpn_no+"' where Prize_Unique_ID='" + id + "'";
                theCommand.ExecuteNonQuery(); // Execute insert query.  
                flag = 1;
            }

            catch
            {
                return flag;
            }

            return flag;
        }
    }
}
