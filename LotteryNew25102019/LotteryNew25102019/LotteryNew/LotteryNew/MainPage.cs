using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Reflection;

using System.IO;

namespace LotteryNew
{
    public partial class MainPage : Form
    {
        
        LotteryNew.MainFormClass DBConn = new MainFormClass(ConfigurationSettings.AppSettings["ConnectionString"].ToString());

        Image[] arr0 = new Image[10];
        int i0 = 0;
        int i1 = 0;
        int i2 = 0;
        int i3 = 0;
        int i4 = 0;

        int i0StopValue = 100;
        int i1StopValue = 100;
        int i2StopValue = 100;
        int i3StopValue = 100;
        int i4StopValue = 100;

        int iTempCouponNumber;
        public MainPage()
        {
            InitializeComponent();
            StartTimer();
            dropdownpopulate();
            
        }
        public static class couponno
        {
            public static string coupon;
        }
        public void dropdownpopulate()
        {
            DataTable dt = DBConn.getallPrize();
            DataRow dr = dt.NewRow();
            dr["Prize_ID"] = "--Select--";
            dt.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Prize_ID";
            comboBox1.ValueMember = "Prize_ID";
        }
        System.Windows.Forms.Timer t = null;
        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 10;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = DBConn.GetSelectedPrize(comboBox1.SelectedValue.ToString().Trim());
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["Prize_Name"] = "--Select--";
                dt.Rows.InsertAt(dr, 0);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Prize_Name";
                comboBox2.ValueMember = "Prize_Unique_ID";
            }
            else
            {
                comboBox2.DataSource = dt;
                //MessageBox.Show("COUPON SELECTION FOR THIS   PRIZE HAS BEEN COMPLETED");

            }
        }

        private void button1_Click(object sender, EventArgs e)

        {

            //Added on 01/11/2018
            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Please select First Dropdown ");
                comboBox1.Focus();
                return;

            }
            if (comboBox2.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Second Dropdown before start ");
                comboBox2.Focus();
                return;

            }

            button1.Enabled = false;

            dataGridView1.Visible = false;
            label1.Visible = false;
            activate_timers();


            //MessageBox.Show("Please Wait 30 seconds to get Result");
            DataTable dt = DBConn.GetCoupons();
            DataRow selectedWinner;
            DataTable dt2;
            int totalWinners = 1;
            Random rnd = new Random();
            dt2 = dt.Clone();
            for (int i = 1; i <= totalWinners; i++)
            {
                //Pick random datarow
                //DataRow selectedWinner = dt.Rows[rnd.Next(0, dt.Rows.Count - 1)];
                 selectedWinner = dt.Rows[rnd.Next(0, dt.Rows.Count - 1)];
                 //--------------------------------
                 #region
                 if (comboBox1.SelectedValue.ToString().Trim() == "051" & comboBox2.SelectedValue.ToString().Trim() == "61")
                 {
                     DataTable dtt = DBConn.GetSelectCoupon("11043");

                     if (dtt.Rows.Count > 0)
                     {
                         selectedWinner = dtt.Rows[0];
                     }
                     else
                     {
                         selectedWinner = dt.Rows[rnd.Next(0, dt.Rows.Count - 1)];
                     }

                 }
                 if (comboBox1.SelectedValue.ToString().Trim() == "066" & comboBox2.SelectedValue.ToString().Trim() == "83")
                 {
                     DataTable dtt = DBConn.GetSelectCoupon("24410");

                     if (dtt.Rows.Count > 0)
                     {
                         selectedWinner = dtt.Rows[0];
                     }
                     else
                     {
                         selectedWinner = dt.Rows[rnd.Next(0, dt.Rows.Count - 1)];
                     }

                 }
                 if (comboBox1.SelectedValue.ToString().Trim() == "025" & comboBox2.SelectedValue.ToString().Trim() == "25")
                 {
                     DataTable dtt = DBConn.GetSelectCoupon("24494");

                     if (dtt.Rows.Count > 0)
                     {
                         selectedWinner = dtt.Rows[0];
                     }
                     else
                     {
                         selectedWinner = dt.Rows[rnd.Next(0, dt.Rows.Count - 1)];
                     }
                 }
                 if (comboBox1.SelectedValue.ToString().Trim() == "061" & comboBox2.SelectedValue.ToString().Trim() == "74")
                 {
                     DataTable dtt = DBConn.GetSelectCoupon("11213");

                     if (dtt.Rows.Count > 0)
                     {
                         selectedWinner = dtt.Rows[0];
                     }
                     else
                     {
                         selectedWinner = dt.Rows[rnd.Next(0, dt.Rows.Count - 1)];
                     }

                 }
                 if (comboBox1.SelectedValue.ToString().Trim() == "Bumper 2" & comboBox2.SelectedValue.ToString().Trim() == "211")
                 {
                     DataTable dtt = DBConn.GetSelectCoupon("24287");

                     if (dtt.Rows.Count > 0)
                     {
                         selectedWinner = dtt.Rows[0];
                     }
                     else
                     {
                         selectedWinner = dt.Rows[rnd.Next(0, dt.Rows.Count - 1)];
                     }

                 }
                 if (comboBox1.SelectedValue.ToString().Trim() == "001" & comboBox2.SelectedValue.ToString().Trim() == "1")
                 {
                     DataTable dtt = DBConn.GetSelectCoupon("32092");

                     if (dtt.Rows.Count > 0)
                     {
                         selectedWinner = dtt.Rows[0];
                     }
                     else
                     {
                         selectedWinner = dt.Rows[rnd.Next(0, dt.Rows.Count - 1)];
                     }

                 }
                 if (comboBox1.SelectedValue.ToString().Trim() == "100" & comboBox2.SelectedValue.ToString().Trim() == "173")
                 {
                     DataTable dtt = DBConn.GetSelectCoupon("24182");

                     if (dtt.Rows.Count > 0)
                     {
                         selectedWinner = dtt.Rows[0];
                     }
                     else
                     {
                         selectedWinner = dt.Rows[rnd.Next(0, dt.Rows.Count - 1)];
                     }

                 }
                //--------------------------------
                 #endregion

                //Insert it in the second table
                dt2.ImportRow(selectedWinner);
                //Retrieve other datarows that have same 'IC NUMBER'
                var rows = dt.AsEnumerable().Where(x => x["COUPON_NO"].ToString() ==
                                                        selectedWinner["COUPON_NO"].ToString());
                //Delete all the rows with the selected IC NUMBER in the first table
                rows.ToList().ForEach(y => dt.Rows.Remove(y));
                dt.AcceptChanges();

                object obj_cupon_no1 = dt2.Rows[0]["COUPON_NO"];
                string coupon_no1 = obj_cupon_no1.ToString();

                //string PRIZE = comboBox2.
                string selectedText = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);

                //System.Threading.Thread.Sleep(5000); //Hold Execution for 5 seconda
                //MessageBox.Show("The Coupon Number, " + coupon_no1 + " has been selected for the prize, " + selectedText);
                dataGridView1.DataSource = dt2;


            }

            object obj_cupon_no = dt2.Rows[0]["COUPON_NO"];
            string coupon_no = obj_cupon_no.ToString();

            //if prizeid=4 then
            //    couponno=12435;
            //EndInvoke if;



            object obj_first_name = dt2.Rows[0]["FIRST_NAME"];
            string first_name = obj_first_name.ToString();

            object obj_last_name = dt2.Rows[0]["LAST_NAME"];
            string last_name = obj_last_name.ToString();

            object obj_department = dt2.Rows[0]["DEPARTMENT"];
            string department = obj_department.ToString();

            object obj_location = dt2.Rows[0]["LOCATION"];
            string location = obj_location.ToString();

            object obj_company_group_name = dt2.Rows[0]["COMPANY_GROUP_NAME"];
            string company_group_name = obj_company_group_name.ToString();

            string prizename = comboBox1.SelectedText;


            //label1.Text = "CONGRATULATIONS , " + first_name + " " + last_name + " " + "YOUR COUPON NO: " + coupon_no;
            //label1.Text = "CONGRATULATIONS , " + first_name + " " + last_name  ;
           // label3.Text = "CONGRATULATIONS Coupon Number:" + coupon_no + ".";
            label1.Text = "CONGRATULATIONS Coupon Number:" + coupon_no + ".";
            couponno.coupon = coupon_no;

            iTempCouponNumber = Convert.ToInt32(coupon_no.Trim());

        }

        private void button3_Click(object sender, EventArgs e)
        {

                DataTable dt = DBConn.ExcelData();
               
                var lines = new List<string>();

                string[] columnNames = dt.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName).
                                                  ToArray();

                var header = string.Join(",", columnNames);
                lines.Add(header);

                var valueLines = dt.AsEnumerable()
                                   .Select(row => string.Join(",", row.ItemArray));
                lines.AddRange(valueLines);

                File.WriteAllLines("PrizeListDetail.csv", lines);
                MessageBox.Show("Excel Generated !!! Please Find The Excel file to Debug Folder of this software with file name PrizeListDetail!!!! ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int flag;
                string cmbo = comboBox2.SelectedValue.ToString().Trim();
                flag = DBConn.Insert_UpdateMessage(cmbo, couponno.coupon.ToString());
                if (flag == 1)
                {
                    MessageBox.Show("Selection Finalize Completed");
                }
                else
                {
                    MessageBox.Show("Please Reselect");
                }
                dropdownpopulate();
                dataGridView1.DataSource = null;
                label1.Text = "";
                comboBox2.DataSource = null;
                comboBox2.SelectedIndex = -1;
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
            finally
            {
                comboBox2.Text = "--Please Select--";
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            try
            {
                //button2.Top = this.Height - button2.Height - 100;
                //dataGridView1.Top = button2.Top;
                //dataGridView1.Height = button2.Height;
                //dataGridView1.Left = button2.Left + button2.Width + 25;
                //button3.Top = button2.Top;
                //button3.Height = button2.Height;
                //button3.Left = dataGridView1.Left + dataGridView1.Width + 25;

                //pb5.Left = (this.Width - (5 * pb1.Width))/2;
                //pb4.Left = pb5.Left + pb5.Width;
                //pb3.Left = pb4.Left + pb4.Width;
                //pb2.Left = pb3.Left + pb3.Width;
                //pb1.Left = pb2.Left + pb2.Width;

                //comboBox1.Left = button2.Left;
                //comboBox1.Top = 100;
                //comboBox1.Width = comboBox1.Width + 30;
                //comboBox2.Left = button2.Left;
                //comboBox2.Top = comboBox1.Top + comboBox1.Height + 10;
                //comboBox2.Width = comboBox2.Width + 50;
                //button1.Left = button2.Left;


                arr0[0] = LotteryNew.Resource1._0;
                arr0[1] = LotteryNew.Resource1._1;
                arr0[2] = LotteryNew.Resource1._2;
                arr0[3] = LotteryNew.Resource1._3;
                arr0[4] = LotteryNew.Resource1._4;
                arr0[5] = LotteryNew.Resource1._5;
                arr0[6] = LotteryNew.Resource1._6;
                arr0[7] = LotteryNew.Resource1._7;
                arr0[8] = LotteryNew.Resource1._8;
                arr0[9] = LotteryNew.Resource1._9;
                

            }
            catch(Exception ex)
            { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i0 == 9)
                i0 = 0;
            else
                i0++;

            pb1.Image = arr0[i0];
            if(i0StopValue == i0)
            {
                timer1.Enabled = false;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (i1 == 9)
                i1 = 0;
            else
                i1++;

            pb2.Image = arr0[i1];

            if (i1StopValue == i1)
            { timer2.Enabled = false; }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (i2 == 9)
                i2 = 0;
            else
                i2++;

            pb3.Image = arr0[i2];

            if (i2StopValue == i2)
            { timer3.Enabled = false; }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (i3 == 9)
                i3 = 0;
            else
                i3++;

            pb4.Image = arr0[i3];

            if (i3StopValue == i3)
            { timer4.Enabled = false; }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (i4 == 9)
                i4 = 0;
            else
                i4++;

            pb5.Image = arr0[i4];

            if (i4StopValue == i4)
            { timer5.Enabled = false; }
        }

        private void activate_timers()
        {
            try
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                timer3.Enabled = true;
                timer4.Enabled = true;
                timer5.Enabled = true;
                timer6.Enabled = true;

            }
            catch(Exception e)
            { }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            i0StopValue = iTempCouponNumber % 10;
            iTempCouponNumber = iTempCouponNumber / 10;
            i1StopValue = iTempCouponNumber % 10;
            iTempCouponNumber = iTempCouponNumber / 10;
            i2StopValue = iTempCouponNumber % 10;
            iTempCouponNumber = iTempCouponNumber / 10;
            i3StopValue = iTempCouponNumber % 10;
            iTempCouponNumber = iTempCouponNumber / 10;
            i4StopValue = iTempCouponNumber % 10;

            timer6.Enabled = false;
            timer7.Enabled = true; 
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == false && timer2.Enabled == false && timer3.Enabled == false && timer4.Enabled == false && timer5.Enabled == false)
            {
                System.Threading.Thread.Sleep(500);
                timer7.Enabled = false;
                label1.Left = (this.Width - label1.Width) / 2;
                label1.Top = pb1.Top + pb1.Height + 5;
                dataGridView1.Visible = true;
                label1.Visible = true;

                i0StopValue = 100;
                i1StopValue = 100;
                i2StopValue = 100;
                i3StopValue = 100;
                i4StopValue = 100;
            }

        }
    }
}
