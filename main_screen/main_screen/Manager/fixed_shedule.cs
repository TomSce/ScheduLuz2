﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using USER;
using database_location;
using System.IO;
using check_funcs;


namespace main_screen.Manager
{
    public partial class fixed_schedule : Form
    {
        public fixed_schedule()
        {
            InitializeComponent();
        }

        private void fixed_schedule_Load(object sender, EventArgs e)
        {
            for(int i=0; i<8; i++)
            {
                schedule.Rows.Add((i + 8),(i+9));
            }

           
        }

        private void to_txt_TextChanged(object sender, EventArgs e)
        {
            dataBase dataBase = new dataBase();
            SqlConnection con = dataBase.connect_to_scheduluz_DB();
            string query = "Select id,name,lastName from users Where permission = 'teacher'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtb = new DataTable();
            sda.Fill(dtb);

            teachers_lst.Items.Clear();

            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                string temp = dtb.Rows[i]["name"].ToString().Trim().ToUpper() + " " + dtb.Rows[i]["lastName"].ToString().Trim().ToUpper();

                if (temp.Contains(teacher_name_txt.Text.ToUpper()))
                {
                    teachers_lst.Items.Add(dtb.Rows[i]["name"].ToString().Trim() + " " + dtb.Rows[i]["lastName"].ToString().Trim());
                }
            }
        }

        private void student_lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = teachers_lst.SelectedIndex;
                teacher_name_txt.Text = teachers_lst.Items[index].ToString();
            }
            catch
            {

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            /*
             * for teachers we will use their ID
             * for classes we will use the fromat class-classNum:
             * like this : 10-3
             * wich means 10th year class number 3
             * 
             */

            /*
             * for teacher:
             */

            string username = teacher_name_txt.Text.Replace(" ", "");

            dataBase dataBase = new dataBase();
            SqlConnection con = dataBase.connect_to_scheduluz_DB();
            string query = "Select id from connection_details Where userName = '" + username + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            string userID = dtbl.Rows[0][0].ToString().Trim(); // getting the userID

            query = "Select wEvent_id from weekly_events Where user_id_OR_class = '" + userID + "' and day_in_week='" + days.Text + "'";
            sda = new SqlDataAdapter(query, con);
            dtbl = new DataTable();
            sda.Fill(dtbl);
            con.Close();  //gets all the event this day

            if (dtbl.Rows.Count >= 0)
            {
                for (int i = 0; i < 8; i++) // max 8 hours in the schedule
                {
                    dataBase = new dataBase();
                    con = dataBase.connect_to_scheduluz_DB();
                    query = "Select wEvent_id from weekly_events Where user_id_OR_class = '" + userID + "' and day_in_week='"+days.Text+"' and start='"+ schedule["startTime", i].Value.ToString().Trim() + "'";
                    sda = new SqlDataAdapter(query, con);
                    dtbl = new DataTable();
                    sda.Fill(dtbl);


                    if (schedule[2, i].Value != null)
                    {
                        if(dtbl.Rows.Count > 0)
                        {
                            dataBase = new dataBase();
                            SqlConnection conn = dataBase.connect_to_scheduluz_DB();
                            conn.Open();
                            SqlCommand cmd1 = new SqlCommand("UPDATE weekly_events SET title ='" + schedule[2, i].Value.ToString() + "' WHERE day_in_week ='" + days.Text + "' and start='" + schedule[0, i].Value.ToString() + "' and user_id_OR_class='" + userID + "'", conn);
                            cmd1.ExecuteNonQuery();
                            conn.Close();
                        }
                        else
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO weekly_events(user_id_OR_class,day_in_week,start,ends,title) VALUES(@user_id_OR_class,@day_in_week,@start,@ends,@title) ", con);

                            cmd.Parameters.Add("@user_id_OR_class", userID);
                            cmd.Parameters.Add("@day_in_week", days.Text);
                            cmd.Parameters.Add("@start", schedule[0, i].Value.ToString());
                            if (schedule[2, i].Value != null)

                                cmd.Parameters.Add("@ends", schedule[1, i].Value.ToString());
                            cmd.Parameters.Add("@title", schedule[2, i].Value.ToString());
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                   
                        
                    }
                    else
                    {
                        //delete the event from the DB

                       
                        try
                        {
                            dataBase = new dataBase();
                            SqlConnection conn = dataBase.connect_to_scheduluz_DB();
                            conn.Open();
                            SqlCommand cmd1 = new SqlCommand("DELETE FROM weekly_events WHERE day_in_week ='" + days.Text + "' and start='" + schedule[0, i].Value.ToString() + "' and user_id_OR_class='" + userID + "'", conn);
                            cmd1.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                        
                    }
                }
                //// the problem is that its inserting OR updating not both.
            }
            else
            {
                for (int i = 0; i < 8; i++) // max 8 hours in the schedule
                {
                    if (schedule[2, i].Value != null)
                    {
                        dataBase = new dataBase();
                        SqlConnection conn = dataBase.connect_to_scheduluz_DB();
                        conn.Open();
                        SqlCommand cmd1 = new SqlCommand("UPDATE weekly_events SET title ='" + schedule[2, i].Value.ToString() + "' WHERE day_in_week ='" + days.Text + "' and start='"+ schedule[0, i].Value.ToString()+"' and user_id_OR_class='"+userID+"'", conn);
                        cmd1.ExecuteNonQuery();
                    }
                    else
                    {
                        try
                        {
                            dataBase = new dataBase();
                            SqlConnection conn = dataBase.connect_to_scheduluz_DB();
                            conn.Open();
                            SqlCommand cmd1 = new SqlCommand("DELETE FROM weekly_events WHERE day_in_week ='" + days.Text + "' and start='" + schedule[0, i].Value.ToString() + "' and user_id_OR_class='" + userID + "'", conn);
                            cmd1.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                    }
                }
            }


            User user = new User();
            user = user.GetUser(userID);
            MessageBox.Show(user.getName() + " " + user.getLastName() + ": Schedule updated.");

            

        }

        private void days_SelectedIndexChanged(object sender, EventArgs e)
        {
            string username = teacher_name_txt.Text.Replace(" ", "");

            dataBase dataBase = new dataBase();
            SqlConnection con = dataBase.connect_to_scheduluz_DB();
            string query = "Select id from connection_details Where userName = '" + username + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count > 0)
            {
                string userID = dtbl.Rows[0][0].ToString().Trim();


                query = "Select  start,title from weekly_events Where user_id_OR_class = '" + userID + "' and day_in_week='" + days.Text + "'";
                sda = new SqlDataAdapter(query, con);
                dtbl = new DataTable();
                sda.Fill(dtbl);
                con.Close();
                for (int i = 0; i < dtbl.Rows.Count; i++)
                {
                    schedule["profassionORclass", Int32.Parse(dtbl.Rows[i][0].ToString().Trim()) - 8].Value = dtbl.Rows[i]["title"].ToString().Trim();
                }
            }


        }

        private void return_btn_Click(object sender, EventArgs e)
        {
            ManagerCalander n = new ManagerCalander();
            this.Hide();
            n.Show();
        }
    }
}