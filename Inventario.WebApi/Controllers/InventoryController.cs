using Inventario.UseCasesDTOs.General;
using Inventario.UseCasesDTOs.Inventory.ListInventory;
using Inventario.UseCasesPorts.Inventory.FormInventory;
using Inventario.UseCasesPorts.Inventory.ListInventory;
using Microsoft.AspNetCore.Mvc;
using Presenters.Inventory.FormInventory;
using Presenters.Inventory.ListInventory;

namespace Inventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        readonly IListInventoryInputPort ListInventoryInputPort;
        readonly IListInventoryOutputPort ListInventoryOutputPort;

        readonly IFormInventoryInputPort FormInventoryInputPort;
        readonly IFormInventoryOutputPort FormInventoryOutputPort;

        public InventoryController
            (IListInventoryInputPort listInventoryInputPort, IListInventoryOutputPort listInventoryOutputPort,
            IFormInventoryInputPort formInventoryInputPort, IFormInventoryOutputPort formInventoryOutputPort) =>
            (ListInventoryInputPort, ListInventoryOutputPort, FormInventoryInputPort, FormInventoryOutputPort) =
            (listInventoryInputPort, listInventoryOutputPort, formInventoryInputPort, formInventoryOutputPort);


        #region EndPoint: Obtener Todos los Productos

        [HttpGet]
        public async Task<IEnumerable<ListInventoryResponse>> GetInventory()
        {

            await ListInventoryInputPort.GetInventory();

            var Presenter = ListInventoryOutputPort as ListInventoryPresenter;

            return Presenter.Content;
        }
        #endregion


        #region EndPoint: Obtener Un Producto por Id
        [HttpGet("{nIdProducto}")]
        public async Task<IEnumerable<ListInventoryResponse>> GetInventoryById(int nOpcion, int nIdProducto)
        {

            await ListInventoryInputPort.GetInventoryById(nOpcion, nIdProducto);

            var Presenter = ListInventoryOutputPort as ListInventoryPresenter;

            return Presenter.Content;
        }
        #endregion


        #region EndPoint: Insertar | Editar | Eliminar => Producto
        [HttpPost]
        public async Task<GeneralResponse> PostInventory(GeneralRequest request)
        {

            await FormInventoryInputPort.PostInventory(request);

            var Presenter = FormInventoryOutputPort as FormInventoryPresenter;

            return Presenter.Content;
        }
        #endregion
    }
}
