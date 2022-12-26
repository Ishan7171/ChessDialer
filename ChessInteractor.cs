using ChessDialer.Interfaces;
using ChessDialer.Models;
using ChessDialer.Models.Board;
using System.Collections.Generic;
using System.Linq;


namespace ChessDialer
{
	public class ChessInteractor
	{
		public ChessBoardBase Board;
		public ITelephoneNumberCalculator TelephoneNumberCalculator;
		public IValidator NumberValidator;
		public ChessPieceBase Piece { get; set; }
		public int CombinationLength { get; set; }
		public List<string> AllCombinations { get; set; }

		public ChessInteractor(ChessBoardBase board, ChessPieceBase piece, int combinationLength, ITelephoneNumberCalculator telephoneNumberCalculator, IValidator numberValidator)
		{
			Board = board;
			Piece = piece;
			CombinationLength = combinationLength;
			TelephoneNumberCalculator = telephoneNumberCalculator;			
			NumberValidator = numberValidator;

			AllCombinations = new List<string>();
		}

		public void CalculateAllCombinations()
		{
			AllCombinations = TelephoneNumberCalculator.GetAllCombinations(Board, Piece, CombinationLength);
			AllCombinations = NumberValidator.ApplyRulesOnCombinations(AllCombinations);
		}

		public string GetSearchResultsForAPattern(string searchText)
		{
			var searchResults = AllCombinations.Where(x => x.StartsWith(searchText));
			if (searchResults.Count() == 0)
				return "No Phone number found with the search text!";
			else
				return $"{searchResults.Count()} Matching phone numbers with the search text = \"{searchText}\" found:\n" + string.Join(", ", searchResults);

		}
	}
}
