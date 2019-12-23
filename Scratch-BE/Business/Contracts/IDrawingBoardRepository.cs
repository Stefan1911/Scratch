﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IDrawingBoardRepository
    {
        Task<DrawingBoardModel> AddAsync(DrawingBoardModel board);
        Task<DrawingBoardModel> GetAsync(int id);
        Task<IEnumerable<DrawingBoardModel>> GetCollecionAsync();
    }
}