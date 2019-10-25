using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;
namespace MakeBridge
{
    public class RetryButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();
            var judgeButton = false;
            Entities.WithAll<RetryButton>().ForEach((Entity entity, ref PointerInteraction pointerInteraction, ref Sprite2DRenderer sprite2D) =>
            {
                if (pointerInteraction.clicked)
                {
                    sprite2D.color.a = 0;
                    judgeButton = true;
                    pointerInteraction.clicked = false;
                }
            });

            if (judgeButton)
            {
                config.Retry = true;
                tinyEnv.SetConfigData(config);
            }
        }
    }
}

