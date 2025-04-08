namespace DHSC.ANS.API.Legacy.Configuration
{
    public class AppSettings
    {
        public StorageQueueConfig StorageQueue { get; set; }

        public class StorageQueueConfig
        {
            public string ConnectionString { get; set; }
            public string QueueName { get; set; }
        }
    }
}
