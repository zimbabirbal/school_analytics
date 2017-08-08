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
    public partial class Class1 : Form
    {
      
        string result;
        int classId = 1;
        int id,GrandTotal=0,Mgender,Fgender,PassMark=32,Cmgender=0;
        int stotal = 0, snepali = 0, senglish = 0, smath = 0, ssocial = 0, spopandenv = 0, sscience = 0, sopt1 = 0,sopt2=0,sopt3=0, Passresult;
        float fsnepali, fsenglish, fsmath, fspopEnv, fssocial, fsscience,fsopt1,fsopt2,fsopt3;
        private void Class1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart5_Click(object sender, EventArgs e)
        {

        }

        private void chart6_Click(object sender, EventArgs e)
        {

        }

        
        public Class1()
        {
            InitializeComponent();
            id=searchStudentNumber();
           
            class_1_analysis();
            marks_analysis();
             marks_Calculation();
            studentResult();
            overall_analysis();
          
        }

        private void studentResult()
        {
            
            this.chart8.Series["Student"].Points.AddXY("Boys(" + Mgender.ToString() + ")", Mgender);
            this.chart8.Series["Student"].Points.AddXY("Girls(" +(id- Mgender).ToString() + ")", (id-Mgender));

            this.chart9.Series["Result"].Points.AddXY("Pass(" + Passresult.ToString() + ")", Passresult);
            this.chart9.Series["Result"].Points.AddXY("Fail(" + (id-Passresult).ToString() + ")", (id-Passresult));

            this.chart10.Series["BoysVsGirl"].Points.AddXY("BoysPass(" + Mgender.ToString() + ")", Mgender);
            this.chart10.Series["BoysVsGirl"].Points.AddXY("GirlsPass(" + (Passresult - Mgender).ToString() + ")", (id - Mgender));
        }

        private void marks_Calculation()
        {

           


            label2.Text = "Number of Student = " + id.ToString();
            label3.Text = "Number of Boys    = " + Cmgender.ToString();
            label4.Text = "Number of Girls   = " + (id-Cmgender).ToString();
            label5.Text = "Number of Passed Student = " + Passresult.ToString();

        }

        private void overall_analysis()
        {
            float ssnepali, ssenglish, ssmath, sspopanden, sssocial, ssscience,ssopt1,ssopt2,ssopt3;
           
            GrandTotal = (snepali + senglish + smath + spopandenv + ssocial + sscience + sopt1 + sopt2 + sopt3);
            ssnepali = ((float)snepali /(float) GrandTotal) * 100;
            ssenglish = ((float)senglish / (float)GrandTotal) * 100;
            ssmath = ((float)smath / (float)GrandTotal) * 100;
            sspopanden = ((float)spopandenv / (float)GrandTotal) * 100;
            sssocial = ((float)ssocial / (float)GrandTotal) * 100;
            ssscience = ((float)sscience / (float)GrandTotal) * 100;
            ssopt1= ((float)sopt1 / (float)GrandTotal) * 100;
            ssopt2 = ((float)sopt2 / (float)GrandTotal) * 100;
            ssopt3 = ((float)sopt3 / (float)GrandTotal) * 100;

            this.chart7.Series["Nepali"].Points.AddXY("Nepali (" + Truncate(ssnepali, 1).ToString() + "%)", (int)ssnepali);
            this.chart7.Series["Nepali"].Points.AddXY("English(" + Truncate(ssenglish, 1).ToString() + "%)", (int)ssenglish);
            this.chart7.Series["Nepali"].Points.AddXY("Math (" + Truncate(ssmath, 1).ToString() + "%)", (int)ssmath);
            this.chart7.Series["Nepali"].Points.AddXY("PopEnv (" + Truncate(sspopanden, 1).ToString() + "%)", (int)sspopanden);
            this.chart7.Series["Nepali"].Points.AddXY("Social (" + Truncate(sssocial, 1).ToString() + "%)", (int)sssocial);
            this.chart7.Series["Nepali"].Points.AddXY("Science ("+ Truncate(ssscience, 1).ToString()+"%)", (int)ssscience);

            if (ssopt1!= 0)
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
            fsnepali = ((float)snepali /(float)temp) * 100;
            fsenglish = ((float)senglish / (float)temp) * 100;
            fsmath = ((float)smath / (float)temp) * 100;
            fspopEnv = ((float)spopandenv / (float)temp) * 100;
            fssocial = ((float)ssocial / (float)temp) * 100;
            fsscience = ((float)sscience / (float)temp) * 100;
            fsopt1 = ((float)sopt1 / (float)temp) * 100;
            fsopt2 = ((float)sopt1 / (float)temp) * 100;
            fsopt3 = ((float)sopt3 / (float)temp) * 100;


            fsnepali = Truncate(fsnepali, 1);
            fsenglish = Truncate(fsenglish, 1);
            fsmath = Truncate(fsmath, 1);
            fspopEnv = Truncate(fspopEnv,1);
            fssocial = Truncate(fssocial,1);
            fsscience = Truncate(fsscience, 1);
            fsopt1 = Truncate(fsopt1, 1);
            fsopt2 = Truncate(fsopt1, 1);
            fsopt3 = Truncate(fsopt1, 1);

            this.chart1.Series["Nepali"].Points.AddXY("nep("+fsnepali.ToString() + "%)",(int) fsnepali);
            this.chart1.Series["Nepali"].Points.AddXY( "-", 100-(int)fsnepali);

            this.chart2.Series["English"].Points.AddXY("eng("+fsenglish+"%)", (int)fsenglish);
            this.chart2.Series["English"].Points.AddXY("-", 100-(int)fsenglish);

            this.chart3.Series["Math"].Points.AddXY("math("+fsmath+"%)", (int)fsmath);
            this.chart3.Series["Math"].Points.AddXY("-", 100 - (int)fsmath);

            this.chart4.Series["Computer"].Points.AddXY("popAndEnv("+fspopEnv+"%)", (int)fspopEnv);
            this.chart4.Series["Computer"].Points.AddXY("-", 100 - (int)fspopEnv);

            this.chart5.Series["Social"].Points.AddXY("soc("+fssocial+"%)", (int)fssocial);
            this.chart5.Series["Social"].Points.AddXY("-", 100 - (int)fssocial);

            this.chart6.Series["Science"].Points.AddXY("sci("+fsscience+ "%)", (int)fsscience);
            this.chart6.Series["Science"].Points.AddXY("-", 100 - (int)fsscience);

            if (fsopt1 != 0)
            {
                this.chart6.Series["Opt1"].Points.AddXY("sci(" + fsopt1 + "%)", (int)fsopt1);
                this.chart6.Series["Opt1"].Points.AddXY("-", 100 - (int)fsopt1);
            }
            if (fsopt1 != 0)
            {
                this.chart6.Series["Opt2"].Points.AddXY("sci(" + fsopt2 + "%)", (int)fsopt2);
                this.chart6.Series["Opt2"].Points.AddXY("-", 100 - (int)fsopt2);
            }
            if (fsopt1 != 0)
            {
                this.chart6.Series["Opt3"].Points.AddXY("sci(" + fsopt3 + "%)", (int)fsopt3);
                this.chart6.Series["Opt3"].Points.AddXY("-", 100 - (int)fsopt3);
            }


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
            
            int english, nepali, math, science, socialStudies, popAndEnvironment, opt1, opt2, opt3, noSubject;
            for (int i = 1; i < id; i++)
            {
                string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                string Query = "select * from latestspas.exam where Student_idStudent= '" + i + "' and idClass= '"+classId+"' ;";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                MySqlDataReader myReader;
                conDatabase.Open();

                try
                {

                    myReader = cmdDatabase.ExecuteReader();
                    // MessageBox.Show("Data has been Updated " + comboBox1.Text);

                    if (myReader.Read())
                    {
                        //MessageBox.Show("Data has been Updated");
                        //myReader.Read();

                        nepali = myReader.GetInt32("nepali");
                        english = myReader.GetInt32("english");
                        math = myReader.GetInt32("math");
                        socialStudies = myReader.GetInt32("socialStudies");
                        popAndEnvironment = myReader.GetInt32("popAndEnvironment");
                        science = myReader.GetInt32("science");
                        opt1 = myReader.GetInt32("opt1");
                        opt2 = myReader.GetInt32("opt1");
                        opt3 = myReader.GetInt32("opt1");
                        noSubject = myReader.GetInt32("noSubject");

                        snepali += nepali;
                        senglish += english;
                        smath += math;
                        ssocial += socialStudies;
                        spopandenv += popAndEnvironment;
                        sscience += science;
                        sopt1 += opt1;
                        sopt2 += opt2;
                        sopt3 += opt3;
                        stotal += (snepali + senglish + smath + ssocial + spopandenv + sscience + sopt1 + sopt2 + sopt3);

                        if (nepali < PassMark)
                        {
                            result = "FAIL";
                        }

                        else if (english < PassMark)
                        {
                            result = "FAIL";
                        }
                        else if (math < PassMark)
                        {
                            result = "FAIL";
                        }
                        else if (science < PassMark)
                        {
                            result = "FAIL";
                        }
                        else if (popAndEnvironment < PassMark)
                        {
                            result = "FAIL";
                        }
                        else if (socialStudies < PassMark)
                        {
                            result = "FAIL";
                        }
                        else if (opt1 < PassMark && opt1 > 0)
                        {
                            result = "FAIL";
                        }
                        else if (opt2 < PassMark && opt2 > 0)
                        {
                            result = "FAIL";
                        }
                        else if (opt2 < PassMark && opt2 > 0)
                        {
                            result = "FAIL";
                        }
                        else
                        {
                            result = "PASS";
                        }



                        // myReader.Read();

                    }
                    myReader.Close();
                    conDatabase.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                string constring1 = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
                string Query1 = "select * from latestspas.student where idStudent= '" + i + "';";
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
                    myReader1.Close();
                    conDatabase1.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }






            }


            // MessageBox.Show(stotal.ToString()+" " + snepali.ToString() +" " + senglish.ToString());


        }
        private int searchStudentNumber()
        {
            string Query;
            // string constring = "datasource=localhost;port=3306;username=root;password=12345";
            string constring = ConfigurationManager.ConnectionStrings["MySQL"].ToString();

            Query = "SELECT COUNT(*) FROM latestspas.exam where idClass= '" + classId + "' ;";

            using (MySqlConnection connect = new MySqlConnection(constring)) 

            using (MySqlCommand cmd = new MySqlCommand(Query, connect))
            {
                connect.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            
        }
    }
}
