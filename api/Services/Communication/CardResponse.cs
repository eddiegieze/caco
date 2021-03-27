using Caco.API.Models;

namespace Caco.API.Services.Communication
{
    public class CardResponse : BaseResponse
    {
        public Card Card { get; private set; }

        private CardResponse(bool success, string message, Card card) : base(success, message)
        {
            this.Card = card;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="card">Saved Card.</param>
        /// <returns>Response.</returns>
        public CardResponse(Card card) : this(true, string.Empty, card)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CardResponse(string message) : this(false, message, null)
        { }
    }
}