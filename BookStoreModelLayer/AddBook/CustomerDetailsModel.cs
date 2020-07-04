using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreModelLayer.AccountModel
{
    public class CustomerDetailsModel
    {
        private int id;
        private string name;
        private string phonenumber;
        private string pincode;
        private string locality;
        private string address;
        private string city;
        private string landmark;
        private string type;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Pincode { get => pincode; set => pincode = value; }
        public string Locality { get => locality; set => locality = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Landmark { get => landmark; set => landmark = value; }
        public string Type { get => type; set => type = value; }
    }
}
