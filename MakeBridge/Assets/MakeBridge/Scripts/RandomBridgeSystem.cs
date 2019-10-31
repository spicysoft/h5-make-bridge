using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;
using Unity.Mathematics;

namespace MakeBridge
{
    public class RandomBridgeSystem : ComponentSystem
    {
        private Random _random;
        float num;
        int easyBlock = 2;
        int normalBlock = 1;
        float hardBlock = 0.5f;
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
            config.Bridge = 2;
            config.easyBridge = 2;
            config.normalBridge = 0;
            config.hardBridge = 0;
            switch (config.difficulty)
            {
                case 0:


                    Entities.ForEach((DynamicBuffer<Buttons> segments) =>
                    {
                        for (int i = 0; i < segments.Length; i++)
                        {
                            var sprite2 = EntityManager.GetComponentData<Sprite2DRenderer>(segments[i].entity);
                            if (i == 0)
                            {
                                sprite2.color.a = 1;
                            }
                            else
                            {
                                sprite2.color.a = 0;
                            }
                            EntityManager.SetComponentData<Sprite2DRenderer>(segments[i].entity, sprite2);
                        }


                    });


                    num = easyBlock *_random.NextInt(1, 4);
                    config.BridgeSpace = num;

                    break;
                case 1:

                    Entities.ForEach((DynamicBuffer<Buttons> segments) =>
                    {
                        for (int i = 0; i < segments.Length; i++)
                        {
                            var sprite2 = EntityManager.GetComponentData<Sprite2DRenderer>(segments[i].entity);
                            if (i < 2)
                            {
                                sprite2.color.a = 1;
                            }
                            else 
                            {
                                sprite2.color.a = 0;
                            }
                            EntityManager.SetComponentData<Sprite2DRenderer>(segments[i].entity, sprite2);
                        }


                    });





                    num = easyBlock * _random.NextInt(1, 4) + normalBlock * _random.NextInt(1, 3);
                    config.BridgeSpace = num;
                    break;

                case 2:


                    Entities.ForEach((DynamicBuffer<Buttons> segments) =>
                    {
                        for (int i = 0; i < segments.Length; i++)
                        {
                            var sprite2 = EntityManager.GetComponentData<Sprite2DRenderer>(segments[i].entity);
                            
                            
                                sprite2.color.a = 1;                            
                          
                            
                            EntityManager.SetComponentData<Sprite2DRenderer>(segments[i].entity, sprite2);
                        }


                    });

                    num = easyBlock * _random.NextInt(1, 4) + normalBlock * _random.NextInt(1, 3) + _random.NextInt(1, 4) + hardBlock * _random.NextInt(1, 4); ;
                    config.BridgeSpace = num;
                    break;

                default:

                    num = _random.NextInt(3, 7);
                    config.BridgeSpace = num;
                    break;

            }


            Entities.ForEach((Entity entity, ref BuildeBridge buildeBridge, ref Sprite2DRenderer sprite2D, ref Translation translation) =>
            {
                translation.Value.y = -8;

                sprite2D.color.a = 1;

            });

            Entities.ForEach((Entity entity, ref JudgeButton judgeButton, ref Sprite2DRenderer sprite2D) =>
            {

                sprite2D.color.a = 1;

            });

            tinyEnv.SetConfigData(config);
        }
    }
}


