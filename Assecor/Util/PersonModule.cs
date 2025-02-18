using Interfaces;
using Ninject.Modules;

using Services;

namespace Assecor.Util
{
    public class PersonModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonService>().To<PersonService>();
        }
    }
}
