using Unity.Entities;
using Unity.Tiny.Core;

namespace MakeBridge
{
    public class JudgeSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();

            if (!config.Judge)
                return;
            config.Judge = false;

            if(config.BridgeSpace == config.Bridge)
            {
                config.AnimeNum = 0;
                config.score++;
            }

            else if (config.BridgeSpace < config.Bridge)
            {
                config.AnimeNum = 1;
            }

            else if (config.BridgeSpace > config.Bridge)
            {
                config.AnimeNum = 2;
            }



            config.Anime = true;
            tinyEnv.SetConfigData(config);
        }
    }
}


