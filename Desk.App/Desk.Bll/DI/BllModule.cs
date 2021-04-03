using Autofac;

namespace Desk.Bll.DI
{
    public class BllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.GetType().Assembly).AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}
