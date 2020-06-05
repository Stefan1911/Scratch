using System.Threading.Tasks;
using Business.Models;

namespace Business.Contracts
{
    public interface IDrawingBoardMessageBroker
    {
         Task PushShapeAsync(string MessageName,string excludedClientID,ShapeModel shape);
		 Task UpdateShapeAsync(string MessageName, string excludedClientID, int shapeIndex ,ShapeModel ShapeModel);
         Task DeleteShapeAsync(string MessageName, string excludedClientID, string shapeId);
         Task AddDrawingBoard(string MessageName, string excludedClientID, DrawingBoardModel drawingBoard);
         Task DeleteDrawingBoard(string MessageName, string boardId);
        Task RenameDrawingBoard(string ProjectId, string TableId, string Name);

    }
}