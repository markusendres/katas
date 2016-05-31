using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryChop
{
    public class BinaryChopAlgorithm1
    {
        public int Chop(int valueToSearch, int[] valuesToChop)
        {
            int chopedTotalRight = 0;
            int total = valuesToChop.Count();
            while (valuesToChop.Count() > 1)
            {
                int chopedInThisRunRight;
                valuesToChop = NewValuesToChop(valueToSearch, valuesToChop, out chopedInThisRunRight);
                chopedTotalRight += chopedInThisRunRight;
            }

            return (total - chopedTotalRight);
        }

        private int[] NewValuesToChop(int valueToSearch, int[] valuesToChop, out int chopedRight)
        {
            int remainingItems = valuesToChop.Count();
            int middlePositionValue = GetMiddleValue(valuesToChop);
            int[] newValuesToChop;

            chopedRight = 0;
            if (ValueGreaterThen(middlePositionValue, valueToSearch, valuesToChop))
            {
                chopedRight = middlePositionValue;
                if (remainingItems%2 != 0)
                {
                    chopedRight--;
                }
                newValuesToChop = RemoveItemsFromTheRightSide(valuesToChop, middlePositionValue);
            }
            else
            {
                newValuesToChop = RemoveItemsFromTheLeftSide(valuesToChop, remainingItems, middlePositionValue);
            }
            return newValuesToChop;
        }

        private static int[] RemoveItemsFromTheLeftSide(int[] valuesToChop, int remainingItems, int middlePositionValue)
        {
            var newValuesToChop = new int[remainingItems - middlePositionValue];
            int o = 0;
            for (int i = middlePositionValue; i < remainingItems; i++)
            {
                newValuesToChop[o] = valuesToChop[i];
                o++;
            }
            return newValuesToChop;
        }

        private static int[] RemoveItemsFromTheRightSide(int[] valuesToChop, int middlePositionValue)
        {
            var newValuesToChop = new int[middlePositionValue];
            int o = 0;
            for (int i = 0; i < middlePositionValue; i++)
            {
                newValuesToChop[o] = valuesToChop[i];
                o++;
            }
            return newValuesToChop;
        }

        private bool ValueGreaterThen(int valueToCheck, int valueToSearch, int[] valuesToChop)
        {
            return valuesToChop[valueToCheck] > valueToSearch;
        }

        private static int GetMiddleValue(int[] valuesToChop)
        {
            int countOfValues = valuesToChop.Count();
            int middleValue;
            if (countOfValues%2 == 0)
            {
                middleValue = countOfValues/2;
            }
            else
            {
                middleValue = (countOfValues + 1)/2;
            }
            return middleValue;
        }
    }
}
