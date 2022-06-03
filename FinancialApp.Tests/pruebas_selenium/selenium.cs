using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APELLIDO_T3.WEB.Tests.pruebas_selenium
{
    
        [TestFixture]
        class Selenium
        {
            string Ruta = "http://localhost:58972/";
            ChromeOptions opciones = new ChromeOptions();
            [Test]
            public void HomeIndexTest()
            {

                ChromeDriver navegador = new ChromeDriver();
                navegador.Url = Ruta;
                navegador.FindElementByName("Username");
                navegador.FindElementByName("Password");
                navegador.FindElementById("BotonLogin").Click();
                var page = navegador.FindElementByName("homeIndex");
                Assert.IsNotNull(page);
                navegador.Close();
            }
            [Test]
            public void ButtonUsuarioTest()
            {

                ChromeDriver navegador = new ChromeDriver();
                navegador.Url = Ruta;
                navegador.FindElementByName("Username");
                navegador.FindElementByName("Password");
                navegador.FindElementById("BotonLogin").Click();
                navegador.FindElementById("BotonTomarusuario").Click();
                var page = navegador.FindElementById("Confirmar");
                Assert.IsNotNull(page);
                navegador.Close();
            }
            [Test]
            public void ButtonIniciarusuarioTest()
            {

                ChromeDriver navegador = new ChromeDriver();
                navegador.Url = Ruta;
                navegador.FindElementByName("Username");
                navegador.FindElementByName("Password");
                navegador.FindElementById("BotonLogin").Click();
                navegador.FindElementById("BotonUsuario").Click();
                navegador.FindElementById("buttonUsuario").Click();
                var page = navegador.FindElementById("Guardar");
                Assert.IsNotNull(page);
                navegador.Close();
            }
            [Test]
           
            
            public void ButtonCrearUsuarioTest()
            {

                ChromeDriver navegador = new ChromeDriver();
                navegador.Url = Ruta;
                navegador.FindElementByName("Username");
                navegador.FindElementByName("Password");
                navegador.FindElementById("BotonLogin").Click();
                navegador.FindElementById("usuarioLink").Click();
                navegador.FindElementById("crearusuarioLink").Click();
                var page = navegador.FindElementById("crearusuario");
                Assert.IsNotNull(page);
                navegador.Close();
            }
            [Test]
            public void CrearusuarioIsOkTest()
            {

                ChromeDriver navegador = new ChromeDriver();
                navegador.Url = Ruta;
                navegador.FindElementByName("Username");
                navegador.FindElementByName("Password");
                navegador.FindElementById("BotonLogin").Click();
                navegador.FindElementById("usuarioLink").Click();
                navegador.FindElementById("crearusuarioLink").Click();
                navegador.FindElementById("Nombre").SendKeys("Prueba");
                navegador.FindElementById("Historia").Click();
                navegador.FindElementById("Descripcion").SendKeys("Historia");
                navegador.FindElementById("btnguardarusuario").Click();
                var page = navegador.FindElementById("usuarios");
                Assert.IsNotNull(page);
                navegador.Close();
            }
            [Test]
            
           
            public void ButtonEditPreguntasTemaIsOkTest()
            {

                ChromeDriver navegador = new ChromeDriver();
                navegador.Url = Ruta;
                navegador.FindElementByName("Username");
                navegador.FindElementByName("Password");
                navegador.FindElementById("BotonLogin").Click();
                navegador.FindElementById("temaLink").Click();
                //
                navegador.FindElementById("preguntas+1").Click();

                navegador.FindElementById("Editar+1").Click();

                var page = navegador.FindElementById("EditarPregunta");
                Assert.IsNotNull(page);
                navegador.Close();


            }
            [Test]
            public void listarUsuariosIsOkTest()
            {

                ChromeDriver navegador = new ChromeDriver();
                navegador.Url = Ruta;
                navegador.FindElementByName("Username");
                navegador.FindElementByName("Password");
                navegador.FindElementById("BotonLogin").Click();
                navegador.FindElementById("usuarioLink").Click();
                //
                navegador.FindElementById("Listar").Click();

                
                navegador.FindElementByName("Descripcion");

               
                navegador.Close();

                       


            }
        }
    }



