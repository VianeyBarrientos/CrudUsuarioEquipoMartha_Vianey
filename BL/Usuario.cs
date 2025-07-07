using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
    public class Usuario
    {
        public ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.LSanchezProyectoEntities context = new DL.LSanchezProyectoEntities())
                {
                    DL.Usuario usuarioDL = new DL.Usuario();

                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.Apellido = usuario.Apellido;
                    usuarioDL.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    context.Usuarios.Add(usuarioDL);
                    int rowsAffected = context.SaveChanges();
                    if(rowsAffected > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No fue posible insertar el usuario";
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                Console.WriteLine(ex);
            }
            return result;
        }

        public ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.LSanchezProyectoEntities context = new DL.LSanchezProyectoEntities())
                {
                    var query = (from a in context.Usuarios where a.IdUsuario == usuario.IdUsuario select a).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.Apellido = usuario.Apellido;
                        query.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        int rowsAffected = context.SaveChanges();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudieron actualizar los datos  el usuario";
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el usuario";
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                Console.WriteLine(ex);
            }
            return result;  
        }

        public ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.LSanchezProyectoEntities context = new DL.LSanchezProyectoEntities())
                {
                    var usuarioBD = (from usuario in context.Usuarios
                                     where usuario.IdUsuario == IdUsuario
                                     select new
                                     {
                                         IdUsuario = usuario.IdUsuario,
                                         Nombre = usuario.Nombre,
                                         Apellido = usuario.Apellido,
                                         FechaNacimiento = usuario.FechaNacimiento
                                     }).SingleOrDefault();
                    if (usuarioBD != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = usuarioBD.IdUsuario;
                        usuario.Nombre = usuarioBD.Nombre;
                        usuario.Apellido = usuarioBD.Apellido;
                        usuario.FechaNacimiento = Convert.ToString(usuarioBD.FechaNacimiento);
                        
                        result.Object = usuario;
                        result.Correct = true;
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                Console.WriteLine(ex);
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (LSanchezProyectoEntities context = new LSanchezProyectoEntities())
                {
                    var listusuarios = context.Usuarios.ToList();

                    result.Objects = new List<object>();

                    foreach (var usuarioDB in listusuarios)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = usuarioDB.IdUsuario;
                        usuario.Nombre = usuarioDB.Nombre;
                        usuario.Apellido = usuarioDB.Apellido;
                        usuario.FechaNacimiento = Convert.ToString(usuarioDB.FechaNacimiento);

                        result.Objects.Add(usuario);
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (LSanchezProyectoEntities conn = new LSanchezProyectoEntities())
                {
                    var query = (from a in conn.Usuarios where a.IdUsuario == IdUsuario select a).SingleOrDefault();


                    if (query != null)
                    {
                        conn.Usuarios.Remove(query);
                        conn.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el usuario a Eliminar";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.LSanchezProyectoEntities context = new DL.LSanchezProyectoEntities())
                {
                    DL.Usuario usuarioDL = new DL.Usuario();

                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.Apellido = usuario.Apellido;
                    usuarioDL.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    context.Usuarios.Add(usuarioDL);
                    int rowsAffected = context.SaveChanges();
                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No fue posible insertar el usuario";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                Console.WriteLine(ex);
            }
            return result;
        }

        public ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.LSanchezProyectoEntities context = new DL.LSanchezProyectoEntities())
                {
                    var query = (from a in context.Usuarios where a.IdUsuario == usuario.IdUsuario select a).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.Apellido = usuario.Apellido;
                        query.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        int rowsAffected = context.SaveChanges();
                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudieron actualizar los datos  el usuario";
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el usuario";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                Console.WriteLine(ex);
            }
            return result;
        }

        public ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LSanchezProyectoEntities context = new DL.LSanchezProyectoEntities())
                {
                    var usuarioBD = (from usuario in context.Usuarios
                                     where usuario.IdUsuario == IdUsuario
                                     select new
                                     {
                                         IdUsuario = usuario.IdUsuario,
                                         Nombre = usuario.Nombre,
                                         Apellido = usuario.Apellido,
                                         FechaNacimiento = usuario.FechaNacimiento
                                     }).SingleOrDefault();
                    if (usuarioBD != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = usuarioBD.IdUsuario;
                        usuario.Nombre = usuarioBD.Nombre;
                        usuario.Apellido = usuarioBD.Apellido;
                        usuario.FechaNacimiento = Convert.ToString(usuarioBD.FechaNacimiento);

                        result.Object = usuario;
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                Console.WriteLine(ex);
            }
            return result;
        }

    }
}
