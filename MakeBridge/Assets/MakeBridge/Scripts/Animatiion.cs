using Unity.Entities;
using Unity.Tiny.Core;
using Unity.Tiny.Core2D;


namespace MakeBridge
{
    public class Animatiion : ComponentSystem
    {
        bool move;
        float speed = 5;
        float HumanSpeed = 5;
        float fallSpeed = 6;
        bool down;
        bool humanMove;
        protected override void OnUpdate()
        {
            var tinyEnv = World.TinyEnvironment();
            var config = tinyEnv.GetConfigData<GameConfig>();

            if (!config.Anime)
                return;
            move = true;

            Entities.ForEach((Entity entity, ref BuildeBridge buildeBridge, ref Translation translation, ref Sprite2DRenderer sprite2D) =>
            {

                    if (config.AnimeNum == 0)
                {
                    if (move)
                    {
                        translation.Value.y += World.TinyEnvironment().frameDeltaTime * speed;
                    }
                    if (translation.Value.y >= 3)
                    {
                        translation.Value.y = 3;
                        move = false;




                        Entities.ForEach((Entity _entity, ref Human human, ref Translation _translation) =>
                        {
                            _translation.Value.x += World.TinyEnvironment().frameDeltaTime * speed;

                            if(_translation.Value.x >= 10)
                            {
                                _translation.Value.x = 10;

                                Entities.ForEach((Entity _entityA, ref NextButton nextButton, ref Sprite2DRenderer _sprite2D) =>
                                {
                                    _sprite2D.color.a = 1;
                                });

                                Entities.ForEach((Entity _entityB, ref SuccessImage successImage, ref Sprite2DRenderer _sprite2D) =>
                                {
                                    _sprite2D.color.a = 1;

                                });

                                config.Anime = false;
                            }


                        });

                    }
                    
                    tinyEnv.SetConfigData(config);
                }


                else if (config.AnimeNum == 1)
                {
                    if (move)
                    {
                        translation.Value.y += World.TinyEnvironment().frameDeltaTime * speed;
                    }
                    if (translation.Value.y >= 2)
                    {
                        speed = -1;
                        down = true;
                    }
                    if (translation.Value.y <= 1 && down)
                    {
                        translation.Value.y = 1;
                        sprite2D.color.a = 0;
                        move = false;
                        down = false;

                        humanMove = true;

                    }

                    if (humanMove)
                    {
                        Entities.ForEach((Entity _entity, ref Human human, ref Translation _translation, ref Sprite2DRenderer sprite2DHuman) =>
                        {

                            _translation.Value.x += World.TinyEnvironment().frameDeltaTime * HumanSpeed;

                            if (_translation.Value.x >= -1 * config.BridgeSpace / 2 + 0.5f)
                            {
                                HumanSpeed = 1f;
                                _translation.Value.y -= World.TinyEnvironment().frameDeltaTime * fallSpeed;

                                if (_translation.Value.y <= -2)
                                {
                                    sprite2DHuman.color.a = 0;
                                    HumanSpeed = 5;
                                    speed = 5;


                                    Entities.ForEach((Entity _entityB, ref GameOverImage gameOverImage, ref Sprite2DRenderer _sprite2D) =>
                                    {
                                        _sprite2D.color.a = 1;

                                    });
                                    Entities.ForEach((Entity _entityA, ref RetryButton retryButton, ref Sprite2DRenderer _sprite2D) =>
                                    {
                                        _sprite2D.color.a = 1;
                                        config.Anime = false;
                                        humanMove = false;
                                    });
                                }


                            }


                        });
                    }
                  



                    tinyEnv.SetConfigData(config);
                }


                else if (config.AnimeNum == 2)
                {
                    if (move)
                    {
                        translation.Value.y += World.TinyEnvironment().frameDeltaTime * speed;
                    }
                    if (translation.Value.y >= 9)
                    {
                        translation.Value.y = 9;
                        sprite2D.color.a = 0;
                        move = false;
                        //config.Anime = false;


                        Entities.ForEach((Entity _entity, ref Human human, ref Translation _translation, ref Sprite2DRenderer sprite2DHuman) =>
                        {
                            _translation.Value.x += World.TinyEnvironment().frameDeltaTime * speed;

                            if (_translation.Value.x >= -1 * config.BridgeSpace / 2 + 0.5f)
                            {
                                speed = 1f;
                                _translation.Value.y -= World.TinyEnvironment().frameDeltaTime * fallSpeed;

                                if(_translation.Value.y <= -2)
                                {
                                    sprite2DHuman.color.a = 0;
                                    speed = 5;
                                    Entities.ForEach((Entity _entityA, ref RetryButton retryButton, ref Sprite2DRenderer _sprite2D) =>
                                    {
                                        _sprite2D.color.a = 1;
                                        config.Anime = false;
                                   });

                                    Entities.ForEach((Entity _entityB, ref GameOverImage gameOverImage, ref Sprite2DRenderer _sprite2D) =>
                                    {
                                        _sprite2D.color.a = 1;

                                    });
                                }


                            }


                        });

                    }
                    tinyEnv.SetConfigData(config);
                }

               
            });

        }
    }
}


