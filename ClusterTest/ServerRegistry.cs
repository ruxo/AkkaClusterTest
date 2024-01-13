using LanguageExt;

namespace ClusterTest;

public sealed class ServerRegistry
{
    const string RegistryFile = @"c:\temp\akka_cluster_test.txt";
    const int RequiredSeedNumber = 3;
    
    Lst<string> seeds = toList(File.ReadLines(RegistryFile));

    public Seq<string> SeedNodes => seeds.ToSeq();

    public Seq<string> NodeUp(string nodeAddress) {
        if (seeds.Count < RequiredSeedNumber) {
            seeds = seeds.Add(nodeAddress);
            File.WriteAllLines(RegistryFile, seeds);
        }
        return SeedNodes;
    }
}