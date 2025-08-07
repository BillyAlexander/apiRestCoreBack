using AppFactura.Models;
using Microsoft.EntityFrameworkCore;

namespace AppFactura.Repos
{
    public class FacturaRepoImpl : FacturaRepo
    {
        private readonly DbFacturaContext _facturaContext;

        public FacturaRepoImpl(DbFacturaContext facturaContext)=> _facturaContext = facturaContext;

        public async Task<Factura> createFacturaAsync(Factura factura)
        {
            await _facturaContext.Set<Factura>().AddAsync(factura);
            await _facturaContext.SaveChangesAsync();
            return factura;
        }

        public async Task<bool> deleteFacturaAsync(Factura factura)
        {
            if (factura == null)
            {
                return false;
            }
            _facturaContext.Set<Factura>().Remove(factura);
            await _facturaContext.SaveChangesAsync() ;
            return true;
        }

        public IEnumerable<Factura> facturas()
        {
            return _facturaContext.Facturas.ToList();
        }

        public Factura finFacturaById(int id)
        {
            return _facturaContext.Facturas.Find(id);
        }

        public async Task<Factura> updateFacturaAsync(Factura factura)
        {
            _facturaContext.Entry(factura).State = EntityState.Modified;
            await _facturaContext.SaveChangesAsync();
            return factura;     
        }
    }
}
