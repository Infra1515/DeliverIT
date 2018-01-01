using DeliverIT.Common.Enums;
using System;

namespace DeliverIT.Core.Engine.Event
{
    public class OrderStateChangedEventArgs : EventArgs
    {
        public readonly OrderState LAST_STATE;
        public readonly OrderState CURRENT_STATE;
        public readonly int ID;

        public OrderStateChangedEventArgs(OrderState lastState, OrderState currentState, int id)
        {
            this.LAST_STATE = lastState;
            this.CURRENT_STATE = currentState;
            this.ID = id;
        }
    }
}
