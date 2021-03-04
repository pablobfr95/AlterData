using core.Modelo;
using core.Repository;

namespace core.Services.Impl
{
    public class ServicoDominioContato : ServicoDominioBase<Contato>, IServicoDominioContato
    {
        
        public ServicoDominioContato(IRepositorioContato repositorio) : base(repositorio)
        {
            
        }
    }
}