using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
namespace MakeBridge
{
    public class BridgeSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();


            Entities.ForEach((Entity entity, ref BuildeBridge buildeBridge, ref NonUniformScale nonUniformScale) =>
            {

                nonUniformScale.Value.x = config.Bridge;

            });

        }
    }
}
