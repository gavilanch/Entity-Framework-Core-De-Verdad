using AutoMapper;
using EFCorePeliculas.Entidades;
using System.Collections.ObjectModel;

namespace EFCorePeliculas.Servicios
{
    public interface IActualizadorObservableCollection
    {
        void Actualizar<ENT, DTO>(ObservableCollection<ENT> entidades, IEnumerable<DTO> dtos)
            where ENT : IId
            where DTO : IId;
    }

    public class ActualizadorObservableCollection: IActualizadorObservableCollection
    {
        private readonly IMapper mapper;

        public ActualizadorObservableCollection(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void Actualizar<ENT, DTO>(ObservableCollection<ENT> entidades, IEnumerable<DTO> dtos)
            where ENT : IId
            where DTO : IId
        {
            var diccionarioEntidades = entidades.ToDictionary(x => x.Id);
            var diccionarioDTOs = dtos.ToDictionary(x => x.Id);

            var idsEntidades = diccionarioEntidades.Select(x => x.Key);
            var idsDTOs = diccionarioDTOs.Select(x => x.Key);

            var crear = idsDTOs.Except(idsEntidades);
            var borrar = idsEntidades.Except(idsDTOs);
            var actualizar = idsEntidades.Intersect(idsDTOs);

            foreach (var id in crear)
            {
                var entidad = mapper.Map<ENT>(diccionarioDTOs[id]);
                entidades.Add(entidad);
            }

            foreach (var id in borrar)
            {
                var entidad = diccionarioEntidades[id];
                entidades.Remove(entidad);
            }

            foreach (var id in actualizar)
            {
                var dto = diccionarioDTOs[id];
                var entidad = diccionarioEntidades[id];
                entidad = mapper.Map(dto, entidad);
            }
        }
    }
}
