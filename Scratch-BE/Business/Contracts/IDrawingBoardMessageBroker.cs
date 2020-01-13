using System.Threading.Tasks;
using Business.Models;

namespace Business.Contracts
{
    public interface IDrawingBoardMessageBroker
    {
         Task PushShape(string MessageName,ShapeModel shape);
    }
}