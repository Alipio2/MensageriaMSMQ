using System.Messaging;

namespace MsMQ.Queue
{
    public abstract class QueueFactoryManager
    {
        protected abstract string PathQueue { get; }

        protected MessageQueueTransaction MessageQueueTransaction { get; set; }

        private MessageQueue MsmQBase()
        {
            var msmq = new MessageQueue(PathQueue);

            if (MessageQueue.Exists(PathQueue))
            {
                msmq.Formatter = new BinaryMessageFormatter();
                return msmq;
            }

            msmq = MessageQueue.Create(PathQueue, true);
            return msmq;
        }

        protected void AddNext(object objeto)
        {
            MsmQBase().Send(objeto, MessageQueueTransaction);
        }

        protected T RemoveNext<T>()
        {
            var proximoElemento = MsmQBase().Receive(MessageQueueTransaction)?.Body;

            return (T)proximoElemento;

        }

        public abstract void Process();
    }
}