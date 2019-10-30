using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;

namespace MakeBridge
{
    public class JudgeButtonSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();
            var judgeButton = false;
            Entities.WithAll<JudgeButton>().ForEach((Entity entity, ref PointerInteraction pointerInteraction, ref Sprite2DRenderer sprite2D) =>
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

                Entities.ForEach((DynamicBuffer<Buttons> segments) =>
                {
                    for (int i = 0; i < segments.Length; i++)
                    {
                        var sprite2 = EntityManager.GetComponentData<Sprite2DRenderer>(segments[i].entity);


                        sprite2.color.a = 0;


                        EntityManager.SetComponentData<Sprite2DRenderer>(segments[i].entity, sprite2);
                    }


                });
                config.Judge = true;
                tinyEnv.SetConfigData(config);
            }
        }
    }
}

