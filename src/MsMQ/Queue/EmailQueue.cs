using System;
using System.Messaging;

namespace MsMQ.Queue
{

    public class EmailQueue : QueueFactoryManager
    {
        protected override string PathQueue => @".\teste$\email";

        public void Add(User user)
        {
            using (MessageQueueTransaction = new MessageQueueTransaction())
            {
                try
                {
                    MessageQueueTransaction.Begin();
                    Add(user);
                    MessageQueueTransaction.Commit();
                }
                catch (Exception)
                {
                    MessageQueueTransaction.Abort();
                }
            }

        }

        public override void Process()
        {
            using (MessageQueueTransaction = new MessageQueueTransaction())
            {
                try
                {
                    MessageQueueTransaction.Begin();
                    var nextUser = RemoveNext<User>();
                    Console.WriteLine("Nome:{0}\nEmail:{1}", nextUser.Name, nextUser.Email);
                    MessageQueueTransaction.Commit();
                }
                catch (Exception)
                {
                    MessageQueueTransaction.Abort();
                }
            }
        }
    }

    
}