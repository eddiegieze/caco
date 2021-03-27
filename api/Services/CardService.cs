using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Caco.API.Models;
using Caco.API.Repositories;
using Caco.API.Services.Communication;

namespace Caco.API.Services
{
    public class CardService : ICardService
    {
        private ICardRepository _cardRepository;
        private IUnitOfWork _unitOfWork;

        public CardService(ICardRepository cardRepository, IUnitOfWork unitOfWork)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Card>> ListCardsAsync(int columnId)
        {
            return await _cardRepository.ListAsync(columnId);
        }

        public async Task<CardResponse> SaveAsync(int columnId, Card card)
        {
            try
            {
                card.ColumnId = columnId;
                await _cardRepository.AddAsync(card);
                await _unitOfWork.CompleteAsync();

                return new CardResponse(card);
            }
            catch (Exception ex)
            {
                return new CardResponse($"An error occurred while saving the Card: {ex.Message}");
            }
        }

        public async Task<CardResponse> UpdateAsync(int id, Card card)
        {
            var existingCard = await _cardRepository.FindByIdAsync(id);

            if (existingCard == null)
            {
                return new CardResponse("Card not found.");
            }

            existingCard.Name = card.Name;

            try
            {
                _cardRepository.Update(existingCard);
                await _unitOfWork.CompleteAsync();

                return new CardResponse(existingCard);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CardResponse($"An error occurred when updating the Card: {ex.Message}");
            }
        }

        public async Task<CardResponse> DeleteAsync(int id)
        {
            var existingCard = await _cardRepository.FindByIdAsync(id);

            if (existingCard == null)
                return new CardResponse("Card not found.");

            try
            {
                _cardRepository.Remove(existingCard);
                await _unitOfWork.CompleteAsync();

                return new CardResponse(existingCard);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CardResponse($"An error occurred when deleting the Card: {ex.Message}");
            }
        }
    }
}