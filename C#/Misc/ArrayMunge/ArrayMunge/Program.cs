using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayMunge
{
    class Program
    {
        static void Main(string[] args)
        {            
            //Call Process Model

            ProcessModel("TFEXT");
            ProcessModel("AnnualLMM");
            ProcessModel("SemiAnnualLMM");
            ProcessModel("MonthlyLMM");

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }

        private static void ProcessModel(string modelType)
        {
            switch (modelType)
            {
                case "TFEXT":
                    object[] TFEXTdata = processTwoFactorExt(pushArrayData(120));                    
                    break;
                case "AnnualLMM":
                    object[] AnnualLMMdata = processAnnualLMM(pushArrayData(121));
                    break;
                case "SemiAnnualLMM":
                    object[] SemiAnnualLMMdata = processNonAnnualLMM(pushArrayData(241), 2);
                    break;
                case "MonthlyLMM":
                    object[] MonthlyLMMdata = processNonAnnualLMM(pushArrayData(1441), 12);
                    break;
            }
        }

        private static object[] processTwoFactorExt(object[] data)
        {
            object[] zcbpData = new object[30];

            for (int i = 0; i < 30; i++)
                zcbpData[i] = data[i];

            return zcbpData;
        }

        private static object[] processAnnualLMM(object[] data)
        {
            object[] zcbpData = new object[30];

            for (int i = 1; i < zcbpData.Length; i++)
            {
                zcbpData[i-1] = ConvertFromForwardRateToZCBP(data[i]);
            }

            return zcbpData;
        }

        private static object[] processNonAnnualLMM(object[] data, int divisor)
        {
            object[] zcbpData = new object[30];

            var tempData = data.Where((x, i) => i % divisor == 0).Take(31).ToArray<object>();

            for(int i=1; i<tempData.Length; i++)
                zcbpData[i-1] = ConvertFromForwardRateToZCBP(tempData[i]);

            return zcbpData;
        }

        private static object[] pushArrayData(int length)
        {
            object[] data = new object[length];

            Random rand = new Random();

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rand.NextDouble();
            }

            return data;
        }

        private static object ConvertFromForwardRateToZCBP(object forwardRate)
        {           
            return forwardRate;
        }
    }
}
