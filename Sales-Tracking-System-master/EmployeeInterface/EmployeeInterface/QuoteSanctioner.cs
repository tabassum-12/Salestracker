using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EmployeeInterface
{
    class QuoteSanctioner
    {
		private MySqlConnection connection;
		private List<Quote> quoteList = new List<Quote>();
		private Quote activeQuote;

		//constructor for initialization
		public QuoteSanctioner()
		{
			//connection string and connect to the db
			string strConn = "port=3306;server=50.165.81.108;user id=Kevin;password=ak4iulgjMwAShNX9rWsp;database=salestracking;";
			connection = new MySqlConnection(strConn);
		}

        public List<Quote> searchCustomer(string name)
        {
			getAllQuotes(name);

			return quoteList;
        }

		public List<Quote> searchQuote(string name)
        {
			getAllQuoteNames(name);

			return quoteList;
        }

		public void selectQuote(Quote quote)
        {
			activeQuote = quote;
			getQuoteItems();
        }

		public void submitQuote(List<Item> itemList, string quoteName, string email, float discount, bool sanctioned, List<string> notes)
        {
			//string for mysql query
			string query;
			MySqlCommand cmd;
			int sanct;

			//connect to the db
			if (this.connect())
			{
				for (int i = 0; i < itemList.Count; i++)
				{
					if (itemList[i].getId() != 0)
					{
						query = "UPDATE item SET description='" + itemList[i].getDescription() + "',price='" + itemList[i].getPrice() + "' WHERE id='" + itemList[i].getId()+"'";
						cmd = new MySqlCommand(query, connection);
						cmd.ExecuteNonQuery();
					}
					else
					{
						query = "INSERT INTO item (price,description,qid) VALUES (" + itemList[i].getPrice() + ",'" + itemList[i].getDescription() + "','" +activeQuote.getId() +"')";
						cmd = new MySqlCommand(query, connection);
						cmd.ExecuteNonQuery();
					}
				}
				if (sanctioned)
					sanct = 1;
				else
					sanct = 0;
				query = "UPDATE quote SET name='" + quoteName + "',email='" + email + "',discount='" + discount + "',total='" + (activeQuote.getCurrentTotalPrice() - activeQuote.getDiscount()) + "',sanctioned='" + sanct + "' WHERE id='" + activeQuote.getId() + "'";
				cmd = new MySqlCommand(query, connection);
				cmd.ExecuteNonQuery();

				//insert secret notes into the db
				for (int i = 0; i < notes.Count; i++)
				{
					if (notes[i] != "")
					{
						query = "INSERT INTO secretnotes (note,qid) VALUES ('" + notes[i] + "','" + activeQuote.getId() + "')";
						cmd = new MySqlCommand(query, connection);
						cmd.ExecuteNonQuery();
					}
				}
			}
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

		//Function: void getAllQuotes(name)
		//Purpose:  retrieves all of the quotes from the db via customer name
		private void getAllQuotes(string name)
		{
			quoteList.Clear();
            string query = "SELECT * FROM quote";

			//connect to the db and retrieve the data
			if (this.connect())
			{
				//execute the query
				MySqlCommand cmd = new MySqlCommand(query, connection);
				MySqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					//create new quotes using the data read
					if ((dr["custName"] + "").Contains(name) && dr.GetFloat(6) != 1)
						quoteList.Add(new Quote(dr.GetInt32(9), dr["name"] + "", dr["custName"] + "", dr["email"] + "", dr.GetInt32(3), dr.GetFloat(4), dr.GetFloat(5), dr.GetFloat(6)));
				}
				dr.Close();
			}
			this.stopConnection();
		}

		//Function: void getAllQuoteNames(name)
		//Purpose:  retrieves all of the quotes from the db via quote name00.
		private void getAllQuoteNames(string name)
		{
			quoteList.Clear();
			//query
			string query = "SELECT * FROM quote";

			//connect to the db and retrieve the data
			if (this.connect())
			{
				//execute the query
				MySqlCommand cmd = new MySqlCommand(query, connection);
				MySqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					//create new quotes using the data read
					if ((dr["name"] + "").Contains(name) && dr.GetFloat(6) != 1)
						quoteList.Add(new Quote(dr.GetInt32(9), dr["name"] + "", dr["custName"] + "", dr["email"] + "", dr.GetInt32(3), dr.GetFloat(4), dr.GetFloat(5), dr.GetFloat(6)));
				}
				dr.Close();
			}
			this.stopConnection();
		}

		//Function: void getQuoteItems()
		//Purpose:  retrieves the items for the active quote from the db and places them in the quote
 		private void getQuoteItems()
		{
			List<Item> items = new List<Item>();
			string query = "SELECT * FROM item WHERE qid = '" + activeQuote.getId() + "'";

			//connect to the db and retrieve the data
			if (this.connect())
			{
				//execute the query
				MySqlCommand cmd = new MySqlCommand(query, connection);
				MySqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					items.Add(new Item(dr.GetInt32(0), dr.GetInt32(3), dr["description"] + "", dr.GetFloat(2)));
				}
				dr.Close();
			}

			activeQuote.setQuoteItems(items);

			this.stopConnection();
		}

		public Quote getActiveQuote()
		{
			return activeQuote;
		}

		public void deleteItem(Item item)
		{
			string query = "DELETE FROM item WHERE id='" + item.getId() + "'";

			if (this.connect())
			{
				MySqlCommand cmd = new MySqlCommand(query, connection);
				cmd.ExecuteNonQuery();
			}

			this.stopConnection();
		}

		public void getSecretNotes()
		{
			string query = "SELECT * FROM secretnotes WHERE qid='" + activeQuote.getId() + "'";
			List<string> notes = new List<string>();
			List<int> ids = new List<int>();

			if (this.connect())
			{
				MySqlCommand cmd = new MySqlCommand(query, connection);
				MySqlDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					notes.Add(dr["note"] + "");
					ids.Add(dr.GetInt32(2));
				}
			}
			activeQuote.setNotes(notes);
			activeQuote.setNoteIds(ids);

			this.stopConnection();
		}
    }
}
