﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sport_App
{
    public partial class AddPlayerForm : Form
    {
        public AddPlayerForm()
        {
            InitializeComponent();
        }

        private void bt_addplayer_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                //step 1: create connection
                
                con.ConnectionString = @"Data Source=DESKTOP-7J9ODH9;Initial Catalog=SportDB;Integrated Security=True;Pooling=False";
                //step 2 : open connection
                con.Open();
                //srep 3: create Command
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Player values(@tshirtNumer,@name,@position,@goals)";
                cmd.CommandType = CommandType.Text;//deault value is Text
                cmd.Connection = con;

                //ou bien 
                /* cmd = new SqlCommand("insert into Player values(@Id,@name,@position,@goals)", con);*/
                //affectation d'une valeur au premier paramètre @ID
                /*cmd.Parameters.Add("@tshirtNumer", SqlDbType.Int);
                cmd.Parameters[0].Value = int.Parse(txt_tshirtNumber.Text);
                */
                //les deux lignes precédentes peuvent être remplacer par la ligne qui suit
                cmd.Parameters.AddWithValue("@tshirtNumer", int.Parse(txt_tshirtNumber.Text));

                cmd.Parameters.AddWithValue("@name", txt_nameplayer.Text);
                cmd.Parameters.AddWithValue("@position", txt_poistionplayer.Text);
                cmd.Parameters.AddWithValue("@goals", int.Parse(txt_goals.Text));
                //step 4 :execute command
                cmd.ExecuteNonQuery(); //case of insert or update or delete
                /*cmd.ExecuteReader();// case of select*/
                MessageBox.Show("Player has been added...");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                //step 5 : close the connection 
                if (con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }
           
        }
    }
}
