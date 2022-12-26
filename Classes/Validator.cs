using ChessDialer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ChessDialer.Classes
{
	public class Validator : IValidator
	{
		public List<string> ApplyRulesOnCombinations(List<string> combinations)
		{
			combinations = FilterOutCombinationsBasedOnStartingCharacters(new char[] { '0', '1', '*', '#' }, combinations);
			combinations = FilterOutCombinationsContainingRestrictedCharacters(new char[] { '*', '#' }, combinations);
			return combinations;
		}
		List<string> FilterOutCombinationsBasedOnStartingCharacters(char[] restrictedStartingChars, List<string> combinations)
		{
			foreach (char ch in restrictedStartingChars)
			{
				combinations = combinations.Where(x => !x.StartsWith(ch.ToString())).ToList();
			}
			return combinations;
		}
		List<string> FilterOutCombinationsContainingRestrictedCharacters(char[] restrictedChars, List<string> combinations)
		{
			foreach (char ch in restrictedChars)
			{
				combinations = combinations.Where(x => !x.Contains(ch.ToString())).ToList();
			}
			return combinations;
		}
	}
}
