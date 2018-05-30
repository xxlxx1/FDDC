﻿using System;
using System.IO;
using System.Text;

namespace 金融数据整理大赛
{
    class Program
    {

        public static StreamWriter Logger = new StreamWriter("Log.log");

        public static String DocBase = @"E:\金融数据整理大赛";

        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Traning.InitContract();
            Traning.InitIncreaseStock();
            Traning.InitStockChange();

            //分词系统
            //WordAnlayze.Init();
            //UT.RunWordAnlayze();
            //UT.StockChangeTest();
            //UT.IncreaseStockTest();
            UT.ContractTest();
            UT.RegularExpress();
            Logger.Close();
            return;

            var IsRunContract = true;
            var IsRunContract_TEST = true;

            var IsRunStockChange = true;
            var IsRunStockChange_TEST = true;

            var IsRunIncreaseStock = true;
            var IsRunIncreaseStock_TEST = true;

            if (IsRunContract)
            {
                //合同处理
                var ContractPath_TRAIN = DocBase + @"\FDDC_announcements_round1_train_20180518\round1_train_20180518\重大合同";
                Console.WriteLine("Start To Extract Info Contract TRAIN");
                StreamWriter ResultCSV = new StreamWriter("Result\\hetong_train.csv", false, Encoding.GetEncoding("gb2312"));
                foreach (var filename in System.IO.Directory.GetFiles(ContractPath_TRAIN + @"\html\"))
                {
                    foreach (var item in Contract.Extract(filename))
                    {
                        ResultCSV.WriteLine(Contract.ConvertToString(item));
                    }
                }
                ResultCSV.Close();
                Console.WriteLine("标准主键数：" + Traning.ContractList.Count);
                Console.WriteLine("Complete Extract Info Contract");
            }
            if (IsRunContract_TEST)
            {
                var ContractPath_TEST = DocBase + @"\FDDC_announcements_round1_test_a_20180524\重大合同";
                StreamWriter ResultCSV = new StreamWriter("Result\\hetong.csv", false, Encoding.GetEncoding("gb2312"));
                Console.WriteLine("Start To Extract Info Contract TEST");
                foreach (var filename in System.IO.Directory.GetFiles(ContractPath_TEST + @"\html\"))
                {
                    foreach (var item in Contract.Extract(filename))
                    {
                        ResultCSV.WriteLine(Contract.ConvertToString(item));
                    }
                }
                ResultCSV.Close();
                Console.WriteLine("Complete Extract Info Contract");
            }


            if (IsRunStockChange)
            {
                //增减持
                Console.WriteLine("Start To Extract Info StockChange TRAIN");
                StreamWriter ResultCSV = new StreamWriter("Result\\zengjianchi_Train.csv", false, Encoding.GetEncoding("gb2312"));
                var StockChangePath_TRAIN = DocBase + @"\FDDC_announcements_round1_train_20180518\round1_train_20180518\增减持";
                foreach (var filename in System.IO.Directory.GetFiles(StockChangePath_TRAIN + @"\html\"))
                {
                    foreach (var item in StockChange.Extract(filename))
                    {
                        ResultCSV.WriteLine(StockChange.ConvertToString(item));
                    }

                }
                ResultCSV.Close();
                Console.WriteLine("Complete Extract Info StockChange");
            }
            if (IsRunStockChange_TEST)
            {
                StreamWriter ResultCSV = new StreamWriter("Result\\zengjianchi.csv", false, Encoding.GetEncoding("gb2312"));
                var StockChangePath_TEST = DocBase + @"\FDDC_announcements_round1_test_a_20180524\增减持";
                Console.WriteLine("Start To Extract Info StockChange TEST");
                foreach (var filename in System.IO.Directory.GetFiles(StockChangePath_TEST + @"\html\"))
                {
                    foreach (var item in StockChange.Extract(filename))
                    {
                        ResultCSV.WriteLine(StockChange.ConvertToString(item));
                    }
                }
                ResultCSV.Close();
                Console.WriteLine("Complete Extract Info StockChange");
            }



            if (IsRunIncreaseStock)
            {
                //定增
                StreamWriter ResultCSV = new StreamWriter("Result\\dingzeng_train.csv", false, Encoding.GetEncoding("gb2312"));
                var IncreaseStockPath_TRAIN = DocBase + @"\FDDC_announcements_round1_train_20180518\round1_train_20180518\定增";
                Console.WriteLine("Start To Extract Info IncreaseStock TRAIN");

                foreach (var filename in System.IO.Directory.GetFiles(IncreaseStockPath_TRAIN + @"\html\"))
                {
                    foreach (var item in IncreaseStock.Extract(filename))
                    {
                        ResultCSV.WriteLine(IncreaseStock.ConvertToString(item));
                    }
                }
                ResultCSV.Close();
                Console.WriteLine("Complete Extract Info IncreaseStock");
            }

            if (IsRunIncreaseStock_TEST)
            {
                StreamWriter ResultCSV = new StreamWriter("Result\\dingzeng.csv", false, Encoding.GetEncoding("gb2312"));
                var IncreaseStockPath_TEST = DocBase + @"\FDDC_announcements_round1_test_a_20180524\定增";
                Console.WriteLine("Start To Extract Info IncreaseStock TRAIN");
                foreach (var filename in System.IO.Directory.GetFiles(IncreaseStockPath_TEST + @"\html\"))
                {
                    foreach (var item in IncreaseStock.Extract(filename))
                    {
                        ResultCSV.WriteLine(IncreaseStock.ConvertToString(item));
                    }
                }
                ResultCSV.Close();
                Console.WriteLine("Complete Extract Info IncreaseStock");
            }


            Logger.Close();
        }
    }
}
