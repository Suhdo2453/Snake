using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Caculator
{
    public class CaculatorLifeTimeScope : LifetimeScope
    {
        [SerializeField] private CaculatorView _caculatorView;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<CaculatorController>(Lifetime.Scoped);
            builder.Register<ICaculatorLogic, CaculatorLogic>(Lifetime.Scoped);
            builder.RegisterComponent(_caculatorView);
        }
    }
}
