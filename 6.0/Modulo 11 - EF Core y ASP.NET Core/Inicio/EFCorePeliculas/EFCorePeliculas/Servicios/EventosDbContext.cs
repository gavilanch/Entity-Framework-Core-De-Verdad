using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCorePeliculas.Servicios
{
    public interface IEventosDbContext
    {
        void ManejarSaveChangesFailed(object sender, SaveChangesFailedEventArgs args);
        void ManejarSavedChanges(object sender, SavedChangesEventArgs args);
        void ManejarSavingChanges(object sender, SavingChangesEventArgs args);
        void ManejarStateChange(object sender, EntityStateChangedEventArgs args);
        void ManejarTracked(object sender, EntityTrackedEventArgs args);
    }

    public class EventosDbContext: IEventosDbContext
    {
        private readonly ILogger<EventosDbContext> logger;

        public EventosDbContext(ILogger<EventosDbContext> logger)
        {
            this.logger = logger;
        }

        public void ManejarTracked(object sender, EntityTrackedEventArgs args)
        {
            var mensaje = $"Entidad: {args.Entry.Entity}, estado: {args.Entry.State}";
            logger.LogInformation(mensaje);
        }

        public void ManejarStateChange(object sender, EntityStateChangedEventArgs args)
        {
            var mensaje = $@"Entidad: {args.Entry.Entity}, estado anterior: {args.OldState} 
                        - estado nuevo: {args.NewState}";
            logger.LogInformation(mensaje);
        }

        public void ManejarSavingChanges(object sender, SavingChangesEventArgs args)
        {
            var entidades = ((ApplicationDbContext)sender).ChangeTracker.Entries();

            foreach (var entidad in entidades)
            {
                var mensaje = $"Entidad: {entidad.Entity} va a ser {entidad.State}";
                logger.LogInformation(mensaje);
            }
        }

        public void ManejarSavedChanges(object sender, SavedChangesEventArgs args)
        {
            var mensaje = $"Fueron procesadas {args.EntitiesSavedCount} entidades";
            logger.LogInformation(mensaje);
        }

        public void ManejarSaveChangesFailed(object sender, SaveChangesFailedEventArgs args)
        {
            logger.LogError(args.Exception, "Error en el SaveChanges");
        }
    }
}
