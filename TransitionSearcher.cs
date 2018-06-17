using System;
using System.Collections.Generic;
using System.Collections;

namespace ImpossileDangerousGame
{
	public class TransitionSearcher
	{
		public static string Search(List<Tuple<string, int>> history, Scenario scenario) {
			foreach (ScenarioTransition transaction in scenario.Transitions) {
				if (!history.Exists(h => h.Item1 == transaction.Dest) && transaction.Src.TrueForAll (src => history.Contains (src))) {
					return transaction.Dest;
				}
			}

			return "<none>";
		}
	}
}

