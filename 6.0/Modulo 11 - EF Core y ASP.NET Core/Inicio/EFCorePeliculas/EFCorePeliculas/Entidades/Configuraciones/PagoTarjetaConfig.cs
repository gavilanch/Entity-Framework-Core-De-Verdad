using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCorePeliculas.Entidades.Configuraciones
{
    public class PagoTarjetaConfig : IEntityTypeConfiguration<PagoTarjeta>
    {
        public void Configure(EntityTypeBuilder<PagoTarjeta> builder)
        {
            builder.Property(p => p.Ultimos4Digitos).HasColumnType("char(4)").IsRequired();

            var pago1 = new PagoTarjeta()
            {
                Id = 1,
                FechaTransaccion = new DateTime(2022, 1, 6),
                Monto = 500,
                TipoPago = TipoPago.Tarjeta,
                Ultimos4Digitos = "0123"
            };

            var pago2 = new PagoTarjeta()
            {
                Id = 2,
                FechaTransaccion = new DateTime(2022, 1, 6),
                Monto = 120,
                TipoPago = TipoPago.Tarjeta,
                Ultimos4Digitos = "1234"
            };

            builder.HasData(pago1, pago2);

        }
    }
}
