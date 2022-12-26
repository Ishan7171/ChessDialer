using ChessDialer.Classes;
using ChessDialer.Interfaces;
using ChessDialer.Models;
using ChessDialer.Models.Board;
using ChessDialer.Models.ChessPieces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ChessDialer
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Introduction();
			while (true)
			{
				var chessPieceSelection = GetChessPieceInputFromUser();
				var combinationLength = GetCombinationLengthFromUser();

				var phoneNumberCalculator = new TelephoneNumberCalculator();
				var numberValidator = new Validator();
				
				// We can take board inputs at run time from the user but for the sake of ease, we prepopulate it
				// The idea is either to create a board too dynamically or easily extend the ChessBoardBase to create more prepopulated boards
				var chessBoard = new ChessBoardNumericKeypad(4, 3);

				var interactor = new ChessInteractor(chessBoard, chessPieceSelection, combinationLength, phoneNumberCalculator, numberValidator);
				interactor.CalculateAllCombinations();
				Console.WriteLine($"\nTotal combinations for {chessPieceSelection.GetType().Name} with length = {combinationLength}: {interactor.AllCombinations.Count}");

				if (interactor.AllCombinations.Count > 0)
				{
					while (true)
					{
						Console.WriteLine("Do you want to search for a telephone pattern? (Type N to skip)");
						string searchInput;
						searchInput = Console.ReadLine().Trim();
						if (searchInput == "n" || searchInput == "N")
							break;
						
						var searchText = GetSearchTextFromUser(combinationLength);
						Console.WriteLine(interactor.GetSearchResultsForAPattern(searchText));
						Console.WriteLine("\n");
					}
				}

				Console.WriteLine("Continue to check another chess piece combinationns? (Type N to exit)");

				string input;
				input = Console.ReadLine().Trim();
				if (input == "n" || input == "N")
					break;

				Console.WriteLine("\n");
			}
		}
		static void Introduction()
		{
			Console.WriteLine("***************************************");
			Console.WriteLine("Welcome to Chess Dialer!");
			Console.WriteLine("***************************************\n");
			Console.WriteLine("Let's begin with chess piece selection:");			
		}

		static ChessPieceBase GetChessPieceInputFromUser()
		{
			Dictionary<int, ChessPieceBase> chessPieceMapping = new Dictionary<int, ChessPieceBase>()
			{
				{ 1, new King()},
				{ 2, new Queen()},
				{ 3, new Bishop()},
				{ 4, new Knight()},
				{ 5, new Rook()},
				{ 6, new Pawn()},

			};
			Console.WriteLine("Please enter the corresponding number from the below options:");
			foreach(var kv in chessPieceMapping)
			{
				Console.WriteLine($"{kv.Key} - {kv.Value.GetType().Name}");
			}
			int chessPieceValue = 0;
			
			while (chessPieceValue < 1 || chessPieceValue > 6)
			{
				Console.WriteLine("Enter: ");
				string input;
				input = Console.ReadLine();
				if (int.TryParse(input, out chessPieceValue))
					if (chessPieceValue >= 1 && chessPieceValue <= 6)
					{
						return chessPieceMapping[chessPieceValue];						
					}
					else
						Console.WriteLine("Invalid! Please try again..\n");
			}

			return new Rook();
		}

		static int GetCombinationLengthFromUser()
		{
			Console.WriteLine("\nPlease enter the length (between 1 & 10) of phone numbers you want to check: ");
			int combinationLength = -1;
			while (combinationLength < 1 || combinationLength > 10)
			{
				string input;
				input = Console.ReadLine();
				if (int.TryParse(input, out combinationLength))
					if (combinationLength >= 1 && combinationLength <= 10)
						break;
					else
						Console.WriteLine("Invalid input!! Please enter valid length between 1 & 10..");
			}

			return combinationLength;
		}

		static string GetSearchTextFromUser(int combinationLength)
		{
			Console.WriteLine("\nPlease enter a number pattern to print all combinations starting with that pattern: ");
			string input = "";

			while (input == String.Empty || input.Length > combinationLength || !Regex.IsMatch(input, @"^\d+$"))
			{
				input = Console.ReadLine();
				if (input.Length > combinationLength)
					Console.WriteLine($"Invalid input!! Search text can't be greater than combination length, please try again..");
			}

			return input;
		}

	}
}
