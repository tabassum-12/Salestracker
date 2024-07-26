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

namespace EmployeeInterface
{
	public partial class Authentication : Form
	{
		private MySqlConnection connection;
		private bool valid = false;
        private string admin;
		private int counter = 0;

		public Authentication()
		{
			InitializeComponent();
			//connection string and connect to the db
			string strConn = "port=3306;server=50.165.81.108;user id=Kevin;password=ak4iulgjMwAShNX9rWsp;database=salestracking;";
			connection = new MySqlConnection(strConn);
		}

		//Function: validate()
		//Purpose:  Validates login credentials in order to access the employee interface
		//Returns:  True if validation is successful
		private void validate()
		{
			//int for counting
			int i = 0;

			//list for results
			List<string>[] rs = new List<string>[3];
			rs[0] = new List<string>();
			rs[1] = new List<string>();
			rs[2] = new List<string>();

			//query
			string query = "SELECT * FROM employees";

			//connect to the db and retrieve the data
			if (this.connect())
			{
				//execute the query
				MySqlCommand cmd = new MySqlCommand(query, connection);
				MySqlDataReader dr = cmd.ExecuteReader();
				
                while (dr.Read())
				{
					rs[0].Add(dr["id"] + "");
					rs[1].Add(dr["password"] + "");
					rs[2].Add(dr["admin"] + "");
				}
			}

			//validate the id
			while (!valid)
			{
				//validate the id and pw
				if (rs[0][i] == idTextBox.Text && rs[1][i] == passwordTextBox.Text)
                {
                    admin = rs[2][i];
					valid = true;
                }

                if (i < rs[0].Count - 1)
                {
                    i++;
                }
                else
                {
                    break;
                }
			}

			if (!valid)
			{
				MessageBox.Show("Either your ID or password is incorrect.");
			}

			//close the connection
			this.stopConnection();
		}

		//function: bool connect()
		//purpose:  opens a connection to the employee database in order to validate credentials
		//returns:  true if connection works, false if connection fails
		private bool connect()
		{
			try
			{
				connection.Open();
				return true;
			}
			//bullshit exceptions
			catch (MySqlException ex)
			{

				return false;
			}
		}

		//function: bool stopConnection()
		//purpose:  stops the connection to the database
		//returns:  true if disconnection succeeds
		private void stopConnection()
		{
			connection.Close();
		}

		//Function: void loginButton_Click()
		//Purpose:  Handles clicking of the login button and provides verification of the login.
		private void loginButton_Click(object sender, EventArgs e)
		{
			if (counter < 5)
			{
				this.validate();
				counter++;
			}
			else if (counter >= 5)
				MessageBox.Show("You are out of login attempts. Please try again later.");
			if (this.isValid())
				Dispose();
		}

		//Function: bool isValid()
		//Purpose:  returns whether the login is valid or not
		public bool isValid()
		{
			return valid;
		}

        public bool isAdmin()
        {
            if(admin == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}
