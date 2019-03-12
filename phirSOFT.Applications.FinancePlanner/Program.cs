using System;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Reflection;
using NLog;
using NLog.Targets;
using Ookii.CommandLine;
using phirSOFT.Applications.FinancePlanner.Model;
using Logger = NLog.Logger;

namespace phirSOFT.Applications.FinancePlanner
{
    /// <summary>
    /// Contains the start up code and the main entry point.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The instace of the current logger.
        /// </summary>
        private static Logger logger;

        /// <summary>
        /// The options used to start this program.
        /// </summary>
        private static StartupOptions Options;

       

        static Program()
        {
            var target = new FileTarget("FileLog") {FileName = Application.UserAppDataPath + "\\log.txt"};
            LogManager.Configuration.AddTarget(target);
            LogManager.Configuration.AddRule(LogLevel.Info, LogLevel.Fatal, "FileLog");
            logger = LogManager.GetLogger("Main Thread");
        }

        public static FinanceContext CurrentContext { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static int Main(string[] args)
        {
            logger.Info("Starting Application");
            try
            {
                logger.Trace("Creating cmd Parser");
                var parser = new CommandLineParser(typeof(StartupOptions));

                logger.Trace("Parsing Options");
                Options = (StartupOptions) parser.Parse(args);


                if (Options.Debug)
                {
                    logger.Trace("Enabling Debg Information");
                    foreach (var rule in LogManager.Configuration.LoggingRules)
                        rule.EnableLoggingForLevel(LogLevel.Debug);
                    LogManager.ReconfigExistingLoggers();
                }




                //Print startup Options
                Debug(Options.DebugOptions());

                ConnectToDb();
                //CreateDb("Data.mdf");

                Debug("Enabling visual styles");
                Application.EnableVisualStyles();

                Debug("Deactivating compatible text renderng.");
                Application.SetCompatibleTextRenderingDefault(false);

                Debug("Starting main form");
                Application.Run(Form1.Instance);


            }
            catch (Exception ex)
            {
                logger.Error(ex);
                logger.Info(Path.ChangeExtension(new Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath, ".ribbon.dll"));
                return -1;
            }

            finally
            {
                logger.Info("Storing Database");
                CurrentContext.SaveChanges();

                logger.Info("Closing Database connection");
                CurrentContext.Dispose();
            }
               


            return 0;
        }

        public static void ConnectToDb()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FinanceContext, Configuration>());

            logger.Info("Connecting to Database");
            CurrentContext = new FinanceContext();


            if (!CurrentContext.Database.CompatibleWithModel(false))
            {
                logger.Fatal("Database Update is required. Model is not compatible");
            }
        }

       /* public static void CreateDb(string path)
        {
            var connectionString = "Data Source=(LocalDB)\\v11.0";

            var masterCsb = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = "master",
                AttachDBFilename = path
            };


            using (var sqlConn = new SqlConnection(masterCsb.ToString()))
            {
                sqlConn.Open();
                using (var cmd = sqlConn.CreateCommand())
                {
                    var done = false;
                    var attempt = 0;
                    do
                    {
                        try
                        {
                            cmd.CommandText =
                                string.Format(
                                    "IF EXISTS (Select name from sys.databases " +
                                    "WHERE name = '{0}') " +
                                    "DROP DATABASE {0}", "EventsListDB");
                            cmd.ExecuteNonQuery();
                            done = true;
                        }
                        catch (System.Exception ex)
                        {
                            //We sometimes get odd exceptions that're probably because LocalDB hasn't finished starting. 
                            if (attempt++ > 5)
                            {
                                throw ex;
                            }
                            Thread.Sleep(100);
                        }
                    } while (!done);
                }
            }
            CurrentContext = new FinanceContext(connectionString);

            CurrentContext.Database.CreateIfNotExists();
            CurrentContext.Database.Initialize(true);

        }*/

        /// <summary>
        /// Writes a debug message to the log.
        /// </summary>
        /// <param name="message">The message to write to the log.</param>
        private static void Debug(string message)
        {
            logger.Debug(CultureInfo.CurrentCulture, message);
        }
    }
}
