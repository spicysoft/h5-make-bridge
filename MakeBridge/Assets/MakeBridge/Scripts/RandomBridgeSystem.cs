using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Mathematics;

namespace MakeBridge
{
    public class RandomBridgeSystem : ComponentSystem
    {
        private Random _random;
        protected override void OnCreate()
        {
            _random = new Random();
            _random.InitState();

        }
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();
            if (!config.RandomBrodgeSystem)
                return;
            config.RandomBrodgeSystem = false;
            config.Bridge = 1;
            int num = _random.NextInt(3, 8);
            //int num = 2;
            Entities.ForEach((Entity entity, ref BridgeButton bridgeButton, ref Sprite2DRenderer sprite2D) =>
            {

                sprite2D.color.a = 1;

            });

            Entities.ForEach((Entity entity, ref BuildeBridge buildeBridge, ref Sprite2DRenderer sprite2D, ref Translation translation) =>
            {
                translation.Value.y = -8;

                sprite2D.color.a = 1;

            });

            Entities.ForEach((Entity entity, ref JudgeButton judgeButton, ref Sprite2DRenderer sprite2D) =>
            {

                sprite2D.color.a = 1;

            });



            config.BridgeSpace = num;
            tinyEnv.SetConfigData(config);
        }
    }
}


