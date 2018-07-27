namespace Logger
{
    public class Log
        {
            private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            public static void Message(string message)
            {
                logger.Info(message);
            }
        }
    }

