using Unity.Entities;
namespace MakeBridge
{
    public struct GameConfig : IComponentData
    {
        public int Rounds;
        public bool RandomBrodgeSystem;

        public float BridgeSpace;
        public float Bridge;
    }
}

