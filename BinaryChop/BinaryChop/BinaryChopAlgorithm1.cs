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
            int chopedTotalLeft = 0;
            int chopedTotalRight = 0;
            int total = valuesToChop.Count();
            while (valuesToChop.Count() > 1)
            {
                int chopedInThisRunLeft;
                int chopedInThisRunRight;
                valuesToChop = NewValuesToChop(valueToSearch, valuesToChop, out chopedInThisRunLeft, out chopedInThisRunRight);
                chopedTotalLeft += chopedInThisRunLeft;
                chopedTotalRight += chopedInThisRunRight;
            }

            return (total -1 + chopedTotalLeft);
        }

        private int[] NewValuesToChop(int valueToSearch, int[] valuesToChop, out int chopedRight, out int chopedLeft)
        {
            int remainingItems = valuesToChop.Count();
            int middlePositionValue = GetMiddleValue(valuesToChop);
            int[] newValuesToChop = new int[0];

            if (ValueGreaterThen(middlePositionValue, valueToSearch, valuesToChop))
            {
                chopedRight = -(middlePositionValue-1);
                newValuesToChop = new int[middlePositionValue];
                int o = 0;
                for (int i = 0; i < middlePositionValue; i++)
                {
                    newValuesToChop[o] = valuesToChop[i];
                    o++;
                }
            }
            else
            {
                chopedLeft = (middlePositionValue - 1);
                newValuesToChop = new int[remainingItems - middlePositionValue];
                int o = 0;
                for (int i = middlePositionValue; i < remainingItems; i++)
                {
                    newValuesToChop[o] = valuesToChop[i];
                    o++;
                }
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
