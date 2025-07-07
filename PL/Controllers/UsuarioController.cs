using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]// GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects.ToList();
            }

            return View(usuario);
        }
        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            ML.Result result = BL.Usuario.Delete(IdUsuario);

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public ActionResult Formulario(int? IdUsuario) //GetById
        {
            ML.Usuario usuario = new ML.Usuario();
            

            if(IdUsuario > 0)
            {
                ML.Result result = BL.Usuario.GetById(IdUsuario.Value);

                if(result.Correct == true)
                {
                    usuario =(ML.Usuario) result.Object;
                }

            }

            return View(usuario);
        }

       [HttpPost]
       public ActionResult Formulario (ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            if(usuario.IdUsuario == 0)
            {
                result = BL.Usuario.Add(usuario);
                if (result.Correct)
                {
                    return RedirectToAction("GetAll");
                }
            }
            else
            {
                result = BL.Usuario.Update(usuario);
                if (result.Correct)
                {
                    return RedirectToAction("GetAll");
                }
            }
            return View(usuario);
        }
    }
}