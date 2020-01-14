using System.Threading.Tasks;
using Business.Models;

namespace Business.Contracts
{
    public interface IDrawingBoardMessageBroker
    {
         Task PushShapeAsync(string MessageName,string excludedClientID,ShapeModel shape);
		 Task UpdateShapeAsync(string MessageName, string excludedClientID, int shapeIndex ,ShapeModel ShapeModel);
    }
}