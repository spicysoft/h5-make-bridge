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
            config.Rounds = 0;
            config.difficulty = 0;

            Entities.ForEach((Entity entity, ref StartButton startButton, ref Sprite2DRenderer sprite2D) =>
            {
                sprite2D.color.a = 1;
            });


            Entities.ForEach((Entity entity, ref Title title , ref Sprite2DRenderer sprite2D) =>
            {
                sprite2D.color.a = 1;
            });

            Entities.ForEach((Entity _entityB, ref GameOverImage gameOverImage, ref Sprite2DRenderer _sprite2D) =>
            {
                _sprite2D.color.a = 0;

            });
            Entities.ForEach((Entity _entity, ref Human human, ref Translation _translation, ref Sprite2DRenderer _sprite2D) =>
            {
                _translation.Value.x = -10;
                _translation.Value.y = 4.7f;
                _sprite2D.color.a = 1;

            });
            tinyEnv.SetConfigData(config);
        }
    }
}

