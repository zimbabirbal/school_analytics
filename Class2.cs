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
    public partial class Class2 : Form
    {
        string result;
        int classId = 2;
        int id, GrandTotal = 0, Mgender, Fgender, PassMark = 32, Cmgender = 0;
        int stotal = 0, Passresult=0;
        List<int> english = new List<int>();
        List<int> nepali = new List<int>();
        List<int> math = new List<int>();
        List<int> science = new List<int>();
        List<int> popAnde = new List<int>();
        List<int> social = new List<int>();
        List<int> opt1 = new List<int>();
        List<int> opt2 = new List<int>();
        List<int> opt3 = new List<int>();
        List<int> studentIds = new List<int>();

        private void chart10_Click(object sender, EventArgs e)
        {

        }

        float fsnepali, fsenglish, fsmath, fspopEnv, fssocial, fsscience, fsopt1, fsopt2, fsopt3;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
       
        public Class2()
        {

            InitializeComponent();
           
          
            class_1_analysis();
            marks_analysis();
            marks_Calculation();
            studentResult();
            overall_analysis();
        }

        private void Class2_Load(object sender, EventArgs e)
        {

        }
        private void studentResult()
        {

            this.chart8.Series["Student"].Points.AddXY("Boys(" + Cmgender.ToString() + ")", Cmgender);
            this.chart8.Series["Student"].Points.AddXY("Girls(" + (id - Cmgender).ToString() + ")", (id - Cmgender));

            this.chart9.Series["Result"].Points.AddXY("Pass(" + Passresult.ToString() + ")", Passresult);
            this.chart9.Series["Result"].Points.AddXY("Fail(" + (id - Passresult).ToString() + ")", (id - Passresult));

            this.chart10.Series["BoysVsGirls"].Points.AddXY("BoysPass(" + Mgender.ToString() + ")", Mgender);
            this.chart10.Series["BoysVsGirls"].Points.AddXY("GirlsPass(" + (Passresult - Mgender).ToString() + ")", (Passresult - Mgender));
        }

        private void marks_Calculation()
        {




            label2.Text = "Number of Student = " + id.ToString();
            label3.Text = "Number of Boys    = " + Cmgender.ToString();
            label4.Text = "Number of Girls   = " + (id - Cmgender).ToString();
            label5.Text = "Number of Passed Student = " + Passresult.ToString();

        }

        private void overall_analysis()
        {
            float ssnepali, ssenglish, ssmath, sspopanden, sssocial, ssscience, ssopt1, ssopt2, ssopt3;

            GrandTotal = stotal;
            ssnepali = ((float)nepali.Sum() / (float)GrandTotal) * 100;
            ssenglish = ((float)english.Sum() / (float)GrandTotal) * 100;
            ssmath = ((float)math.Sum() / (float)GrandTotal) * 100;
            sspopanden = ((float)popAnde.Sum() / (float)GrandTotal) * 100;
            sssocial = ((float)social.Sum() / (float)GrandTotal) * 100;
            ssscience = ((float)science.Sum() / (float)GrandTotal) * 100;
            ssopt1 = ((float)opt1.Sum() / (float)GrandTotal) * 100;
            ssopt2 = ((float)opt2.Sum() / (float)GrandTotal) * 100;
            ssopt3 = ((float)opt3.Sum() / (float)GrandTotal) * 100;

            this.chart7.Series["Nepali"].Points.AddXY("Nepali (" + Truncate(ssnepali, 1).ToString() + "%)", (int)ssnepali);
            this.chart7.Series["Nepali"].Points.AddXY("English(" + Truncate(ssenglish, 1).ToString() + "%)", (int)ssenglish);
            this.chart7.Series["Nepali"].Points.AddXY("Math (" + Truncate(ssmath, 1).ToString() + "%)", (int)ssmath);
            this.chart7.Series["Nepali"].Points.AddXY("PopEnv (" + Truncate(sspopanden, 1).ToString() + "%)", (int)sspopanden);
            this.chart7.Series["Nepali"].Points.AddXY("Social (" + Truncate(sssocial, 1).ToString() + "%)", (int)sssocial);
            this.chart7.Series["Nepali"].Points.AddXY("Science (" + Truncate(ssscience, 1).ToString() + "%)", (int)ssscience);

            if (ssopt1 != 0)
            {
                this.chart7.Series["Nepali"].Points.AddXY("Opt1 (" + Truncate(ssopt1, 1).ToString() + "%)", (int)ssopt1);
            }
            if (ssopt2 != 0)
            {
                this.chart7.Series["Nepali"].Points.AddXY("Opt2 (" + Truncate(ssopt2, 1).ToString() + "%)", (int)ssopt2);
            }
            if (ssopt3 != 0)
            {
                this.chart7.Series["Nepali"].Points.AddXY("Opt3 (" + Truncate(ssopt3, 1).ToString() + "%)", (int)ssopt3);
            }
        }

        private void marks_analysis()
        {
            int temp;

            temp = (id * 100);
            GrandTotal = (stotal);
            fsnepali = ((float)nepali.Sum() / (float)temp) * 100;
            fsenglish = ((float)english.Sum() / (float)temp) * 100;
            fsmath = ((float)math.Sum() / (float)temp) * 100;
            fspopEnv = ((float)popAnde.Sum() / (float)temp) * 100;
            fssocial = ((float)social.Sum() / (float)temp) * 100;
            fsscience = ((float)science.Sum() / (float)temp) * 100;
            fsopt1 = ((float)opt1.Sum() / (float)temp) * 100;
            fsopt2 = ((float)opt2.Sum() / (float)temp) * 100;
            fsopt3 = ((float)opt3.Sum() / (float)temp) * 100;


            fsnepali = Truncate(fsnepali, 1);
            fsenglish = Truncate(fsenglish, 1);
            fsmath = Truncate(fsmath, 1);
            fspopEnv = Truncate(fspopEnv, 1);
            fssocial = Truncate(fssocial, 1);
            fsscience = Truncate(fsscience, 1);
            fsopt1 = Truncate(fsopt1, 1);
            fsopt2 = Truncate(fsopt1, 1);
            fsopt3 = Truncate(fsopt1, 1);

            this.chart1.Series["Nepali"].Points.AddXY("nep(" + fsnepali.ToString() + "%)", (int)fsnepali);
            this.chart1.Series["Nepali"].Points.AddXY("-", 100 - (int)fsnepali);

            this.chart2.Series["English"].Points.AddXY("eng(" + fsenglish + "%)", (int)fsenglish);
            this.chart2.Series["English"].Points.AddXY("-", 100 - (int)fsenglish);

            this.chart3.Series["Math"].Points.AddXY("math(" + fsmath + "%)", (int)fsmath);
            this.chart3.Series["Math"].Points.AddXY("-", 100 - (int)fsmath);

            this.chart4.Series["Computer"].Points.AddXY("popAndEnv(" + fspopEnv + "%)", (int)fspopEnv);
            this.chart4.Series["Computer"].Points.AddXY("-", 100 - (int)fspopEnv);

            this.chart5.Series["Social"].Points.AddXY("soc(" + fssocial + "%)", (int)fssocial);
            this.chart5.Series["Social"].Points.AddXY("-", 100 - (int)fssocial);

            this.chart6.Series["Science"].Points.AddXY("sci(" + fsscience + "%)", (int)fsscience);
            this.chart6.Series["Science"].Points.AddXY("-", 100 - (int)fsscience);

            


            // MessageBox.Show(fsnepali.ToString()+ " "+ fsenglish.ToString() + " " + fsmath.ToString() + " " + fscomputer.ToString() + " " + fssocial.ToString() + " " + fssocial.ToString() +" "+ GrandTotal.ToString());

        }
        public static float Truncate(float value, int digits)
        {
            double mult = Math.Pow(10.0, digits);
            double result = Math.Truncate(mult * value) / mult;
            return (float)result;
        }

        public void class_1_analysis()
        {

          
                string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                string Query = "select *  from latestspas.exam as e   inner join latestspas.active_class as a on (a.current_class=2 and e.idClass=1) and a.student_idStudent=e.Student_idStudent order by e.Student_idStudent asc;";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                MySqlDataReader myReader;
                conDatabase.Open();

                try
                {

                    myReader = cmdDatabase.ExecuteReader();
                    // MessageBox.Show("Data has been Updated " + comboBox1.Text);

                    while (myReader.Read())
                    {
                        //MessageBox.Show("Data has been Updated");
                        //myReader.Read();
                        studentIds.Add( myReader.GetInt32("Student_idStudent"));
                        nepali.Add(myReader.GetInt32("nepali"));
                        english.Add(myReader.GetInt32("english"));
                        math.Add( myReader.GetInt32("math"));
                        social.Add( myReader.GetInt32("socialStudies"));
                        popAnde.Add(myReader.GetInt32("popAndEnvironment"));
                        science.Add (myReader.GetInt32("science"));
                        opt1.Add( myReader.GetInt32("opt1"));
                        opt2.Add( myReader.GetInt32("opt1"));
                        opt3.Add( myReader.GetInt32("opt1"));
                       
                    
                       
                        // myReader.Read();

                    }
                stotal = nepali.Sum() + english.Sum() + math.Sum() + social.Sum() + popAnde.Sum() + science.Sum() + opt1.Sum() + opt2.Sum() + opt3.Sum();

                       



                }
            catch (Exception ex)
                {
                
                    MessageBox.Show(ex.Message);
                }
            id = nepali.Count();
            for (int i = 0; i < id; i++)
            {
                if (nepali[i] < PassMark)
                {
                    result = "FAIL";
                }

                else if (english[i] < PassMark)
                {
                    result = "FAIL";
                }
                else if (math[i] < PassMark)
                {
                    result = "FAIL";
                }
                else if (science[i] < PassMark)
                {
                    result = "FAIL";
                }
                else if (popAnde[i] < PassMark)
                {
                    result = "FAIL";
                }
                else if (social[i] < PassMark)
                {
                    result = "FAIL";
                }
                else if (opt1[i] < PassMark && opt1[i] > 0)
                {
                    result = "FAIL";
                }
                else if (opt2[i] < PassMark && opt2[i] > 0)
                {
                    result = "FAIL";
                }
                else if (opt2[i] < PassMark && opt2[i] > 0)
                {
                    result = "FAIL";
                }
                else
                {
                    result = "PASS";
                }


                string constring1 = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                string Query1 = "select * from latestspas.student where idStudent= '" + studentIds[i] + "';";
                MySqlConnection conDatabase1 = new MySqlConnection(constring1);
                MySqlCommand cmdDatabase1 = new MySqlCommand(Query1, conDatabase1);
                MySqlDataReader myReader1;
                conDatabase1.Open();

                try
                {

                    myReader1 = cmdDatabase1.ExecuteReader();
                    // MessageBox.Show("Data has been Updated " + comboBox1.Text);

                    if (myReader1.Read())
                    {
                        string gender = myReader1.GetString("gender");
                      
                        if (result == "PASS")
                        {
                            Passresult += 1;
                            if (gender == "Male")
                            {
                                Cmgender += 1;
                                Mgender += 1;
                            }
                            else
                            {
                                Fgender += 1;
                            }
                        }
                        else
                        {
                            if (gender == "Male")
                            {
                                Cmgender += 1;

                            }

                        }



                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }






            } 


            // MessageBox.Show(stotal.ToString()+" " + snepali.ToString() +" " + senglish.ToString());
          
        }
        //private int searchStudentNumber()
        //{
        //    string Query;
        //    // string constring = "datasource=localhost;port=3306;username=root;password=12345";
        //    string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();

        //    Query = "SELECT COUNT(*) FROM latestspas.active_class where current_class= '" + classId + "' ;";

        //    using (MySqlConnection connect = new MySqlConnection(constring))

        //    using (MySqlCommand cmd = new MySqlCommand(Query, connect))
        //    {
        //        connect.Open();
        //        return Convert.ToInt32(cmd.ExecuteScalar());
        //    }

        //}
    

}
}
