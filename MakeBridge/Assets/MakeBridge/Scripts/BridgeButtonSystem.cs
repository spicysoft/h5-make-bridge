using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Tiny.UIControls;

namespace MakeBridge
{
    public class BridgeButtonSystem : ComponentSystem
    {
        float _block;
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();
            var bridgeButton = false;
            Entities.WithAll<BridgeButton>().ForEach((Entity entity, ref PointerInteraction pointerInteraction, ref Sprite2DRenderer sprite2D ,ref BridgeButton bridge) =>
            {
                if (pointerInteraction.clicked)
                {
                    
                    _block = bridge.block;
                    bridgeButton = true;
                    pointerInteraction.clicked = false;
                }
            });

            if (bridgeButton)
            {
                config.Bridge += _block;
                tinyEnv.SetConfigData(config);
            }
        }
    }



}