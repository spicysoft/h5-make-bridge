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
            config.score++;
            config.RandomBrodgeSystem = true;

            if (config.Rounds > 5)
            {
                config.difficulty = 1;
            }
            else if (config.Rounds > 10)
            {

                config.difficulty = 2;

            }
            Entities.ForEach((Entity _entity, ref Human human, ref Translation _translation) =>
            {
                _translation.Value.x = -10;


            });

            Entities.ForEach((Entity _entityB, ref SuccessImage successImage, ref Sprite2DRenderer _sprite2D) =>
            {
                _sprite2D.color.a = 0;

            });


            tinyEnv.SetConfigData(config);
        }
    }
}
