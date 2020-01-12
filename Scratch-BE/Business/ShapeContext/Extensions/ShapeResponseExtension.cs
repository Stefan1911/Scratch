using System.Linq;
using Boundary.ShapeContext.Response;
using Business.Models;

namespace Business.ShapeContext.Extension
{
    public static class ShapeResponseExtension
    {
        public static ShapeResponse ToResponse(this ShapeModel shape)
        {
            return new ShapeResponse
            {
                Id = shape.Id,
                FillColor = shape.FillColor,
                StrockColor = shape.StrockColor,
                Type = shape.Type,
				Points = shape.Points.Select(Point => {
					return new PointResponse{
						X = Point.X,
						Y = Point.Y
					};
				}).ToList()
            };
        }
    }
}
