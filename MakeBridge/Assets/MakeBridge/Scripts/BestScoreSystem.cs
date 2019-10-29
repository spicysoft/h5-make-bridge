using Unity.Entities;
using Unity.Tiny.Text;
using Unity.Tiny.Core;

namespace MakeBridge
{
    public class BestScoreSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {

            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();

            if(config.score >= config.BestScore)
            {
                config.BestScore = config.score;
            }

            Entities.ForEach((Entity entity, ref BestScore score) =>
            {

                EntityManager.SetBufferFromString<TextString>(entity, "Best Score:" + config.BestScore.ToString());

            });
            tinyEnv.SetConfigData(config);
        }
    }
}

