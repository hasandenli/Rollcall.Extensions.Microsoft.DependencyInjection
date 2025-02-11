﻿using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace MultiImplementationBenchark
{
    internal class Program
    {
        static void Main()
        {
#if DEBUG
            var benchmark = new RollcallBenchmarks();
            benchmark.Execute();
            return;
#endif

            var config = ManualConfig.Create(DefaultConfig.Instance)
                  .WithOption(ConfigOptions.JoinSummary, true);

            BenchmarkRunner.Run(new[]{
                BenchmarkConverter.TypeToBenchmarks( typeof(EnumerableBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(FactoryBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(TypeFactoryBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(DelegateBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(TypeDelegateBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(DistinctBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(DistinctFactoryBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(DistinctLookupFactoryBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(RollcallBenchmark), config),
                BenchmarkConverter.TypeToBenchmarks( typeof(RollcallFuncBenchmark), config)
            });
        }
    }
}
