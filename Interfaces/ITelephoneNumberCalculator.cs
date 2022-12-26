using ChessDialer.Models;
using ChessDialer.Models.Board;
using System.Collections.Generic;

namespace ChessDialer.Interfaces
{
	public interface ITelephoneNumberCalculator
	{
		List<string> GetAllCombinations(ChessBoardBase board, ChessPieceBase chessPiece, int combinationLength);
	}
}
