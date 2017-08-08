using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace SEproject
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        List<string> event_name_list = new List<string>();
        List<string> event_date_list = new List<string>();
        List<string> event_by = new List<string>();
        List<string> event_details = new List<string>();
        List<string> event_staff = new List<string>();
        public HomePage()
        {
            InitializeComponent();
            fillBlank();
        }

        private void fillBlank()
        {
            

            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            // string Query = "select * from latestspas.remainder  ;";
            string Query = "SELECT  event_name, event_by, event_details, staff_idStaff,event_date AS DATE FROM latestspas.remainder  ORDER BY DATE desc LIMIT 8;";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;

           
            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                //MessageBox.Show("Data has been Updated");
                while (myReader.Read())
                {
                  
                    event_name_list.Add(myReader.GetString("event_name"));
                    event_date_list.Add(myReader.GetString("DATE"));
                    event_details.Add(myReader.GetString("event_details"));
                    event_by.Add(myReader.GetString("event_by"));
                    event_staff.Add(myReader.GetString("staff_idStaff"));




                }
                button.Content = event_date_list[0] +" "+ event_name_list[0];
                button_Copy.Content = event_date_list[1] + " " + event_name_list[1];
                button_Copy1.Content = event_date_list[2] + " " + event_name_list[2];
                button_Copy2.Content = event_date_list[3] + " " + event_name_list[3];
                button_Copy3.Content = event_date_list[4] + " " + event_name_list[4];
                button_Copy4.Content = event_date_list[5] + " " + event_name_list[5];
                button_Copy5.Content = event_date_list[6] + " " + event_name_list[6];
                button_Copy6.Content = event_date_list[7] + " " + event_name_list[7];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conDatabase.Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
           
            checkLogin asw = new checkLogin();


            bool c = asw.checkLogin1();
            try
            {
                if (c)
                {
                    
                    // string constring = "datasource=localhost;port=3306;username=root;password=12345";
                    string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                    string Query = "insert into latestspas.remainder (event_name, event_date, event_by, event_details, staff_idStaff ) values ('" + this.EventName.Text + "','" + this.dateInsert.Text + "','" + this.EventBy.Text + "','" + this.EventDetails.Text + "','"+ login.GID + "') ;";
                    MySqlConnection conDatabase = new MySqlConnection(constring);
                    MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                    MySqlDataReader myReader;

                    try
                    {
                        conDatabase.Open();
                        myReader = cmdDatabase.ExecuteReader();

                        MessageBox.Show("Data has been Saved Successfully");
                        EventName.Text = "";
                        dateInsert.Text = "";
                        EventBy.Text = "";
                        EventDetails.Text = "";



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something errors occurs in Database" + ex.Message);
                    }
                    conDatabase.Close();
                }
                else
                {
                    MessageBox.Show("please login as Admin first");
                }

            }
            catch
            {
                MessageBox.Show("Some Invalid Occurs");
            }
           
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            showBox(1);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            showBox(0);
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            showBox(2);
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            showBox(3);
        }

        private void button_Copy3_Click(object sender, RoutedEventArgs e)
        {
            showBox(4);
        }

        private void button_Copy4_Click(object sender, RoutedEventArgs e)
        {
            showBox(5);
        }

        private void button_Copy5_Click(object sender, RoutedEventArgs e)
        {
            showBox(6);
        }

        private void button_Copy6_Click(object sender, RoutedEventArgs e)
        {
            showBox(7);
        }

        void showBox(int a)
        {
            MessageBox.Show("Event Name: " + event_name_list[a] + "\n" + "Event Date: " + event_date_list[a] + "\n" + "Event By: " + event_by[a] + "\n" + "Event Details: " + event_details[a]);
        }

    }
}
