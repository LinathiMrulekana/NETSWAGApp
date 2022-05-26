using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NETSWAGApp.models
{
    public class OrderingItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public bool TShirtSize { get; set; }
        public string Dateoforder { get; set; }
        public string Tshirtcolor { get; set; }
        public string Shippingaddress { get; set; }

        

    }
}
