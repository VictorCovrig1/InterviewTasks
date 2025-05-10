using FindElementsForSum;

namespace FindElementsForSumTests
{
    public class FindElementsForSumTests
    {
        public static IEnumerable<object[]> Elements()
        {
            // Check if sub-list sum is equal to input sum (consecutive list)
            yield return new object[] { new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 11, 5, 7 };
            // Check if all list sum is equal to input sum (consecutive list)
            yield return new object[] { new List<uint> { 4, 5, 6, 7 }, 22, 0, 4 };
            // Check if input sum is not in array
            yield return new object[] { new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7 }, 88, 0, 0 };
            // Check if sub-list sum is equal to input sum (non-consecutive list)
            yield return new object[] { new List<uint> { 1, 100, 2, 99, 10, 1, 4, 31 }, 46, 4, 8 };
            // Check input sum is found in an array of only one element
            yield return new object[] { new List<uint> { 10 }, 10, 0, 1 };
            // Check the sum for empty list
            yield return new object[] { new List<uint> { }, 0, 0, 0 };
        }

        [Theory]
        [MemberData(nameof(Elements))]
        public void ShouldGetCorrectElementsThatMatchesSum(List<uint> list, uint sum, int inputStart, int inputEnd)
        {
            Program program = new Program();
            program.FindElementsForSum(list, sum, out int outputStart, out int outputEnd);

            Assert.Equal(inputStart, outputStart);
            Assert.Equal(inputEnd, outputEnd);
        }
    }
}
