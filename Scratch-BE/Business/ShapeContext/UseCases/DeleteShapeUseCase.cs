using System.Threading.Tasks;
using Boundary.ShapeContext.Request;
using Boundary.ShapeContext.Response;
using Business.Contracts;
using Kernel;
using Kernel.Response;

namespace Business.ShapeContext.UseCases
{
    public class DeleteShapeUseCase : IHandle<DeleteShapeRequest, NoResponse>
    {
        private IShapeRepository _shapeRepository;
        private IDrawingBoardMessageBroker _messageBroker;
        public DeleteShapeUseCase(IShapeRepository repository, IDrawingBoardMessageBroker broker)
        {
            _shapeRepository = repository;
            _messageBroker = broker;
        }
        public async Task<NoResponse> HandleAsync(DeleteShapeRequest request)
        {
            await this._shapeRepository.DeleteAsync(request.TableId,request.ShapeId);
            await this._messageBroker.DeleteShapeAsync(request.TableId,request.ClientId,request.ShapeId);
            return new NoResponse();
        }
    }
}