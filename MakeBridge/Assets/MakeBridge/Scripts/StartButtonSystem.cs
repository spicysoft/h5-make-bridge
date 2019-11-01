using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;

namespace MakeBridge
{
    public class StartButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();
            var startButton = false;
            Entities.WithAll<StartButton>().ForEach((Entity entity, ref PointerInteraction pointerInteraction, ref Sprite2DRenderer sprite2D) =>
            {
                if (pointerInteraction.clicked)
                {
                    sprite2D.color.a = 0;
                    startButton = true;
                    pointerInteraction.clicked = false;
                }
            });

            if (startButton)
            {
                Entities.ForEach((Entity entity, ref Title title, ref Sprite2DRenderer sprite2D) =>
                {
                    sprite2D.color.a = 0;
                });

                config.RandomBrodgeSystem = true;
                tinyEnv.SetConfigData(config);
            }
        }
    }
}


