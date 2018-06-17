using System;
using System.Collections.Generic;

namespace ImpossileDangerousGame
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Scenario scenario = ScenarioFilesParser.ParseScenario ("idg.steps", "idg.trs");
			List<Tuple<string, int>> history = new List<Tuple<string, int>> ();
			while (true) {
				string nextId = TransitionSearcher.Search (history, scenario);
				if (nextId == "<none>") {
					break;
				}
				ScenarioStep nextStep = scenario.findStep (nextId);
				if (nextStep == null){
					Console.Write ("ID ");
					Console.Write (nextId);
					Console.Write (" NOT FOUND");
				}
				int variance = ConsoleProcessor.ProcessStep (nextStep);
				history.Add (Tuple.Create (nextId, variance));
			}
		}
	}
}
