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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace first
{
    public partial class Form1 : Form
    {

        int ID = 0;
        int ID2 = 0;
        int ID3 = 0;
        int cloid = 0;
        string a;
        int sum = 0;
       
        string h;


        public Form1()
        {
            InitializeComponent();
            Fill_ComboBox();
            Fill_ComboBox_of_AssessRubric();
            Fill_ComboBox_of_Assignment_();
            Fill_ComboBox_regNo();
            Fill_ComboBox_Assess_result();

            Fill_ComboBox_of_StudentId_in_StudentAttendance();


          
        }
        //Adding connection to this file.

        SqlConnection sql = new SqlConnection(@"Data Source=HP-PC\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True;MultipleActiveResultSets=True");
        private void button2_Click(object sender, EventArgs e)
        {
            //Inserting the Data of Student in the Student table in Sql Server.
            sql.Open();
            string query = "INSERT INTO Student (FirstName,LastName,Contact,Email,RegistrationNumber,Status) VALUES('" + txt_FirstName.Text + "','" + txt_LastName.Text + "','" + txt_Contact.Text + "','" + txt_Email.Text + "','" + txt_regNo.Text + "',(select LookupId from Lookup where Name='" + Status_ComboBox.Text + "'))";
            SqlDataAdapter foo = new SqlDataAdapter(query, sql);

            //Executing the query 
            foo.SelectCommand.ExecuteNonQuery();
            //Closing the Connection,
            sql.Close();
            //Showing that the data is inserted successfully.
            MessageBox.Show("Data Inserted Successfully");
            Fill_ComboBox_regNo_Of_CLOwise_Result();
        }

        //Filling the  combo Box of Rubrics with the CLOS  of the CLO.Aany cahange in the Clo will also ocuur in this comboBox 
        public void Fill_ComboBox()
        {

            sql.Open();
            //Query of selecting the Name and ID of CLO from CLO table

            string query66 = "Select Name,Id from Clo";
            SqlCommand cmd0 = new SqlCommand(query66, sql);

            //Executing the query
            cmd0.ExecuteNonQuery();
            SqlDataAdapter sd = new SqlDataAdapter(cmd0);
            //Binding of the combobox with the values of dataTable
            DataTable dt9 = new DataTable();
            sd.Fill(dt9);
            txt_AllClos.DataSource = dt9;
            //Display only the members of the Name of CLO
            txt_AllClos.DisplayMember = "Name";
            //Taking the values of ID against the selected name in the comboBox
            txt_AllClos.ValueMember = "Id";

            //Closing the connection,
            sql.Close();



        }
        public void Fish()
        {

           
            int  q = Convert.ToInt32(textBox8.Text.ToString());

            SqlCommand pop = new SqlCommand("select * from Rubric where Id=@lol", sql);
            pop.Parameters.AddWithValue("@lol", q);
            SqlDataReader noon = pop.ExecuteReader();


            while (noon.Read())
            {

                string b = noon["CloId"].ToString();
                comboBox12.Items.Add(b);
            }

            noon.Close();


            sql.Close();
            using (SqlConnection cn = new SqlConnection(@"Data Source=HP-PC\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True;MultipleActiveResultSets=True")) ;


        }



        public void Fill_ComboBox_of_StudentId_in_StudentAttendance()
        {

            sql.Open();
            //Query of selecting the Name and ID of CLO from CLO table

            string query66 = "Select RegistrationNumber,Id from Student";
            SqlCommand cmd0 = new SqlCommand(query66, sql);

            //Executing the query
            cmd0.ExecuteNonQuery();
            SqlDataAdapter sd = new SqlDataAdapter(cmd0);
            //Binding of the combobox with the values of dataTable
            DataTable dt9 = new DataTable();
            sd.Fill(dt9);
            comboBox1.DataSource = dt9;
            //Display only the members of the Name of CLO
            comboBox1.DisplayMember = "RegistrationNumber";
            //Taking the values of ID against the selected name in the comboBox
            comboBox1.ValueMember = "Id";

            //Closing the connection,
            sql.Close();





        }



        public void FillStates(int countryID)
        {
            
         
            SqlCommand cmd = new SqlCommand();
            
            cmd.Connection = sql;
          
            cmd.CommandType = CommandType.Text;
         
            cmd.CommandText = "SELECT Name,Id FROM AssessmentComponent WHERE AssessmentId =@CountryID";
        
            cmd.Parameters.AddWithValue("@CountryID", countryID);
           
            DataSet objDs = new DataSet();
         
            SqlDataAdapter dAdapter = new SqlDataAdapter();
      
            dAdapter.SelectCommand = cmd;
          
            sql.Open();
      
            dAdapter.Fill(objDs);
          
            sql.Close();
  
            if (objDs.Tables[0].Rows.Count > 0)
           
            {
            
                comboBox5.ValueMember = "Id";
     
                comboBox5.DisplayMember = "Name";
              
                comboBox5.DataSource = objDs.Tables[0];
            
            }
        }

      

        public void Fill_ComboBox_of_AssessRubric()
        {
            sql.Open();
            //Query of selecting the Name and ID of CLO from CLO table

            string query66 = "Select Id,Details from Rubric";
            SqlCommand cmd0 = new SqlCommand(query66, sql);

            //Executing the query
            cmd0.ExecuteNonQuery();
            SqlDataAdapter sd = new SqlDataAdapter(cmd0);
            //Binding of the combobox with the values of dataTable
            DataTable dt9 = new DataTable();
            sd.Fill(dt9);
            comboBox6.DataSource = dt9;
            //Display only the members of the Name of CLO
            comboBox6.DisplayMember = "Details";
            //Taking the values of ID against the selected name in the comboBox
            comboBox6.ValueMember = "Id";

            //Closing the connection,
            sql.Close();




        }
     

        public void Fill_ComboBox_of_Assignment_()
        {

            sql.Open();
            //Query of selecting the Name and ID of CLO from CLO table

            string query66 = "Select Id,Title from Assessment";
            SqlCommand cmd0 = new SqlCommand(query66, sql);

            //Executing the query
            cmd0.ExecuteNonQuery();
            SqlDataAdapter sd = new SqlDataAdapter(cmd0);
            //Binding of the combobox with the values of dataTable
            DataTable dt9 = new DataTable();
            sd.Fill(dt9);
            comboBox2.DataSource = dt9;
            //Display only the members of the Name of CLO
            comboBox2.DisplayMember = "Title";
            //Taking the values of ID against the selected name in the comboBox
            comboBox2.ValueMember = "Id";

            //Closing the connection,
            sql.Close();




        }
        public void Fill_ComboBox_of_AssignmentAssess()
        {

            sql.Open();
            //Query of selecting the Name and ID of CLO from CLO table

            string query66 = "Select Id,Title from Assessment";
            SqlCommand cmd0 = new SqlCommand(query66, sql);

            //Executing the query
            cmd0.ExecuteNonQuery();
            SqlDataAdapter sd = new SqlDataAdapter(cmd0);
            //Binding of the combobox with the values of dataTable
            DataTable dt9 = new DataTable();
            sd.Fill(dt9);
            comboBox2.DataSource = dt9;
            //Display only the members of the Name of CLO
            comboBox2.DisplayMember = "Title";
            //Taking the values of ID against the selected name in the comboBox
            comboBox2.ValueMember = "Id";

            //Closing the connection,
            sql.Close();




        }

        public void Fill_ComboBox_regNo()
        {

            sql.Open();
            //Query of selecting the Name and ID of CLO from CLO table

            string query66 = "Select RegistrationNumber,Id from Student";
            SqlCommand cmd0 = new SqlCommand(query66, sql);

            //Executing the query
            cmd0.ExecuteNonQuery();
            SqlDataAdapter sd = new SqlDataAdapter(cmd0);
            //Binding of the combobox with the values of dataTable
            DataTable dt9 = new DataTable();
            sd.Fill(dt9);
            comboBox4.DataSource = dt9;
            //Display only the members of the Name of CLO
            comboBox4.DisplayMember = "RegistrationNumber";
            //Taking the values of ID against the selected name in the comboBox
            comboBox4.ValueMember = "Id";

            //Closing the connection,
            sql.Close();



        }

        public void Fill_ComboBox_regNo_Of_CLOwise_Result()
        {

   
        }




        public void Fill_ComboBox_assesscomp()
        {

            sql.Open();
            //Query of selecting the  and ID of CLO from CLO table

            string query66 = "Select Name,Id from AssessmentComponent";
            SqlCommand cmd0 = new SqlCommand(query66, sql);

            //Executing the query
            cmd0.ExecuteNonQuery();
            SqlDataAdapter sd = new SqlDataAdapter(cmd0);
            //Binding of the combobox with the values of dataTable
            DataTable dt9 = new DataTable();
            sd.Fill(dt9);
            comboBox5.DataSource = dt9;
            //Display only the members of the Name of CLO
            comboBox5.DisplayMember = "Name";
            //Taking the values of ID against the selected name in the comboBox
            comboBox5.ValueMember = "Id";

            //Closing the connection,
            sql.Close();



        }
        public void Fill_ComboBox_Assess_result()
        {
          
           
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            
            cmd.CommandType = CommandType.Text;
            
            cmd.CommandText = "SELECT Title, Id FROM Assessment";
            
            DataSet objDs = new DataSet();
            
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            
            dAdapter.SelectCommand = cmd;
            
            sql.Open();
            
            dAdapter.Fill(objDs);
           
            sql.Close();
            
            comboBox7.ValueMember = "Id";
            
            comboBox7.DisplayMember = "Title";
           
            comboBox7.DataSource = objDs.Tables[0];



        }
        public void Fill_ComboBox_rubric_result()
        { 



        }
        public void FillRubricLevelresult(int countryID)
        {

            


        }




        //Viewing all the data of Inserted Student in the datagrid view of Student.
        private void button4_Click(object sender, EventArgs e)
        {
            //Connection opoen
            sql.Open();
            string fun = "SELECT * FROM Student";
            SqlDataAdapter cmd = new SqlDataAdapter(fun, sql);
            DataTable dt = new DataTable();
            //Fill the table with the returning data of the fun query.
            cmd.Fill(dt);
            dataGridView1.DataSource = dt;
            //Connectioion close.

            sql.Close();

        }

        private void Status_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet.Student' table. You can move, or remove it, as needed.
         

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {





        }

        private void txt_FirstName_TextChanged(object sender, EventArgs e)
        {

        }

        //Deleting the studemt when clicking on the header of the row of datagrid view
        private void button5_Click(object sender, EventArgs e)
        {



            //Query of Deleting the Student.

            SqlCommand cmd = new SqlCommand("Delete from Student where ID=@id", sql);
            sql.Open();
            //Adding the value of ID ib @id variable. and using it for comparing the  deleting query
            //ID is the value of Id of Student which is to be deletd or compared.
            cmd.Parameters.AddWithValue("@id", ID);

            //Executing the Query

            cmd.ExecuteNonQuery();
            sql.Close();
            //Showing to be DEleted
            MessageBox.Show("Deleted");
            //Binding the result with dataTable of the dataGridView.
            sql.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Student", sql);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            sql.Close();
            //Removing all the values from textBoxes
            txt_FirstName.Text = "";
            txt_LastName.Text = "";
            txt_Contact.Text = "";
            txt_Email.Text = "";
            txt_regNo.Text = "";
            Status_ComboBox.Text = "";






        }
        //Rowheader event in which when we click on any rowheader of the row in dataGrid it will
        //show all the values of the selected header to the corresponding textboxex and the combobox.


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Taking the value of the selected row cell0 which contains the Id of the Student
            ID = Convert.ToInt32(txt_FirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //showing the value of FirstName to the related text Box
            txt_FirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //showing the value of LastName to the related text Box
            txt_LastName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //showing the value of Contact to the related text Box
            txt_Contact.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //showing the value of Email to the related text Box
            txt_Email.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //showing the value of registration Number to the related text Box
            txt_regNo.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //showing the value of Status to the related ComboBox which is taken form the Lookup table
            Status_ComboBox.Text = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()).ToString();


            

        }


        //Update the Student on click the row of desired Student 
        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_FirstName.Text != "" && txt_LastName.Text != "" && txt_Email.Text != "" && txt_Contact.Text != "")
            {

                string query2 = "Update Student set [FirstName]='" + txt_FirstName.Text + "' , [LastName]='" + txt_LastName.Text + "' , [Contact]='" + txt_Contact.Text + "', [Email]='" + txt_Email.Text + "', [RegistrationNumber]='" + txt_regNo.Text + "',Status= (Select LookupId from Lookup where Name='" + Status_ComboBox.Text + "') where ID=@id ";
                sql.Open();
                SqlCommand cmd2 = new SqlCommand(query2, sql);
                cmd2.Parameters.AddWithValue("@id", ID);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Updated");
                sql.Close();

                sql.Open();
                DataTable tt = new DataTable();


                SqlDataAdapter adap = new SqlDataAdapter("Select * from Student", sql);
                adap.Fill(tt);
                dataGridView1.DataSource = tt;


                sql.Close();

                //Removing all the values after upfating frfom the textBox.

                txt_FirstName.Text = "";
                txt_LastName.Text = "";
                txt_Contact.Text = "";
                txt_Email.Text = "";
                txt_regNo.Text = "";
                Status_ComboBox.Text = "";

            }
        }
        //Inserting the values of the CLO to the CLO table.
        private void button1_Click(object sender, EventArgs e)
        {
            sql.Open();
            //DateCreated is set datetime .Now because it gets the date when it created 
            //and update date is also using the dateTime.Now because it also gives the date when it is updating 
            //but now the date created remain the same
            string query3 = "Insert INTO Clo(Name,DateCreated,DateUpdated) VALUES('" + txt_CLO.Text + "','" + (DateTime.Now).Date + "','" + (DateTime.Now).Date + "')";
            SqlCommand cmd3 = new SqlCommand(query3, sql);
            cmd3.ExecuteNonQuery();
            sql.Close();


            MessageBox.Show("CLOS Added");
            Fill_ComboBox();
           
           

        }
        //Viewing all the data of the CLO
        private void button8_Click(object sender, EventArgs e)
        {

            sql.Open();
            string fun2 = "SELECT * FROM Clo";
            SqlDataAdapter cmd4 = new SqlDataAdapter(fun2, sql);
            DataTable dtt = new DataTable();
            cmd4.Fill(dtt);
            dataGridView2.DataSource = dtt;
            //connection is close.


            sql.Close();
            //Filling the comboBox with that values of CLO which are inserted 
            Fill_ComboBox();





        }
        //Deleting the rubric against the added CLO
        private void button6_Click(object sender, EventArgs e)
        {

            //First it delltes the Rubric related to the CLO and then delete the CLO of that table.
            //It will be deleted both from the CLO and the RUbric after viewing again the data of that module.
            sql.Open();
            SqlCommand cm = new SqlCommand("Delete  Rubric where CloId=@id ", sql);
            cm.Parameters.AddWithValue("@id", ID2);
            try
            {
                //Executing the query of Deletion
                cm.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Not deleted");
            }
            finally
            {
                sql.Close();
            }
            Fill_ComboBox();
            Fish();
       



            using (SqlCommand cmd = new SqlCommand("DELETE  Clo WHERE ID = @id", sql))
            {

                cmd.Parameters.AddWithValue("@id", ID2);
                sql.Open();
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    MessageBox.Show("Not Deleted");

                }
                finally
                {
                    sql.Close();

                }
                //Filling again the Combo Box
                Fill_ComboBox();
                Fish();
               
            }
            DataTable dt = new DataTable();
            SqlDataAdapter ado = new SqlDataAdapter("Select * from Clo", sql);
            ado.Fill(dt);
            dataGridView2.DataSource = dt;

        }









        //Rowheader click of the Rubric 
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //gettingthe value of the  id from the slected index of the clo
            ID2 = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            //CLOS are showing to the related textBox

            txt_CLO.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();



        }
        //updating the CLOS which we want it will also updated to all other tables .
        private void button7_Click(object sender, EventArgs e)
        {
            if (txt_CLO.Text != "")
            {
                //Updating the CLOS with another names
                string query7 = "Update Clo set [Name]='" + txt_CLO.Text + "' , [DateUpdated]='" + (DateTime.Now).Date + "'where ID=@id ";
                sql.Open();
                SqlCommand cmd6 = new SqlCommand(query7, sql);
                cmd6.Parameters.AddWithValue("@id", ID2);
                cmd6.ExecuteNonQuery();
                MessageBox.Show("Updated");
                sql.Close();
                sql.Open();
                DataTable t7 = new DataTable();


                SqlDataAdapter adapt = new SqlDataAdapter("Select * from Clo", sql);
                adapt.Fill(t7);
                dataGridView2.DataSource = t7;


                sql.Close();


                Fill_ComboBox();
                Fish();
               

                txt_CLO.Text = "";

            }


        }
        //Deleting the corresponding CLOS .I will also delete the rubrics from the rubric table.
        private void button11_Click(object sender, EventArgs e)
        {

            //First it will delete the Clo from the related table
            sql.Open();
            SqlCommand cm = new SqlCommand("Delete from Clo where Id=@id ", sql);

            cm.Parameters.AddWithValue("@id", cloid);
            try
            {
                cm.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Not deleted");
            }
            finally
            {
                sql.Close();
            }



            //then it deleted the rubric of that clos against its own table.
          
            using (SqlCommand cmd = new SqlCommand("DELETE  Rubric WHERE CloId = @id", sql))
            {

                cmd.Parameters.AddWithValue("@id", cloid);
                sql.Open();
                try
                {
                    cmd.ExecuteNonQuery();


                }
                catch
                {
                    MessageBox.Show("Not Deleted");

                }
                finally
                {
                    sql.Close();

                }

            }
            DataTable dt = new DataTable();
            SqlDataAdapter ado = new SqlDataAdapter("Select * from Rubric", sql);
            ado.Fill(dt);
            dataGridView3.DataSource = dt;







        }

        private void txt_allClo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        //Inserting the values into the Rubric atable in the sql server
        private void button9_Click(object sender, EventArgs e)
        {
            sql.Open();
            string query77 = "Insert INTO Rubric(Details,Cloid) VALUES('" + richtxt_CLO.Text + "',(Select Id from Clo where Id='" + txt_AllClos.SelectedValue + "'))";
            SqlCommand sq = new SqlCommand(query77, sql);
            sq.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Rubrics are added");
       
         
            Fill_ComboBox_of_AssessRubric();


        }
        //Viewing all thedata to the datgrid in the Rubric form
        private void button10_Click(object sender, EventArgs e)
        {

            sql.Open();
            string fun2 = "SELECT * FROM Rubric";
            SqlDataAdapter cmd5 = new SqlDataAdapter(fun2, sql);
            DataTable di = new DataTable();
            cmd5.Fill(di);
            dataGridView3.DataSource = di;
            sql.Close();
            MessageBox.Show("Click the row header of the grid to ADD the rubric level");
         
            
        }
        //On rowheader click of the datagrid it will select all the values to the corresponding fields.
        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //first  setting the value of combo Box with the selected CLO odf the table for easiness
            textBox2.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            //taking th vallue of the Rubric ID in the ID3
            //Populate the values to the corresponding fields
            ID3 = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
            richtxt_CLO.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            cloid = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString());
           
          
         
          


        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        //Adding the rubric level to the corresponding Rubric and the CLO
        private void button13_Click(object sender, EventArgs e)
        {
            //First it will insert the data into the Rubric to confirm that the data is placd in the Rubric which we
            //can add the level to it
            sql.Open();
            string query67 = "Insert INTO Rubric(Details,CloId) VALUES('" + richtxt_CLO.Text + "',(Select Id from Clo where Id='" + txt_AllClos.SelectedValue + "'))";
            SqlCommand s = new SqlCommand(query67, sql);
            s.ExecuteNonQuery();
            sql.Close();


            //Then it will adad the level otherwise it will be ethe insert anomaly
            sql.Open();
            string query78 = "Insert INTO RubricLevel(RubricId,Details,MeasurementLevel) VALUES((Select Id from Rubric where Id= '" + textBox2.Text + "'),'" + richTextBox2.Text + "','" + comboBox3.SelectedItem + "')";
            SqlCommand sq = new SqlCommand(query78, sql);
            sq.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Rubrics Levels  are added");
        }
        //Rubrics levels are shown to the table from which we have to be shown the level of that rubric.

        private void button14_Click(object sender, EventArgs e)
        {
            sql.Open();
            string fun3 = "SELECT * FROM RubricLevel";
            SqlDataAdapter cmd5 = new SqlDataAdapter(fun3, sql);
            DataTable di = new DataTable();
            cmd5.Fill(di);
            dataGridView4.DataSource = di;



            sql.Close();


        }

        private void button16_Click(object sender, EventArgs e)
        {
            //Deleting the rubric level
            using (SqlCommand cmd = new SqlCommand("DELETE  RubricLevel WHERE Id= @id", sql))
            {

                cmd.Parameters.AddWithValue("@id", ID3);
                sql.Open();
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch
                {
                    MessageBox.Show("Not Deleted");

                }
                finally
                {
                    sql.Close();

                }

            }
            DataTable dt = new DataTable();
            SqlDataAdapter ado = new SqlDataAdapter("Select * from RubricLevel", sql);
            ado.Fill(dt);
            dataGridView4.DataSource = dt;

        }





        //On row header click of the Rubriclevel datagrid view it will show the values to the correspondoing
        //fields.
        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            ID3 = Convert.ToInt32(dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox2.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
            richTextBox2.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();




        }
        //Updating the rubric levels
        private void button15_Click(object sender, EventArgs e)
        {
            string query22 = "Update RubricLevel set [Details]='" + richTextBox2.Text + "' ,[MeasurementLevel]='" + comboBox3.SelectedItem + "' where Id=@id ";
            sql.Open();
            SqlCommand cmd6 = new SqlCommand(query22, sql);
            cmd6.Parameters.AddWithValue("@id", ID3);
            cmd6.ExecuteNonQuery();
            MessageBox.Show("Updated");
            sql.Close();

            sql.Open();
            DataTable t7 = new DataTable();


            SqlDataAdapter adapt = new SqlDataAdapter("Select * from RubricLevel", sql);
            adapt.Fill(t7);
            dataGridView4.DataSource = t7;


            sql.Close();






        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_FirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation of the First Name
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                base.OnKeyPress(e);
                MessageBox.Show("Only Alphabets are allowed in this field");
            }

        }

        private void txt_LastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation of the Last Name
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                base.OnKeyPress(e);
                MessageBox.Show("Only Alphabets are allowed in this field");
            }

        }

        private void txt_Contact_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validation of the PhoneNumber
            if (e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                base.OnKeyPress(e);
                MessageBox.Show("Only Digits are allowed in this field");
            }
            if (txt_Contact.Text.Length == 11)
            {
                e.Handled = true;
                base.OnKeyPress(e);
                MessageBox.Show("Phone Number contains only 11 digits");
            }
        }

        private void txt_Email_TextChanged(object sender, EventArgs e)
        {



        }

        private void txt_Email_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_Email_CausesValidationChanged(object sender, EventArgs e)
        {

        }

        private void txt_Email_Validated(object sender, EventArgs e)
        {

        }

        private void txt_Email_Validating(object sender, CancelEventArgs e)
        {
            //Validation of the Email

            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-z)-9]@[a-zA-z0-9][\w\.-]*[a-zA-z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txt_Email.Text.Length > 0 && txt_Email.Text.Trim().Length != 0)
            {
                if (!rEmail.IsMatch(txt_Email.Text.Trim()))
                {
                    MessageBox.Show("Please enter the valid Email adress");
                    txt_Email.SelectAll();
                    e.Cancel = true;

                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (txt_AllClos.Text != "")
            {
                //Updating the rubrics against the Rubric.
                string query7 = "Update Rubric set [Details]='" + richtxt_CLO.Text + "' ,[CloID]='"+txt_AllClos.SelectedValue+"' where Id=@id ";
                sql.Open();
                SqlCommand cmd6 = new SqlCommand(query7, sql);
                cmd6.Parameters.AddWithValue("@id", ID3);
                cmd6.ExecuteNonQuery();
                MessageBox.Show("Updated");
                
              
                DataTable t7 = new DataTable();


                SqlDataAdapter adapt = new SqlDataAdapter("Select * from Rubric", sql);
                adapt.Fill(t7);
                dataGridView3.DataSource = t7;


                sql.Close();

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Inserting the Data of assessment in the Student table in Sql Server.
            sql.Open();
            string query = "INSERT INTO Assessment (Title,DateCreated,TotalMarks,TotalWeightage) VALUES('" + textBox1.Text + "','" + (DateTime.Now).Date + "','" + textBox4.Text+ "','" + textBox5.Text + "')";
            SqlDataAdapter foo = new SqlDataAdapter(query, sql);

            //Executing the query 
            foo.SelectCommand.ExecuteNonQuery();
            //Closing the Connection,
            sql.Close();
            //Showing that the data is inserted successfully.
            MessageBox.Show("Data Inserted Successfully");
            Fill_ComboBox_of_Assignment_();
            Fill_ComboBox_Assess_result();

            
     
        }

        private void button18_Click(object sender, EventArgs e)
        {
            sql.Open();
            string fun3 = "SELECT * from Assessment";
            SqlDataAdapter cmd5 = new SqlDataAdapter(fun3, sql);
            DataTable di = new DataTable();
            cmd5.Fill(di);
            dataGridView5.DataSource = di;



            sql.Close();
            
            Fill_ComboBox_of_Assignment_();
            Fill_ComboBox_Assess_result();
            MessageBox.Show("Click the row header of the datagrid view to proceed the result");
         

        }



        private void button20_Click(object sender, EventArgs e)
        {
           
            sql.Open();
            string fun3 = "SELECT * from AssessmentComponent";
            SqlDataAdapter cmd5 = new SqlDataAdapter(fun3, sql);
            DataTable di = new DataTable();
            cmd5.Fill(di);
            dataGridView6.DataSource = di;

            sql.Close();
            Fill_ComboBox_of_Assignment_();
            
            //Fill_ComboBox_Assesscomp_result();
            

        }

        private void button21_Click(object sender, EventArgs e)
        {
            //Inserting the Data of attendance in the Class attendance table in Sql Server.
            sql.Open();
            string query = "INSERT INTO ClassAttendance (AttendanceDate) VALUES('" +dateTimePicker1.Value.Date+"')";
            SqlDataAdapter foo = new SqlDataAdapter(query, sql);

            //Executing the query 
            foo.SelectCommand.ExecuteNonQuery();
            //Closing the Connection,
            sql.Close();
            //Showing that the data is inserted successfully.
            MessageBox.Show("Data Inserted Successfully");
           

        }

        private void button22_Click(object sender, EventArgs e)
        {
            sql.Open();
            string fun3 = "SELECT * from ClassAttendance";
            SqlDataAdapter cmd5 = new SqlDataAdapter(fun3, sql);
            DataTable di = new DataTable();
            cmd5.Fill(di);
            dataGridView7.DataSource = di;

            sql.Close();
            MessageBox.Show("Click the row header of the header to proceed the student Attendance");
                
        }

        private void comboBox5_DropDownClosed(object sender, EventArgs e)
        {
      

        }

        private void comboBox7_DropDownClosed(object sender, EventArgs e)
        {

          

        }

        private void button23_Click(object sender, EventArgs e)
        {
            //Inserting the Data of reslt in the result table in Sql Server.
            sql.Open();
           string query = "INSERT INTO StudentResult (StudentId,AssessmentComponentId,RubricMeasurementId,EvaluationDate) VALUES('" + dateTimePicker1.Value + "')";
            SqlDataAdapter foo = new SqlDataAdapter(query, sql);

            //Executing the query 
            foo.SelectCommand.ExecuteNonQuery();
            //Closing the Connection,
            sql.Close();
            //Showing that the data is inserted successfully.
            MessageBox.Show("Data Inserted Successfully");

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedValue.ToString() != "")

            {

                int CountryID = Convert.ToInt32(comboBox7.SelectedValue.ToString());
                FillStates(CountryID);
                

            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql.Open();
            int c = Convert.ToInt32(comboBox5.SelectedValue.ToString());
            
            SqlCommand k = new SqlCommand("select * from AssessmentComponent where Id='" + Convert.ToString(comboBox5.SelectedValue) + "'", sql);
            SqlDataReader reader=k.ExecuteReader();

            
            while (reader.Read())
            {
                string name = (string)reader["Name"];
                string h = reader["RubricId"].ToString();
                string w = reader["TotalMarks"].ToString();
                textBox8.Text = h;
                textBox10.Text = w;

            }

            reader.Close();


            
            int p = Convert.ToInt32(textBox8.Text.ToString());

            SqlCommand cmd = new SqlCommand("select * from RubricLevel where RubricId=@c", sql);
            cmd.Parameters.AddWithValue("@c", p);
            SqlDataReader t = cmd.ExecuteReader();


            while (t.Read())
            {

                h = t["MeasurementLevel"].ToString();
                textBox6.Text = h;
            }

            t.Close();

            Fish();
           
  
            sql.Close();



            using (SqlConnection cn = new SqlConnection(@"Data Source=HP-PC\SQLEXPRESS;Initial Catalog=ProjectB;Integrated Security=True;MultipleActiveResultSets=True"));
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


       
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
       

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void button19_Click_1(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
        
            string s = comboBox2.SelectedText;
            int u = Convert.ToInt32(textBox4.Text);


            int y = Convert.ToInt32(textBox7.Text);
            sum = sum + y;
       
            if (sum < u)
            { 
            
                //Inserting the Data of assessment in the Student table in Sql Server.
                sql.Open();
                string query = "INSERT INTO AssessmentComponent (Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) VALUES('" + textBox3.Text + "','" + comboBox6.SelectedValue + "','" + textBox7.Text + "','" + (DateTime.Now).Date + "','" + (DateTime.Now).Date + "',(select Id from Assessment where Id='" + comboBox2.SelectedValue + "'))";
                SqlDataAdapter foo = new SqlDataAdapter(query, sql);

                //Executing the query 
                foo.SelectCommand.ExecuteNonQuery();
                //Closing the Connection,
                sql.Close();
                //Fill_ComboBox_Assesscomp_result();
                
                //Fill_ComboBox_of_AssessRubric();


                MessageBox.Show("Again add the Component of the same assessment");
            }
            else if (sum > u)
            {

                //Showing that the data is inserted successfully.
                MessageBox.Show("Number already added");

            }
            else
            {
                //Inserting the Data of assessment in the Student table in Sql Server.
                sql.Open();
                string query = "INSERT INTO AssessmentComponent (Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) VALUES('" + textBox3.Text + "','" + comboBox6.SelectedValue + "','" + textBox7.Text + "','" + (DateTime.Now).Date + "','" + (DateTime.Now).Date + "',(select Id from Assessment where Id='" + comboBox2.SelectedValue + "'))";
                SqlDataAdapter foo = new SqlDataAdapter(query, sql);

                //Executing the query 
                foo.SelectCommand.ExecuteNonQuery();
                //Closing the Connection,
                sql.Close();
                //Fill_ComboBox_Assesscomp_result();
                //Fill_ComboBox_of_Assignment_();
                //Fill_ComboBox_of_AssessRubric();
                MessageBox.Show("Data Inserted Successfully");
                

            }
          
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
         

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_Click(object sender, EventArgs e)
        {




        }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
           
  
        }

        private void button24_Click(object sender, EventArgs e)
        {
            sql.Open();
            string fun3 = "SELECT AssessmentComponent.Name AS Component ,Rubric.Details AS Rubric, AssessmentComponent.TotalMarks AS Component_Marks,((RubricLevel.MeasurementLevel*AssessmentComponent.TotalMarks)/4) AS ObtainedMarks,Student.FirstName,Student.Id  from StudentResult inner join Student on Student.Id=StudentResult.StudentId and Student.Id='" + comboBox4.SelectedValue + "' left join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id left join Rubric on Rubric.Id=AssessmentComponent.RubricId left join RubricLevel on  RubricLevel.Id=StudentResult.RubricMeasurementId";

            SqlDataAdapter numpy = new SqlDataAdapter(fun3, sql);

            DataTable design = new DataTable();
            numpy.Fill(design);
            dataGridView8.DataSource = design;
            sql.Close();


        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            textBox1.Text = dataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView5.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            //Inserting the Data of assessment in the Student table in Sql Server.
            sql.Open();
            string query = "INSERT INTO StudentAttendance (AttendanceId,StudentId,AttendanceStatus) VALUES('" + textBox9.Text + "','" + comboBox1.SelectedValue +"',(select LookupId from Lookup where Name='"+comboBox8.Text+"'))";
            SqlDataAdapter foo = new SqlDataAdapter(query, sql);

            //Executing the query 
            foo.SelectCommand.ExecuteNonQuery();
            //Closing the Connection,
            sql.Close();
            //Showing that the data is inserted successfully.
            MessageBox.Show("Data Inserted Successfully");
           

        }

        private void dataGridView7_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox9.Text = dataGridView7.Rows[e.RowIndex].Cells[0].Value.ToString();
        

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            sql.Open();
            string fun3 = "SELECT * from StudentAttendance";
            SqlDataAdapter cmd5 = new SqlDataAdapter(fun3, sql);
            DataTable di = new DataTable();
            cmd5.Fill(di);
            dataGridView9.DataSource = di;

            sql.Close();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("Assessment.pdf", FileMode.Create));
            doc.Open();


            PdfPTable table = new PdfPTable(dataGridView8.Columns.Count);
            for (int j = 0; j < dataGridView8.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView8.Columns[j].HeaderText));

            }
            table.HeaderRows = 1;
            for (int k = 0; k < dataGridView8.Rows.Count; k++)
            {
                for (int w = 0; w < dataGridView8.Columns.Count; w++)
                {
                    if (dataGridView8[w, k].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView8[w, k].Value.ToString()));

                    }

                }
            }
            doc.Add(table);
            doc.Close();


        }

        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {



         

       
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            sql.Open();

            string fun3 = "SELECT Clo.Name AS CLO ,Rubric.Details AS Rubric, AssessmentComponent.TotalMarks AS Component_Marks, RubricLevel.MeasurementLevel AS Student_Rubric_Level ,((RubricLevel.MeasurementLevel*AssessmentComponent.TotalMarks)/4) AS ObtainedMarks from (((Clo inner join Rubric on Clo.Id=Rubric.CloId) inner join AssessmentComponent on Rubric.Id=AssessmentComponent.RubricId)inner join RubricLevel on  Rubric.Id=RubricLevel.RubricId)";
            SqlDataAdapter numpy = new SqlDataAdapter(fun3, sql);

            DataTable design = new DataTable();
            numpy.Fill(design);
            dataGridView10.DataSource = design;
            sql.Close();
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            sql.Open();
            //DateCreated is set datetime .Now because it gets the date when it created 
            //and update date is also using the dateTime.Now because it also gives the date when it is updating 
            //but now the date created remain the same
            string query3 = "Insert INTO StudentResult(StudentId,AssessmentComponentId,RubricMeasurementId,EvaluationDate) VALUES((select Id from Student where Id='"+comboBox4.SelectedValue+"'),(select Id from AssessmentComponent where Id='"+comboBox5.SelectedValue+"' ),(select Id from RubricLevel where RubricId='"+textBox8.Text+"'),'"+dateTimePicker2.Value.Date+"')";
            SqlCommand cmd3 = new SqlCommand(query3, sql);
            cmd3.ExecuteNonQuery();
            sql.Close();


            MessageBox.Show(" Added");
           
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("CLO.pdf", FileMode.Create));
            doc.Open();


            PdfPTable table = new PdfPTable(dataGridView10.Columns.Count);
            for (int j = 0; j < dataGridView10.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView10.Columns[j].HeaderText));

            }
            table.HeaderRows = 1;
            for (int k = 0; k < dataGridView10.Rows.Count; k++)
            {
                for (int w = 0; w < dataGridView10.Columns.Count; w++)
                {
                    if (dataGridView10[w, k].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView10[w, k].Value.ToString()));

                    }

                }
            }
            doc.Add(table);
            doc.Close();

        }
    }
}

    

