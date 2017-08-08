using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace SEproject
{
    public partial class Form2 : Form
    {
        string  name,Student_id;
        int[] subjects = new int[6];
        int[] subjects_class_1 = new int[6];
        int passMark = 32;
       
        int Number_Subject = 6;
       int TotalObtained_class1, TotalObtained_class2,aadmin_class,active_class;
        string improved, improveRequire;

        List<int> english = new List<int>();
        List<int> nepali = new List<int>();
        List<int> math = new List<int>();
        List<int> science = new List<int>();
        List<int> popAnde = new List<int>();
        List<int> social = new List<int>();
        List<int> opt1 = new List<int>();
        List<int> opt2 = new List<int>();
        List<int> opt3 = new List<int>();
        List<int> classId = new List<int>();
        List<int> noofsubject = new List<int>();
        List<int> classResult = new List<int>();


        public Form2(string sName,string StudentId,int admin_class)
        {
            InitializeComponent();
            name = sName;
            Student_id = StudentId;
            aadmin_class = admin_class;
            

            TotalObtained_class2 = (subjects[0] + subjects[1] + subjects[2] + subjects[3] + subjects[4] + subjects[5]);
            label1.Text = name + " / " + "(" +"id-N0. "+Student_id+")" ;
            
           
            Active_class_func();
            class_exam_view();
            ShowAll();
            performanceChart();
            improvedSub();
        }
        void Active_class_func()
        {
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select* from latestspas.active_class where student_idStudent= '" + Student_id + "' ;";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                //System.Windows.Forms.MessageBox.Show("Data has been Saved Successfully");
                while (myReader.Read())
                {

                    active_class = myReader.GetInt32("current_class");

                }

               

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Something errors occurs in Database" + ex.Message);
                active_class= aadmin_class;
            }
            conDatabase.Close();


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void PlotGraph(List<int> x)
        {
            for (int i = 1; i < (active_class - aadmin_class); i++)
            {
                this.chart1.Series["Class" + (aadmin_class + i)].Points.AddXY("", x[i]);

            }
        }

        private void ShowAll()
        {
            try
            {
                this.chart1.Series["Class" + aadmin_class].Points.AddXY("Nepali", nepali[0]);
                PlotGraph(nepali);
                this.chart1.Series["Class" + aadmin_class].Points.AddXY("English", english[0]);
                PlotGraph(english);
                this.chart1.Series["Class" + aadmin_class].Points.AddXY("Math", math[0]);
                PlotGraph(math);
                this.chart1.Series["Class" + aadmin_class].Points.AddXY("Science", science[0]);
                PlotGraph(science);
                this.chart1.Series["Class" + aadmin_class].Points.AddXY("Social", social[0]);
                PlotGraph(social);
                this.chart1.Series["Class" + aadmin_class].Points.AddXY("Pop and Env", popAnde[0]);
                PlotGraph(popAnde);
                this.chart1.Series["Class" + aadmin_class].Points.AddXY("Opt1", opt1[0]);
                PlotGraph(opt1);
                this.chart1.Series["Class" + aadmin_class].Points.AddXY("Opt2", opt2[0]);
                PlotGraph(opt2);
                this.chart1.Series["Class" + aadmin_class].Points.AddXY("Opt3", opt3[0]);
                PlotGraph(opt3);
            }
            catch (Exception ex) {
                 System.Windows.Forms.MessageBox.Show("Fromm show all ");

            }
          


            //if (bigtemp <= 0)
            //{
            //    label7.Text = "decreased " + bigtemp.ToString() + "%";
            //}
            //else
            //{
            //    label7.Text = "increased " + bigtemp.ToString() + "%";
            //}
            //label9.Text = temp.ToString() + "%";
            //label11.Text = temp2.ToString() + "%";




        }
        private void class_exam_view()
        {
           


            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
            string Query = "select * from latestspas.exam where Student_idStudent= '" + Student_id + "' order by idClass asc ;";
            MySqlConnection conDatabase = new MySqlConnection(constring);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
            MySqlDataReader myReader;

            try
            {
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                //System.Windows.Forms.MessageBox.Show("Data has been Saved Successfully");
                while (myReader.Read())
                {



                    classId.Add(myReader.GetInt32("idClass"));
                    english.Add(myReader.GetInt32("english"));
                    nepali.Add(myReader.GetInt32("nepali"));
                    math.Add(myReader.GetInt32("math"));
                    science.Add(myReader.GetInt32("science"));
                    popAnde.Add(myReader.GetInt32("socialStudies"));
                    social.Add(myReader.GetInt32("popAndEnvironment"));
                    opt1.Add(myReader.GetInt32("opt1"));
                    opt2.Add(myReader.GetInt32("opt2"));
                    opt3.Add(myReader.GetInt32("opt3"));
                    noofsubject.Add(myReader.GetInt32("noSubject"));


                }


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Something errors occurs in Database" + ex.Message);
            }
            conDatabase.Close();

            label12.Text = "" + name + " had admission in class " + aadmin_class + " and currently studing in class " + active_class + "\nin those year Exams Performace was Above ";

            

          


        }
        void performanceChart()
        {
            try
            {
                for (int i = 0; i < (active_class-aadmin_class); i++)
                {
                    
                    classResult.Add((english[i] + nepali[i] + science[i] + social[i] + popAnde[i] + math[i] + opt1[i] + opt2[i] + opt3[i]) / noofsubject[i]);
                    this.chart2.Series["PerformanceChart"].Points.AddXY("Class " + (aadmin_class + i), classResult[i]);
                }
            }
            catch  (Exception ex)
            {
            System.Windows.Forms.MessageBox.Show("performance chart " + ex.Message);
            }
            
           

        }


        private void improvedSub()
        {
            
            int a = nepali.Count() - 2;
            int b = nepali.Count()-1;

            if (nepali[a] < nepali[b])
            {
                label5.Text += "Nepali,";
            }
            else
            {
                label3.Text += "Nepali,";
            }
            if (english[a] < english[b])
            {
                label5.Text += "English,";
            }
            else
            {
                label3.Text += "English,";
            }
            if (math[a] < math[b])
            {
                label5.Text += "Math,";
            }
            else
            {
                label3.Text += "Math,";
            }
            if (science[a] < science[b])
            {
                label5.Text += "Science,";
            }
            else
            {
                label3.Text += "Science,";
            }
            if (social[a] < social[b])
            {
                label5.Text += "Social,";
            }
            else
            {
                label3.Text += "Social,";
            }
            if (popAnde[a] < popAnde[b])
            {
                label5.Text += "Pop And Env,";
            }
            else
            {
                label3.Text += "Pop And Env,";
            }
           



        }
    }
}
