// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using ForEachAndListForEach;

Console.WriteLine("Performance Comparison between Parallel.ForEach and List.ForEach");

var summary = BenchmarkRunner.Run<ParallelVsListBenchmark>();

Console.ReadLine();

