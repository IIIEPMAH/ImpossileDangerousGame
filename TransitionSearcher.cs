using System;
using System.Collections.Generic;
using System.Collections;

namespace ImpossileDangerousGame
{
	public class TransitionSearcher
	{
		public static string Search(List<Tuple<ScenarioStep, int>> history, Scenario scenario) {
			if (history.Count == 0) {
				return scenario.Steps[0].Id;
			}
			var lastStep = history[history.Count - 1].Item1;
			var lastVar = history[history.Count - 1].Item2;
			var nexts = lastStep.Vars[lastVar].Next;
            
			foreach (var next in nexts) {
				ScenarioStep step = scenario.FindStep(next);
				bool allExists = true;
				foreach (HistoryItem prev in step.Prev) {
					if (!history.Exists((Tuple<ScenarioStep, int> item) => item.Item1.Id == prev.Id && item.Item2 == prev.Num)) {
						allExists = false;
						break;
					}
				}

				if (allExists) {
					return next;
				}
			}

			return "<none>";
		}
	}
}

