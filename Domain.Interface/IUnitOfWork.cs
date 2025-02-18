using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Person> Persons { get; }
        IRepository<Color> Colors { get; }
    }
}
