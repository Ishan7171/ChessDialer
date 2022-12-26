using System.Collections.Generic;

namespace ChessDialer.Interfaces
{
	public interface IValidator
	{
		List<string> ApplyRulesOnCombinations(List<string> combinations);
	}
}
