using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;

namespace MakeBridge
{
    public class SpaceSet : ComponentSystem
    {
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();

            Entities.ForEach((Entity entity, ref BridgeSpace bridgeSpace, ref NonUniformScale nonUniformScale) =>
            {

                nonUniformScale.Value.x = config.BridgeSpace;

            });
        }
    }
}


