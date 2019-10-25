using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;

namespace MakeBridge
{
    public class NextSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();
            if (!config.NextRound)
                return;
            config.NextRound = false;
            config.Rounds++;
            config.RandomBrodgeSystem = true;












            tinyEnv.SetConfigData(config);
        }
    }
}
