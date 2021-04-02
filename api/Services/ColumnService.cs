using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;
using Caco.API.Repositories;
using Caco.API.Services.Communication;

namespace Caco.API.Services
{
    public class ColumnService : IColumnService
    {
        private IColumnRepository _columnRepository;
        private IUnitOfWork _unitOfWork;

        public ColumnService(IColumnRepository columnRepository, IUnitOfWork unitOfWork)
        {
            _columnRepository = columnRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Exists(int id)
        {
            return await _columnRepository.FindByIdAsync(id) != null;
        }

        public async Task<IEnumerable<Column>> ListColumnsAsync(int boardId)
        {
            return await _columnRepository.ListAsync(boardId);
        }

        public async Task<ColumnResponse> SaveAsync(int boardId, Column column)
        {
            try
            {
                column.BoardId = boardId;
                await _columnRepository.AddAsync(column);
                await _unitOfWork.CompleteAsync();

                return new ColumnResponse(column);
            }
            catch (Exception ex)
            {
                return new ColumnResponse($"An error occurred while saving the Column: {ex.Message}");
            }
        }

        public async Task<ColumnResponse> UpdateAsync(int id, Column column)
        {
            var existingColumn = await _columnRepository.FindByIdAsync(id);

            if (existingColumn == null)
            {
                return new ColumnResponse("Column not found.");
            }

            existingColumn.Name = column.Name;

            try
            {
                _columnRepository.Update(existingColumn);
                await _unitOfWork.CompleteAsync();

                return new ColumnResponse(existingColumn);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ColumnResponse($"An error occurred when updating the Column: {ex.Message}");
            }
        }

        public async Task<ColumnResponse> DeleteAsync(int id)
        {
            var existingColumn = await _columnRepository.FindByIdAsync(id);

            if (existingColumn == null)
                return new ColumnResponse("Column not found.");

            try
            {
                _columnRepository.Remove(existingColumn);
                await _unitOfWork.CompleteAsync();

                return new ColumnResponse(existingColumn);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ColumnResponse($"An error occurred when deleting the Column: {ex.Message}");
            }
        }
    }
}