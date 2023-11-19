using BenchmarkDotNet.Attributes;

namespace ForEachAndListForEach
{
    public class ParallelVsListBenchmark
    {
        private List<int> data;

        [Params(1000000)] // Adjust the size of the dataset as needed
        public int DataSize;

        [GlobalSetup]
        public void Setup()
        {
            // Generating a large collection of integers
            Random rand = new Random();
            data = new List<int>(DataSize);
            for (int i = 0; i < DataSize; i++)
            {
                data.Add(rand.Next(100));
            }
        }

        [Benchmark]
        public void ParallelForEachBenchmark()
        {
            Parallel.ForEach(data, item =>
            {
                // Simulating a CPU-bound operation (e.g., some intensive calculation)
                int result = Calculate(item);
            });
        }

        [Benchmark]
        public void ListForEachBenchmark()
        {
            data.ForEach(item =>
            {
                // Simulating the same CPU-bound operation
                int result = Calculate(item);
            });
        }

        // Simulated CPU-bound operation
        private int Calculate(int value)
        {
            // Simulating some CPU-bound calculation
            return value * value;
        }
    }
}
