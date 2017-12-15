namespace DeliverIT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Client => Receiver/Sender => Individual/Legal entity;
    /// Client Fields: Adress, ZIP Code, Country, City, Phone, Email, All Orders List, 
    /// 
    /// </summary>
    
    public class Client : Person
    {
        private List<Order> ordersList;
        private static int id;


        void DisplayOrderList()
        {
            //method for displaying order list
        }
    }
}
