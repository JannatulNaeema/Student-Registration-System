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
using System.Xml.Linq;

namespace studentregistration
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Load();
        }
        sqlConnection con = new sqlConnection("Data Source+LAPTOP-CICTRR6T-PC;Initial catalog=gcbt; User Id=sa;Password=12345);

        sqlCommand cmd;
        SqlDataReader read;
        SqlDataAdapter drr;
        string id;
        bool Mood = true;
        string sql;
        // if the mood is true means add records otherwise update the record
        public void Load()
        {
            try
            {
                sql = "select * from student";
                Cmd = new SqlCommand(sql, con);
                con.open();
                read = Cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (read.Read())
                {
                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getID(string id)
        {
            sql = "select * from student where id=" + id + "'"};
            cmd=new SqlCommand(SqlCommand, con);
            con.open();
            read =cmd.ExecuteReader();
            while(read.Read))
            {
            txtName.Text= read[1].ToString();
            txtCourse.Text=read[2].ToString();
            txtFee = read[3]. ToString();
    }
          con.Close();

        }

         privatervoid button1_click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string course = txtCourse.Text;
            string Fee = txtFee.Text;

            if (Mood == true)
            {
                sql = "insert into student (stname,course,fee)values(@stname,@course,@fee"};
            con.open();
            Cmd = new SqlCommand(sql, con);
            Cmd.parameters.AddwithValue("@stname", name);
            Cmd.parameters.AddwithValue("@course", course);
            Cmd.parameters.AddwithValue("@fee", fee);
            MessageBox.Show("Record Addeded");
            Cmd().ExecuteNonQuery();


            txtName.Clear();
            txtCourse.Clear();
            txtFee.Clear();
            txtName.Focus();


        }
        else
        {
             id=dataGridView1.CurrentRow.Cells[0].value.ToString();
             sql = "update student set stname =@stname,course=@course,fee=@fee where id=@id";
             con.open();
             cmd= new SqlCommand(Sql,Con);
             Cmd.parameters.AddwithValue("@stname", name);
             Cmd.parameters.AddwithValue("@course", course);
             Cmd.parameters.AddwithValue("@fee", fee);
             MessageBox.Show("Record Addeded");
            Cmd().ExecuteNonQuery();


                 txtName.Clear();
                 txtCourse.Clear();
                 txtFee.Clear();
                 txtName.Focus();
                 button1.Text="save";
                 Mode = true;
    }

              
        
     private void dataGridView1_ cell contentClick(object sender,DataGridViewCellEventArgs e)
       {   
       if(e.ColumnIndex == dataGridView1.Columns["Edit"]). Index && e.RowIndex >=0)
       {
             Mode = false;
             id = DataGridView1.CurrentRow.cells[0].value.ToString();
             getID(id);
             button1.Text = "Edit";
       }
         else if(e.ColumnIndex == DataGridView1.Column["Delete"]).Index && e.RowIndex>=0)
         {
            Mode = false;
            id = DataGridView1.CurrentRow.cells[0].value.ToString();
            Sql = "delete from student where =@id";
            con.open();
            cmd = new SqlCommand(Sql, con);
            cmd.Parameters.AddwithValue("@id", id);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deletee");
            con.Close();      
           
         }
    
     }
         private void button2_click(object sender,EventArges e)
        {
         Load();
        }
         private void button3_click(object sender,EventArges e)
        {
         txtName.Clear();
         txtCourse.Clear();
         txtFee.clear();
         txtName.Focus();
         button1,Text = "save";
         Node= true;
}

  }
}