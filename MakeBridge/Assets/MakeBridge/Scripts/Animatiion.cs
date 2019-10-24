using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;


namespace MakeBridge
{
    public class Animatiion : ComponentSystem
    {
        bool move;
        float speed = 5;
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();

            if (!config.Anime)
                return;

            move = true;
            if (config.AnimeNum == 0)
            {
                Entities.ForEach((Entity entity, ref BuildeBridge buildeBridge, ref Translation translation) =>
                {
                    if (move)
                    {
                        translation.Value.y += World.TinyEnvironment().frameDeltaTime * speed;
                    }
                    if(translation.Value.y >= 3)
                    {
                        translation.Value.y = 3;
                        move = false;
                        config.Anime = false;
                    }

                });

                tinyEnv.SetConfigData(config);
            }

            else if (config.AnimeNum == 1)
            {
                Entities.ForEach((Entity entity, ref BuildeBridge buildeBridge, ref Translation translation) =>
                {
                    if (move)
                    {
                        translation.Value.y += World.TinyEnvironment().frameDeltaTime * speed;
                    }
                    if (translation.Value.y >= 2)
                    {
                        speed = -4;
                    }

                    if (translation.Value.y <= -12)
                    {
                        translation.Value.y = -12;
                        move = false;
                        config.Anime = false;
                    }

                });

                tinyEnv.SetConfigData(config);
            }

            else if (config.AnimeNum == 2)
            {
                Entities.ForEach((Entity entity, ref BuildeBridge buildeBridge, ref Translation translation) =>
                {
                    if (move)
                    {
                        translation.Value.y += World.TinyEnvironment().frameDeltaTime * speed;
                    }
                    if (translation.Value.y >= 12)
                    {
                        translation.Value.y = 12;
                        move = false;
                        config.Anime = false;
                    }

                });

                tinyEnv.SetConfigData(config);
            }




        }
    }
}


