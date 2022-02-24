using System.Collections.Generic;
using static System.Console;

namespace ThetaTempReader
{
    public class Program
    {
        List<Data> dataList = new List<Data>();
        public Program()
        {
           storeFileContents();

        }

        public void storeFileContents()
        {
          
            FileManager fm = new FileManager();
            dataList = fm.ReadFile();

            //sort list using the comparator in Data
            dataList.Sort();
           
            //day with minimum temperature variation is at first index since list was sorted in ascending order
            var minimumTemp =  dataList[0].Day;

            //But check if other days have the same variation
            List<Data> minimumVariationTemperature = new List<Data>();
            for(int i = 0; i< dataList.Count; i++)
            {
                if(dataList[0].VariationTemp() == dataList[i].VariationTemp())
                {
                    minimumVariationTemperature.Add(dataList[i]);
                } 
                else
                {
                    break;
                }
            }

            //output in console Days with Minimum variation
            WriteLine("Day (s) with Minimum Temperature Variation");
            foreach (Data minimum in minimumVariationTemperature){
                WriteLine("Day: " + minimum.Day + " Variation in Temp:  " + minimum.VariationTemp());

            }
        }

        static void Main(string[] args)
        {
             new Program();
         
        }
    }
}
