﻿namespace AgroStore.Services.AuthAPI.RabbmitMQSender
{
    public interface IRabbmitMQAuthMessageSender
    {
        void SendMessage(Object message, string queueName);
    }
}