using Caco.API.Models;

namespace Caco.API.Services.Communication
{
    public class SaveBoardResponse : BaseResponse
    {
        public Board Board { get; private set; }

        private SaveBoardResponse(bool success, string message, Board Board) : base(success, message)
        {
            this.Board = Board;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Board">Saved Board.</param>
        /// <returns>Response.</returns>
        public SaveBoardResponse(Board Board) : this(true, string.Empty, Board)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveBoardResponse(string message) : this(false, message, null)
        { }
    }
}