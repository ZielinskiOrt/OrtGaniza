using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;

namespace Business.Validators
{
    public interface IProyectoServiceValidator 
    {
        void CrearProyectoValidation(ProyectoDTO proyectoDTO);
        void EditarProyectoValidation(ProyectoDTO proyectoDTO);
    }
}
