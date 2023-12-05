
using UnityEngine;
using VContainer;
using VContainer.Unity;
using vContainerDemo;

namespace vContainerDemo
{
    public class GameLifeTimeScope : LifetimeScope
    {
        [SerializeField] HelloScreen _helloScreen;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GamePresenter>(Lifetime.Singleton);
            builder.Register<HelloWorldService>(Lifetime.Singleton);
            builder.RegisterComponent(_helloScreen);
        }
    }
}
