using System;
using System.Collections.Generic;
using System.IO;

namespace ImpossileDangerousGame
{
	public class ScenarioFilesParser
	{
		public static List<ScenarioStep> ParseSteps(string filename) {
			List<ScenarioStep> steps = new List<ScenarioStep> ();
			using (StreamReader reader = new StreamReader (filename)) {
				while (!reader.EndOfStream) {
					string id = reader.ReadLine ();

					int textNum = Convert.ToInt32 (reader.ReadLine (), 10);
					string text = "";
					for (int i = 0; i < textNum; i++) {
						text += reader.ReadLine ();
						text += "\n";
					}

					int varNum = Convert.ToInt32 (reader.ReadLine (), 10);
					List<string> vars = new List<string> ();
					for (int i = 0; i < varNum; i++) {
						vars.Add (reader.ReadLine ());
					}

					steps.Add (new ScenarioStep (text, vars, id));
				}
			}

			return steps;
		}

		public static List<ScenarioTransition> ParseTransitions(string filename) {
			List<ScenarioTransition> vars = new List<ScenarioTransition> ();
			using (StreamReader reader = new StreamReader (filename)) {
				while (!reader.EndOfStream) {
					string line = reader.ReadLine ();
					string[] parts = line.Split (',');
					if (parts.Length % 2 != 1) {
						throw new FormatException ();
					}
					List<Tuple<string, int>> pairs = new List<Tuple<string, int>>(); 
					for (int i = 0; i < parts.Length / 2; i++) {
						string id = parts [2 * i];
						int v = Convert.ToInt32 (parts [2 * i + 1], 10);
						pairs.Add (Tuple.Create (id, v));
					}

					vars.Add (new ScenarioTransition (pairs, parts [parts.Length - 1]));
				}
			}

			return vars;
		}

		public static Scenario ParseScenario(string stepsFile, string transitionsFile) {
			return new Scenario (ParseSteps (stepsFile), ParseTransitions (transitionsFile));
		}
	}
}

