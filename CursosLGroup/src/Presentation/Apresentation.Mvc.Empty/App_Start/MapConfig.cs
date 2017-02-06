using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FastMapper;
using Domain.GerenciamentoCursosLGroup.Entities;
using Apresentation.Mvc.Empty.Models;

namespace Apresentation.Mvc.Empty.App_Start
{
    public static class MapConfig
    {
        public static void Inicialize()
        {
            //Para mapear um objeto que tenha nomes diferentes
            //Basta fazer igual ao código abaixo:
            TypeAdapterConfig<CursoEntity, CursosViewModel>
                .NewConfig()
                .MapFrom(dest => dest.IdCategoria,
                         src => src.CategoriaId);

            TypeAdapterConfig<CursosViewModel, CursoEntity>
                .NewConfig()
                .MapFrom(dest => dest.CategoriaId,
                         src => src.IdCategoria);
        }
    }
}