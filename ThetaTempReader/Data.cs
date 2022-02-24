using System;

namespace ThetaTempReader
{
    public class Data : IComparable<Data>
    {
      
        public int Day { get; set; }
        public int MaxTemperature { get; set; }
        public int MinTemperature { get; set; }


        public int VariationTemp()
        {
            int variationTemp = MaxTemperature - MinTemperature;
            return variationTemp;
        }

        public int CompareTo(Data other)
        {
            //if variation is same will sort base on day that comes first
            if(this.VariationTemp() == other.VariationTemp())
            {
                return this.Day.CompareTo(other.Day);
           }
            //else sort in ascending order
            return this.VariationTemp().CompareTo(other.VariationTemp());
        }
    }
}
