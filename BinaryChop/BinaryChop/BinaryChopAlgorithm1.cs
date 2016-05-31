using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryChop
{
    public class BinaryChopAlgorithm1
    {
        public int FindPositionOfValueInSortedNumberArray(int valueToSearch, int[] sortedNumberArray)
        {
            int chopedItemsFromTheRightTotal = 0;
            int total = sortedNumberArray.Count();
            while (sortedNumberArray.Count() > 1)
            {
                int chopedItemsFromTheRightSideInThisRun;
                sortedNumberArray = NewValuesToChop(valueToSearch, sortedNumberArray, out chopedItemsFromTheRightSideInThisRun);
                chopedItemsFromTheRightTotal += chopedItemsFromTheRightSideInThisRun;
            }

            return (total - chopedItemsFromTheRightTotal);
        }

        private int[] NewValuesToChop(int valueToSearch, int[] sortedNumberArray, out int chopedRight)
        {
            int numberOfRemainingItems = sortedNumberArray.Count();
            int middlePositionValue = GetMiddleValue(sortedNumberArray);
            int[] remainingValues;

            chopedRight = 0;
            if (ValueGreaterThen(middlePositionValue, valueToSearch, sortedNumberArray))
            {
                chopedRight = middlePositionValue;
                if (numberOfRemainingItems % 2 != 0)
                {
                    chopedRight--;
                }
                remainingValues = RemoveItemsFromTheRightSide(sortedNumberArray, middlePositionValue);
            }
            else
            {
                remainingValues = RemoveItemsFromTheLeftSide(sortedNumberArray, numberOfRemainingItems, middlePositionValue);
            }
            return remainingValues;
        }

        private static int[] RemoveItemsFromTheLeftSide(int[] valuesToChop, int numberOfRemainingItems, int middlePositionValue)
        {
            var newValuesToChop = new int[numberOfRemainingItems - middlePositionValue];
            int o = 0;
            for (int i = middlePositionValue; i < numberOfRemainingItems; i++)
            {
                newValuesToChop[o] = valuesToChop[i];
                o++;
            }
            return newValuesToChop;
        }

        private static int[] RemoveItemsFromTheRightSide(int[] sortedNumberArray, int middlePositionValue)
        {
            var newValuesToChop = new int[middlePositionValue];
            int o = 0;
            for (int i = 0; i < middlePositionValue; i++)
            {
                newValuesToChop[o] = sortedNumberArray[i];
                o++;
            }
            return newValuesToChop;
        }

        private bool ValueGreaterThen(int valueToCheck, int valueToSearch, int[] sortedNumberArray)
        {
            return sortedNumberArray[valueToCheck] > valueToSearch;
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
