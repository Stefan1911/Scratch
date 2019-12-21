﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class ProjectModel
    {
        public String Id { get; set; }
        public String  Name { get; set; }
        public List<DrawingBoardModel> DrawingBoards { get; set; }
        public List<String> UserIDs { get; set; }

    }
}
