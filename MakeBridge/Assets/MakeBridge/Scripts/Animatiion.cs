using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;


namespace MakeBridge
{
    public class Animatiion : ComponentSystem
    {
        bool move;
        float speed = 5;

        bool down;
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();

            if (!config.Anime)
                return;
            move = true;

            Entities.ForEach((Entity entity, ref BuildeBridge buildeBridge, ref Translation translation, ref Sprite2DRenderer sprite2D) =>
            {

                if (config.AnimeNum == 0)
                {
                    if (move)
                    {
                        translation.Value.y += World.TinyEnvironment().frameDeltaTime * speed;
                    }
                    if (translation.Value.y >= 3)
                    {
                        translation.Value.y = 3;
                        move = false;
                        config.Anime = false;

                        Entities.ForEach((Entity _entity, ref NextButton nextButton, ref Sprite2DRenderer _sprite2D) =>
                        {
                            _sprite2D.color.a = 1;
                        });
                    }
                    tinyEnv.SetConfigData(config);
                }


                else if (config.AnimeNum == 1)
                {
                    if (move)
                    {
                        translation.Value.y += World.TinyEnvironment().frameDeltaTime * speed;
                    }
                    if (translation.Value.y >= 2)
                    {
                        speed = -1;
                        down = true;
                    }
                    if (translation.Value.y <= 1 && down)
                    {
                        translation.Value.y = 1;
                        sprite2D.color.a = 0;
                        move = false;
                        config.Anime = false;
                        down = false;
                        speed = 5;
                        Entities.ForEach((Entity _entity, ref RetryButton retryButton, ref Sprite2DRenderer _sprite2D) =>
                        {
                            _sprite2D.color.a = 1;
                        });
                    }
                    tinyEnv.SetConfigData(config);
                }


                else if (config.AnimeNum == 2)
                {
                    if (move)
                    {
                        translation.Value.y += World.TinyEnvironment().frameDeltaTime * speed;
                    }
                    if (translation.Value.y >= 9)
                    {
                        translation.Value.y = 9;
                        sprite2D.color.a = 0;
                        move = false;
                        config.Anime = false;

                        Entities.ForEach((Entity _entity, ref RetryButton retryButton, ref Sprite2DRenderer _sprite2D) =>
                        {
                            _sprite2D.color.a = 1;
                        });
                    }
                    tinyEnv.SetConfigData(config);
                }
            });

        }
    }
}


