using System;
using System.Collections.Generic;
using CALI.Database.Contracts.Data;
using CALI.Logic.Common;
using CALI.Logic.Common.Processors;
using CALI.Logic.Common.Util;

namespace CALI.Client.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAssociateMonikersToData();
            TestMonikerSynonym();
            TestWhoWhatAreTheFor();



            Console.ReadLine();
        }
        static void DoQuery(string query)
        {
            var qr = new QueryRouter();
            qr.RegisterProcessor(new WhoWhatAreIsTheFor());
            qr.RegisterProcessor(new IsTheFor());
            var results = qr.Query(query);
            PrintResults(query, results);
        }

        static void TestMonikerSynonym()
        {
            MonikerRetriever.AssociateMonikers("contacts","contact");
        }
        static void TestWhoWhatAreTheFor()
        {
            DoQuery("Bob is the IT admin for PCL.");
            DoQuery("Who are the contacts for pcl?");
            DoQuery("What are the contacts for pcl?");
            DoQuery("Who is the IT Admin for pcl?");
            
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
            PrintResults("Contacts for pcl", results);

            results = BinaryDataRetriever.GetData(contact);
            PrintResults("Contacts", results);
        }

        static void PrintResults(string header, List<BinaryDataContract> results)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(header);
            foreach (var result in results)
            {
                var dataStr = System.Text.Encoding.ASCII.GetString(result.Data);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("\t {0} :", result.DataType);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(dataStr);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
