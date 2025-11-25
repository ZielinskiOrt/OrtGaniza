using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.CustomExceptions;
using Business.DTO;
using Data.Repositories.Interfaces;
using Entities.Entities;

namespace Business.Validators
{
    public class ProyectoServiceValidator : IProyectoServiceValidator
    {
        private IProyectoRepository _proyectoRepository;
        private const string MSG_ERROR_USUARIO_EXISTENTE = "Error usuario existente";
        private const string MSG_ERROR_USUARIO_Y_LIDER_EXISTENTE = "El lider no puede ser un usuario colaborador";
        private const string MSG_ERROR_PROYECTO_EXISTENTE = "Error ya existe un proyecto con el mismo nombre";
        public ProyectoServiceValidator(IProyectoRepository proyectoRepository)
        {
            _proyectoRepository = proyectoRepository;
        }
        public void CrearProyectoValidation(ProyectoDTO proyectoDTO)
        {
            if (_proyectoRepository.Existe(proyectoDTO.Nombre,proyectoDTO.ProyectoId))
            {
                throw new ProyectoException(MSG_ERROR_PROYECTO_EXISTENTE);
            }
            else if (proyectoDTO.MiembrosIds.Contains(proyectoDTO.UserId))
            {
                throw new ProyectoException(MSG_ERROR_USUARIO_Y_LIDER_EXISTENTE);
            }
        }

        public void EditarProyectoValidation(ProyectoDTO proyectoDTO)
        {
            this.CrearProyectoValidation(proyectoDTO);
        }
    }
}
