using System.Collections.Generic;
using System.Linq;
using APELLIDO_T3.WEB.Tests.Helpers;
using APELLIDO_T3.WEB.Web.DB;
using APELLIDO_T3.WEB.Web.Models;
using APELLIDO_T3.WEB.Web.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using NUnit.Framework;

namespace APELLIDO_T3.WEB.Tests.Repositories;

public class UsuarioRepositorioTest
{
    private IQueryable<Cuenta> data;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Cuenta>
        {
            new() { Id = 1, Nombre = "usaurio 01"},
            new() { Id = 2, Nombre = "usuario 02"},
            new() { Id = 3, Nombre = "usuario 03"},
        }.AsQueryable();
    }
    
    [Test]
    public void ObtenerTodosTestCaso01()
    {
        // var mockDbSetUsuario = new Mock<DbSet<Cuenta>>();
        // mockDbSetUsuario.As<IQueryable<Cuenta>>().Setup(o => o.Provider).Returns(data.Provider);
        // mockDbSetUsuario.As<IQueryable<Cuenta>>().Setup(o => o.Expression).Returns(data.Expression);
        // mockDbSetUsuario.As<IQueryable<Cuenta>>().Setup(o => o.ElementType).Returns(data.ElementType);
        // mockDbSetUsuario.As<IQueryable<Cuenta>>().Setup(o => o.GetEnumerator()).Returns(data.GetEnumerator());

        var mockDbSetUsuario = new MockDBSet<Usuario>(data);
        var mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.Usuarios).Returns(mockDbSetUsuario.Object);
        
        var repo = new UsuarioRepositorio(mockDB.Object);
        var result = repo.ObtenerTodos();
        
        Assert.AreEqual(3, result.Count);
    }
}