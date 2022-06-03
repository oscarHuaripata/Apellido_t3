using System.Collections.Generic;
using System.Linq;
using APELLIDO_T3.WEB.Tests.Helpers;
using APELLIDO_T3.WEB.Web.DB;
using APELLIDO_T3.WEB.Web.Models;
using APELLIDO_T3.WEB.Web.Repositories;
using Moq;
using NUnit.Framework;

namespace APELLIDO_T3.WEB.Tests.Repositories;

public class TipoUsuarioRepositorioTest
{
    private IQueryable<TipoCuenta> data;
    private Mock<DbEntities> mockDB;

    [SetUp]
    public void SetUp()
    {
        data = new List<TipoUsuario>
        {
            new() {Id = 1, Nombre = "masculino"},
            new() {Id = 2, Nombre = "Dfemenino"},
        }.AsQueryable();
        
        var mockDbSetTipoUsuario = new MockDBSet<TipoUsuario>(data);
        mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.TipoUsuarios).Returns(mockDbSetTipoUsuario.Object);
    }
    
    [Test]
    public void ObtenerTodosTestCaso01()
    {
        // var mockDbSetTipoUsuario = new Mock<DbSet<TipoCuenta>>();
        // mockDbSetTipoUsuario.As<IQueryable<TipoCuenta>>().Setup(o => o.Provider).Returns(data.Provider);
        // mockDbSetTipoUsuario.As<IQueryable<TipoCuenta>>().Setup(o => o.Expression).Returns(data.Expression);
        // mockDbSetTipoUsuario.As<IQueryable<TipoCuenta>>().Setup(o => o.ElementType).Returns(data.ElementType);
        // mockDbSetTipoUsuario.As<IQueryable<TipoCuenta>>().Setup(o => o.GetEnumerator()).Returns(data.GetEnumerator());

        var repo = new TipoUsuariosRepositorio(mockDB.Object);
        var result = repo.ObtenerTodos();
        
        Assert.AreEqual(2, result.Count);
    }

    [Test]
    public void ObtenerPorNombreTestCaso01()
    {
        var repo = new TipousuarioRepositorio(mockDB.Object);
        var result = repo.ObtenerPoNombre("mascullino");
        
        Assert.AreEqual(1, result.Count);
    }
    
    [Test]
    public void ObtenerPorNombreTestCaso02()
    {
        var repo = new TipoUsuarioRepositorio(mockDB.Object);
        var result = repo.ObtenerPoNombre("femenino");
        
        Assert.AreEqual(0, result.Count);
    }
}

 