using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CALI.Database.Contracts.Data;
using CALI.Logic.Common;
using CALI.Logic.Common.Processors;
using CALI.Logic.Common.Util;
using CALI.Logic.Common.Interfaces;

namespace CALI.Client.ConsoleApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var provider = new ConsoleQueryProvider();
            QueryRouter.Instance.RegisterProvider(provider);

            provider.Run();
        }

        public class ConsoleQueryProvider : ICaliQueryProvider
        {
            public event ICaliQueryProviderDelegates.QueryReceivedDelegate QueryReceived;
            public event ICaliQueryProviderDelegates.SetDataContextDelegate SetDataContext;

            public void Run()
            {
                WriteAsCali("Hello, I am CALI.");
                var input = ReadFromUser();
                while (input != "quit")
                {
                    var isCommand = false;

                    if (input == "debug on")
                    {
                        isCommand = true;
                        QueryRouter.Instance.DebugMode = true;
                    }

                    if (input == "debug off")
                    {
                        isCommand = true;
                        QueryRouter.Instance.DebugMode = false;
                    }

                    if (input == "do test")
                    {
                        isCommand = true;
                        QueryRouter.Instance.RunAllExampleTests();
                    }

                    
                    if (!isCommand && QueryReceived != null)
                    {
                        var results = QueryReceived(this, input); 
                        WriteAsCali(results);
                    }

                    var lInput = input.ToLower();
                    if (lInput.StartsWith("this ") || lInput.StartsWith("that ") || lInput.StartsWith("these ") ||
                        lInput.StartsWith("here ") || lInput.StartsWith("there "))
                    {
                        //Pull data from clip board 
                        if (SetDataContext != null) //Note to self: Clipboard is fucking retarded.
                        {
                            if (Clipboard.ContainsText()) SetDataContext(this, "string.text", Encoding.ASCII.GetBytes(Clipboard.GetText()));
                            else if (Clipboard.ContainsImage())
                            {
                                byte[] imageData = new byte[0];
                                using (var ms = new MemoryStream())
                                {
                                    var image = Clipboard.GetImage();
                                    if(image != null) image.Save(ms, ImageFormat.Png);
                                    imageData = ms.ToArray();
                                }
                                SetDataContext(this, "image.png", imageData);
                            }
                            else if (Clipboard.ContainsData(DataFormats.Html))
                            {
                                var data = Clipboard.GetData(DataFormats.Html) as string;
                                if(data != null) SetDataContext(this, "string.html", Encoding.ASCII.GetBytes(data));
                            }
                        }
                    }

                    input = ReadFromUser();
                }
            }

            public string ReadFromUser()
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return Console.ReadLine();
            }

            public void WriteAsCali(string text)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("CALI");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(text);
                Console.WriteLine();
            }

            public void WriteAsCali(List<BinaryDataContract> results)
            {
                if (results.Count == 0)
                {
                    WriteAsCali("...*shrugs*");
                }
                else
                {
                    foreach (var result in results)
                    {
                        var dataStr = Encoding.ASCII.GetString(result.Data);
                        WriteAsCali(dataStr);
                    }
                }
            }


        }

        


        static void TestMonikerSynonym()
        {
            MonikerRetriever.AssociateMonikers("contacts","contact");
        }
       
        static void TestAssociateMonikersToData()
        {
            var contact = MonikerRetriever.GetMoniker("contact", true);
            var pcl = MonikerRetriever.GetMoniker("Pcl", true);
            var dataBytes = System.Text.Encoding.ASCII.GetBytes("Bob @ 780.271.2171");

            var data = BinaryDataRetriever.StoreData("sting.contactInfo", dataBytes);
            MonikerRetriever.AssociateMonikers(data,contact,pcl);

            var asebp = MonikerRetriever.GetMoniker("AseBP", true);
            dataBytes = System.Text.Encoding.ASCII.GetBytes("Karen @ 780.271.2171");
            data = BinaryDataRetriever.StoreData("sting.contactInfo", dataBytes);
            MonikerRetriever.AssociateMonikers(data, contact, asebp);

            //Now get data using monikers
            var results = BinaryDataRetriever.GetData(contact, pcl);
            //PrintResults("Contacts for pcl", results);

            results = BinaryDataRetriever.GetData(contact);
            //PrintResults("Contacts", results);
        }

        
    }
}
