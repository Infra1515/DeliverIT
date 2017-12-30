using DeliverIT.Common.Enums;
using System;

namespace DeliverIT.Core.Engine
{
    public class OrderStateChangedEventArgs : EventArgs
    {
        public readonly OrderState LAST_STATE;
        public readonly OrderState CURRENT_STATE;

        public OrderStateChangedEventArgs(OrderState lastState, OrderState currentState)
        {
            this.LAST_STATE = lastState;
            this.CURRENT_STATE = currentState;
        }
    }
}
