namespace DeliverIT
{
    using System;
    using System.Collections.Generic;

    public class Courier : Person
    {
        private List<Order> deliveries;
        private static int id;
    }
}
