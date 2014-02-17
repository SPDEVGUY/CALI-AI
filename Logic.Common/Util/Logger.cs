using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using CALI.Database.Contracts.Data;
using CALI.Database.Logic.Data;

namespace CALI.Logic.Common.Util
{
    public class LogBlock : IDisposable
    {
        public string SectionTitle;
        public object[] Formats;

        public LogBlock()
        {
            Logger.Log.LogBlockLevel++;
        }
        public LogBlock(string sectionTitle, params object[] formats)
        {
            SectionTitle = sectionTitle;
            Formats = formats;
            Logger.Log.Section(sectionTitle, formats);
            Logger.Log.LogBlockLevel++;
        }

        public void Dispose()
        {
            Logger.Log.LogBlockLevel--;
            Logger.Log.EndSection(SectionTitle, Formats);
        }
    }

    public class Logger : IDisposable
    {
        public const string LogDirectory = "Logs";
        public string LogFileName
        {
            get
            {
                if (_logFileName != null) return _logFileName;
                _logFileName =
                    string.Format(
                        "{0}\\{1}.{2}.txt",
                        LogDirectory,
                        Environment.MachineName,
                        DateTime.UtcNow.Ticks);

                return _logFileName;
            }
        }
        private static string _logFileName;


        public static Logger Log = new Logger();
        public bool ErrorsOccurred;
        protected StreamWriter LogFileStream;

        public int LogBlockLevel = 0;
        public Queue<string> LastInfoLines = new Queue<string>();

        public void StartLog()
        {
            if (Console.LargestWindowWidth > 0)
            {
                Console.SetWindowSize((int)(Console.LargestWindowWidth * 0.9), 40);
            }

            Info("Creating {0}...", LogFileName);
            if (!Directory.Exists(LogDirectory)) Directory.CreateDirectory(LogDirectory);
            File.WriteAllText(LogFileName, string.Format("Log started {0}.", DateTime.Now));
            Info("CMD Line Args: {0}.", string.Join(" ", Environment.GetCommandLineArgs()));
            LogFileStream = File.AppendText(LogFileName);

        }
        public void EndLog()
        {
            Info("Log ended {0}.", DateTime.Now);
            Console.ResetColor();
            LogFileStream.Close();
            LogFileStream = null;

            if (File.Exists(LogFileName))
            {
                var machineName = Environment.MachineName;
                var logContents = File.ReadAllText(LogFileName);

                Info("Recording log to database...");
                LogLogic.InsertNow(new LogContract
                {
                    LogContents = logContents,
                    RunOnMachineName = machineName,
                    RunTime = DateTime.Now
                });
                Info("Recorded log to database.");
            }

        }

        public bool Check(bool ifThisIsTrue, string reportThis, params object[] formats)
        {
            if (!ifThisIsTrue) Info(reportThis, formats);
            return ifThisIsTrue;
        }
        public bool Require(bool ifThisIsTrue, string reportThis, params object[] formats)
        {
            if (!ifThisIsTrue) Error(reportThis, formats);
            return ifThisIsTrue;
        }

        public void Section(string reportThis, params object[] formats)
        {
            Console.ForegroundColor = ConsoleColor.White;
            WriteInfoLine();
            WriteInfoLine("".PadLeft(LogBlockLevel, '\t') + "-- START [ " + reportThis, formats);
        }
        public void EndSection(string reportThis, params object[] formats)
        {
            Console.ForegroundColor = ConsoleColor.White;
            WriteInfoLine("".PadLeft(LogBlockLevel, '\t') + "-- END [ " + reportThis, formats);
            WriteInfoLine();
        }
        public void Info(string reportThis, params object[] formats)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            WriteInfoLine("".PadLeft(LogBlockLevel, '\t') + reportThis, formats);
        }
        public string DumpLastLinesToFile()
        {
            if (LogFileStream == null || LastInfoLines.Count == 0) return "";
            var result = new StringBuilder();

            result.AppendLine();
            LogFileStream.WriteLine();
            result.AppendLine("------------ Previous Info---->>");
            LogFileStream.WriteLine("------------ Previous Info---->>");
            while (LastInfoLines.Count > 0)
            {
                var line = LastInfoLines.Dequeue();

                result.AppendLine(line);
                LogFileStream.WriteLine(line);
            }

            result.AppendLine("------------ End Previous Info---->>");
            LogFileStream.WriteLine("------------ End Previous Info---->>");

            return result.ToString();
        }
        public void Warning(string reportThis, params object[] formats)
        {
            var previousLines = DumpLastLinesToFile();
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteLine("".PadLeft(LogBlockLevel, '\t') + "Warning");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("".PadLeft(LogBlockLevel, '\t') + reportThis, formats);


            var result = new StringBuilder();
            result.AppendLine(previousLines);
            result.AppendFormat("".PadLeft(LogBlockLevel, '\t') + reportThis, formats);
            result.AppendLine();
            PreviousWarnings.Enqueue(result.ToString());
        }
        public void Error(string reportThis, params object[] formats)
        {
            var previousLines = DumpLastLinesToFile();
            Console.ForegroundColor = ConsoleColor.Red;
            WriteLine("".PadLeft(LogBlockLevel, '\t') + "Error");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("".PadLeft(LogBlockLevel, '\t') + reportThis, formats);
            ErrorsOccurred = true;

            var result = new StringBuilder();
            result.AppendLine(previousLines);
            result.AppendFormat("".PadLeft(LogBlockLevel, '\t') + reportThis, formats);
            result.AppendLine();
            PreviousErrors.Enqueue(result.ToString());

        }
        public void Exception(Exception ex, string reportThis, params object[] formats)
        {
            var previousLines = DumpLastLinesToFile();

            Error("[EXCEPTION] " + reportThis, formats);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            WriteLine("{0} : {1}", ex.GetType(), ex.Message);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine("---------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            WriteLine(ex.ToString().Replace("{", "{{").Replace("}", "}}"));
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine("---------------------------------------------------");


            var result = new StringBuilder();
            result.AppendLine(previousLines);
            result.AppendFormat("[EXCEPTION] " + reportThis, formats);
            result.AppendLine();
            result.AppendLine("---------------------------------------------------");
            result.AppendFormat("{0} : {1}", ex.GetType(), ex.Message);
            result.AppendLine();
            result.AppendLine("---------------------------------------------------");
            result.AppendFormat(ex.ToString().Replace("{", "{{").Replace("}", "}}"));
            result.AppendLine();
            result.AppendLine("---------------------------------------------------");
            PreviousExceptions.Enqueue(result.ToString());

            ErrorsOccurred = true;
        }
        public void WriteInfoLine()
        {
            Console.WriteLine();
            LastInfoLines.Enqueue("");
            if (LastInfoLines.Count > 10) LastInfoLines.Dequeue();
        }
        public void WriteInfoLine(string outString, params object[] formats)
        {
            Console.WriteLine(outString, formats);
            LastInfoLines.Enqueue(string.Format(outString, formats));
            if (LastInfoLines.Count > 10) LastInfoLines.Dequeue();
        }
        public void WriteLine(string outString, params object[] formats)
        {
            Console.WriteLine(outString, formats);
            if (LogFileStream != null) LogFileStream.WriteLine(outString, formats);
        }
        public void WriteLine()
        {
            Console.WriteLine();
            if (LogFileStream != null) LogFileStream.WriteLine();
        }

        public void Dispose()
        {
            if (LogFileStream != null)
            {
                LogFileStream.Close();
                LogFileStream = null;
            }
        }

        public bool HavePreviousErrors { get { return PreviousErrors.Count > 0 || PreviousExceptions.Count > 0; } }
        public Queue<string> PreviousWarnings = new Queue<string>();
        public Queue<string> PreviousErrors = new Queue<string>();
        public Queue<string> PreviousExceptions = new Queue<string>();

        public string CollectPreviousWarnings()
        {
            if (PreviousWarnings.Count == 0) return null;
            var result = string.Join(Environment.NewLine, PreviousWarnings.ToArray());
            PreviousWarnings.Clear();
            return result;
        }

        public string CollectPreviousErrors()
        {
            if (PreviousErrors.Count == 0) return null;
            var result = string.Join(Environment.NewLine, PreviousErrors.ToArray());
            PreviousErrors.Clear();
            return result;
        }

        public string CollectPreviousExceptions()
        {
            if (PreviousExceptions.Count == 0) return null;
            var result = string.Join(Environment.NewLine, PreviousExceptions.ToArray());
            PreviousExceptions.Clear();
            return result;
        }
    }
}
