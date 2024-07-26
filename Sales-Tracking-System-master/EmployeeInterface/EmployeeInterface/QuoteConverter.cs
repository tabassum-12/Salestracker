using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace EmployeeInterface
{
    class QuoteConverter
    {
        Quote activeQuote;
        private List<Quote> quoteList = new List<Quote>();
        private MySqlConnection connection;

        public QuoteConverter()
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
        }

        public Quote getActiveQuote()
        {
            return activeQuote;
        }

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
                    if ((dr["custName"] + "").Contains(name) && dr.GetFloat(6) == 1)
                        quoteList.Add(new Quote(dr.GetInt32(9), dr["name"] + "", dr["custName"] + "", dr["email"] + "", dr.GetInt32(3), dr.GetFloat(4), dr.GetFloat(5), dr.GetFloat(6)));
                }
                dr.Close();
            }
            this.stopConnection();
        }

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
                    if ((dr["name"] + "").Contains(name) && dr.GetFloat(6) == 1)
                        quoteList.Add(new Quote(dr.GetInt32(9), dr["name"] + "", dr["custName"] + "", dr["email"] + "", dr.GetInt32(3), dr.GetFloat(4), dr.GetFloat(5), dr.GetFloat(6)));
                }
                dr.Close();
            }
            this.stopConnection();
        }

        public string convertQuote(float discount)
        {
            // send datagram to processing system

            UdpClient client = new UdpClient("blitz.cs.niu.edu", 4446);

            string send_msg = activeQuote.getId() + ":" + activeQuote.getCustName() + ":" + activeQuote.getTotalPrice();
            byte[] send_buffer = Encoding.ASCII.GetBytes(send_msg);

            client.Send(send_buffer, send_buffer.Length);

            // receive response from processing system

            string recv_msg;

            string hostname = "blitz.cs.niu.edu";

            IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
            IPAddress serverAddress = hostEntry.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(serverAddress, 4446);

            byte[] recv_buffer = client.Receive(ref endPoint);
            recv_msg = Encoding.ASCII.GetString(recv_buffer);

            return recv_msg;
        }

        public void submitQuote(string msg)
        {
            // create substrings from server response

            string[] substr = msg.Split(' ');
            string confirmationString = substr[8];
            string commissionString = substr[10];

            // create int for confirmation from confirmationString

            substr = confirmationString.Split(':');
            int confirmation;
            Int32.TryParse(substr[0], out confirmation);

            // create float for commission from commissionString

            substr = commissionString.Split('%');
            float commission;
            float.TryParse(substr[0], out commission);
            commission = (commission / 100) * activeQuote.getTotalPrice();

            MySqlCommand cmd;

            // connect to the database to update confirmation and commission for quote and salesperson

            if (this.connect())
            {
                string query = "UPDATE quote SET discount = discount + " + activeQuote.getDiscount() + ", total = " + activeQuote.getTotalPrice() + 
                    ", confirmation = " + confirmation + ", commission = " + commission + " WHERE id = " + activeQuote.getId() + ";";
                cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();

                query = "UPDATE salesperson SET commission = commission + " + commission + " WHERE sid = " + activeQuote.getSId() + ";";
                cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }

            this.stopConnection();
        }

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

        private void stopConnection()
		{
			connection.Close();
		}
    }
}
