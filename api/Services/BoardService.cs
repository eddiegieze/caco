using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;
using Caco.API.Repositories;
using Caco.API.Services.Communication;

namespace Caco.API.Services
{
    public class BoardService : IBoardService
    {
        private IBoardRepository _boardRepository;
        private IUnitOfWork _unitOfWork;

        public BoardService(IBoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Board>> ListBoardsAsync()
        {
            return await _boardRepository.ListAsync();
        }

        public async Task<SaveBoardResponse> SaveAsync(Board Board)
        {
            try
            {
                await _boardRepository.AddAsync(Board);
                await _unitOfWork.CompleteAsync();

                return new SaveBoardResponse(Board);
            }
            catch (Exception ex)
            {
                return new SaveBoardResponse($"An error occurred while saving the Board: {ex.Message}");
            }
        }

        public async Task<SaveBoardResponse> UpdateAsync(int id, Board board)
        {
            var existingBoard = await _boardRepository.FindByIdAsync(id);

            if (existingBoard == null)
            {
                return new SaveBoardResponse("Board not found.");
            }

            existingBoard.Name = board.Name;

            try
            {
                _boardRepository.Update(existingBoard);
                await _unitOfWork.CompleteAsync();

                return new SaveBoardResponse(existingBoard);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveBoardResponse($"An error occurred when updating the Board: {ex.Message}");
            }
        }
    }
}