using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Mathematics;

namespace MakeBridge
{
    public class RandomBridgeSystem : ComponentSystem
    {
        private Random _random;
        protected override void OnCreate()
        {
            _random = new Random();
            _random.InitState();

        }
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();
            if (!config.RandomBrodgeSystem)
                return;
            config.RandomBrodgeSystem = false;

            int num = _random.NextInt(3, 11);
            config.BridgeSpace = num;
            tinyEnv.SetConfigData(config);
        }
    }
}


