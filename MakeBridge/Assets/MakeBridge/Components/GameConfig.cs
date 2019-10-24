using Unity.Entities;
namespace MakeBridge
{
    public struct GameConfig : IComponentData
    {
        public int Rounds;
        public bool RandomBrodgeSystem;
        public bool Judge;
        public bool Anime;

        public int AnimeNum;

        public float BridgeSpace;
        public float Bridge;

        public int score;
    }
}

