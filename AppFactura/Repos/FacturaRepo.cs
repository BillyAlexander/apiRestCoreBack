using AppFactura.Models;

namespace AppFactura.Repos
{
    public interface FacturaRepo
    {
        IEnumerable<Factura> facturas();

        Factura finFacturaById(int id);

        Task<Factura> createFacturaAsync(Factura factura);

        Task<Factura> updateFacturaAsync(Factura factura);

        Task<bool> deleteFacturaAsync(Factura factura);
    }
}
