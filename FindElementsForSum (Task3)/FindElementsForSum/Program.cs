namespace FindElementsForSum
{
    public class Program
    {
        public void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
        {
            // Initialize the start index and currentSum variable
            start = 0;
            ulong currSum = 0;

            // Iterate till the end of the array
            for (end = 0; end < list.Count; end++)
            {
                // Add the sum of elements at each iteration
                currSum += list[end];

                // In case we iterate from some elements and
                // the current sum is greater than searched sum
                // (iterate through sub-list from 'start' to 'end')
                while (currSum > sum && start <= end)
                {
                    // We should subtract the elements until the
                    // current sum is smaller than the searched sum
                    currSum -= list[start];
                    // We should narrow the searched sub-list until end,
                    // then search in the next sub-list
                    start++;
                }

                // When we found the sub-list should return the indexes
                if (currSum == sum)
                {
                    // Increment the end index (exclusive)
                    end++;
                    return;
                }
            }

            // In case we didn't found the given sum should reset the indexes
            start = 0;
            end = 0;
        }
    }
}
