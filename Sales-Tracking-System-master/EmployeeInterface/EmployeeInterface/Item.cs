using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInterface
{
    class Item
    {
        private string description;
        private float price;
		private int id = 0;
		private int quoteId = 0;

		public Item(int idd, int qid, string desc, float prc)
		{
			id = idd;
			quoteId = qid;
			description = desc;
			price = prc;
		}

		public Item(string desc, float prc)
		{
			description = desc;
			price = prc;
		}

		public Item()
		{

		}

		public int getId()
		{
			return id;
		}

		public int getQID()
		{
			return quoteId;
		}

        public string getDescription()
        {
            return description;
        }

        public void setDescription(string desc)
        {
            description = desc;
        }

        public float getPrice()
        {
            return price;
        }

        public void setPrice(float pr)
        {
            price = pr;
        }
    }
}
