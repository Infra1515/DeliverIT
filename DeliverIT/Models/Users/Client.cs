namespace DeliverIT
{
    using DeliverIT.Common;
    using DeliverIT.Common.Enums;
    using DeliverIT.Contracts;
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
    
    public class Client : User
    {
        private ClientType clientType; 
        private static int id;

        public IList<IOrder> OrdersList { get; set; }
        public ClientType ClientType { get => clientType; set => clientType = value; }

        public Client(string firstName, string lastName, string email, string phoneNumber,
                        int years, Country country, GenderType gender) 
            : base(firstName, lastName, email, phoneNumber, years, country, gender)
        {
            this.OrdersList = new List<IOrder>();
        }

        void DisplayOrderList()
        {
            //method for displaying or
        }

        void ShowAllOrders(IList<IOrder> allOrders)
        {
            throw new NotImplementedException();
        }

        void ShowReceivedOrders(IList<IOrder> allReceivedOrders)
        {
            throw new NotImplementedException();
        }

        void ShowSentOrders(IList<IOrder> allSentOrders)
        {
            throw new NotImplementedException();
        }
    }
}
