using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;

namespace MakeBridge
{
    public class RetrySystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();
            if (!config.Retry)
                return;

            config.Retry = false;
            config.score = 0;

            Entities.ForEach((Entity entity, ref StartButton startButton, ref Sprite2DRenderer sprite2D) =>
            {
                sprite2D.color.a = 1;
            });

            tinyEnv.SetConfigData(config);
        }
    }
}

