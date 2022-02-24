using System;
using System.Collections.Generic;
using System.IO;

namespace ThetaTempReader
{
    public class FileManager
    {
        public List<Data> ReadFile()
        {
           
            List<Data> dataList = new List<Data>();
            StreamReader reader= new StreamReader("Temperature.txt");

            //skip first 8 lines that have heading etc.
            for (var i = 0; i < 8; i++)
            {
                reader.ReadLine();
            }
            //Keep reading file to the end
            while (!reader.EndOfStream)
            {
                //since some of the fields have strings instead of integer
                try
                {
                    //read line of txt file, and create array of info about data
                    string[] values = reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    //Convert array into Data object
                    Data data = new Data();
                    data.Day = int.Parse(values[0]);
                    data.MaxTemperature = int.Parse(values[1].Replace("*", ""));
                    data.MinTemperature = int.Parse(values[2].Replace("*", ""));
                    
                    //add to list of all data
                    dataList.Add(data);
                }
         
                catch (Exception e)
                {
                    //throw (e);
                    //WriteLine(e.Message.ToString());
                    //do nothing
                }
            }
            //close stream reader
            reader.Close();
            return dataList;
        }
    }
}
