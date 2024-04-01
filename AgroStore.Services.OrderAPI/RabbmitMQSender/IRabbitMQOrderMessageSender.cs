using System;

namespace AgroStore.Services.OrderAPI.RabbmitMQSender
{
    public interface IRabbitMQOrderMessageSender
    {
        void SendMessage(Object message, string exchangeName);
    }
}
