using System.Linq;
using APELLIDO_T3.WEB.Web.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace APELLIDO_T3.WEB.Tests.Helpers;

public class MockDBSet<T> : Mock<DbSet<T>> where T : class
{
    public MockDBSet(IQueryable<T> data)
    {
        base.As<IQueryable<T>>().Setup(o => o.Provider).Returns(data.Provider);
        base.As<IQueryable<T>>().Setup(o => o.Expression).Returns(data.Expression);
        base.As<IQueryable<T>>().Setup(o => o.ElementType).Returns(data.ElementType);
        base.As<IQueryable<T>>().Setup(o => o.GetEnumerator()).Returns(data.GetEnumerator());
    }
}