using Unity.Entities;
namespace MakeBridge
{
    public struct GameConfig : IComponentData
    {
        public int Rounds;
        public bool RandomBrodgeSystem;
        public bool Judge;
        public bool Anime;
        public bool NextRound;
        public int  difficulty;


        public bool Retry;

        public int AnimeNum;

        public float BridgeSpace;


        public float easyBridge;
        public float normalBridge;
        public float hardBridge;
        public float Bridge;

        public int score;
        public int BestScore;
    }
}

