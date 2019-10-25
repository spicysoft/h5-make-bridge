using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;

namespace MakeBridge
{
    public class NextButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();
            var nextButton = false;
            Entities.WithAll<NextButton>().ForEach((Entity entity, ref PointerInteraction pointerInteraction, ref Sprite2DRenderer sprite2D) =>
            {
                if (pointerInteraction.clicked)
                {
                    sprite2D.color.a = 0;
                    nextButton = true;
                    pointerInteraction.clicked = false;
                }
            });

            if (nextButton)
            {
                config.NextRound = true;
                tinyEnv.SetConfigData(config);
            }
        }
    }


}

