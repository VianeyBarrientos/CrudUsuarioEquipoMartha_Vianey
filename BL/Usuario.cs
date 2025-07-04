using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LSanchezProyectoEntities conn = new DL.LSanchezProyectoEntities()) ;

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMesage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
       
    }
}
