using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class DrawingBoardModel
    {
        public string Id { get; set; }
        public ChatModel Chat { get; set; }
        public List<ShapeModel> Shapes { get; set; }

    }
}