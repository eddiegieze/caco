using Caco.API.Models;

namespace Caco.API.Services.Communication
{
    public class BoardResponse : BaseResponse
    {
        public Board Board { get; private set; }

        private BoardResponse(bool success, string message, Board Board) : base(success, message)
        {
            this.Board = Board;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Board">Saved Board.</param>
        /// <returns>Response.</returns>
        public BoardResponse(Board Board) : this(true, string.Empty, Board)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BoardResponse(string message) : this(false, message, null)
        { }
    }
}