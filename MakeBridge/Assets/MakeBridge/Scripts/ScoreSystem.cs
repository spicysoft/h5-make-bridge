using Unity.Entities;
using Unity.Tiny.Text;
using Unity.Tiny.Core;

namespace MakeBridge
{
    public class ScoreSystem : ComponentSystem
    {

        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();

            Entities.ForEach((Entity entity, ref ScoreText score) =>
            {

                    EntityManager.SetBufferFromString<TextString>(entity, "Score:" + config.score.ToString());
              
            });
        }
    }
}

