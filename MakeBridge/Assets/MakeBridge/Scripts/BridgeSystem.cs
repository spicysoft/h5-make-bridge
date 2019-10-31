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
                switch (buildeBridge.difficulty)
                {
                    case 0:

                        nonUniformScale.Value.x = config.easyBridge;

                        break;


                    case 1:

                        nonUniformScale.Value.x = config.easyBridge + config.normalBridge;

                        break;


                    case 2:

                        nonUniformScale.Value.x = config.easyBridge + config.normalBridge + config.hardBridge;

                        break;

                }








                //nonUniformScale.Value.x = config.Bridge;

            });

        }
    }
}
