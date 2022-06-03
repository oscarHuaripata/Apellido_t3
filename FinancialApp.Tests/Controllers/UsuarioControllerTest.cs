using System.Collections.Generic;
using System.Security.Claims;
using APELLIDO_T3.WEB.Web.Controllers;
using APELLIDO_T3.WEB.Web.Models;
using APELLIDO_T3.WEB.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace APELLIDO_T3.WEB.Tests.Controllers;

public class UsuarioControllerTest
{
    [Test]
    public void CreateViewCase01()
    {
        var mockTipoRepositorio = new Mock<ITipoUsuarioRepositorio>();
        mockTipoRepositorio.Setup(o => o.ObtenerTodos()).Returns(new List<TipoCuenta>());
        
        var controller = new UsuarioController(mockTipoRepositorio.Object, null);
        var view = controller.Create();
        
        Assert.IsNotNull(view);
    }

    [Test]
    public void IndexCase01()
    {

        var claimsPrincipal = new Mock<ClaimsPrincipal>();
        claimsPrincipal.Setup(o => o.Claims).Returns(new List<Claim>() {new Claim(ClaimTypes.Name, "admin")});
        var context = new Mock<HttpContext>();
        context.Setup(o => o.User).Returns(claimsPrincipal.Object);
        var mock = new Mock<ITipoUsuarioRepositorio>();
        var controller = new UsuarioController(mock.Object, null);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext =context.Object
        };
        var result = controller.Index();

    }
    
}