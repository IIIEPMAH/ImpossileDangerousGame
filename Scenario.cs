using System;
using System.Collections.Generic;

namespace ImpossileDangerousGame
{
	public class ScenarioStep 
	{
		public string Id { get; }
		public string Text { get; }
		public List<string> Variences { get; }

		public ScenarioStep(string text, List<string> variences, string id) 
		{
			Text = text; 	
			Variences = variences;
			Id = id;
		}
	}

	public class ScenarioTransition 
	{
		public List<Tuple<string, int>> Src { get; }
		public string Dest { get; }

		public ScenarioTransition(List<Tuple<string, int>> src, string dest)
		{
			Src = src;
			Dest = dest;
		}
	}

	public class Scenario
	{
		public List<ScenarioStep> Steps { get; }
		public List<ScenarioTransition> Transitions { get; }

		public Scenario (List<ScenarioStep> steps, List<ScenarioTransition> transitions)
		{
			Steps = steps;
			Transitions = transitions;

			transitions.Sort (Comparer<ScenarioTransition>.Create ((ScenarioTransition t1, ScenarioTransition t2) => {
				if (t1.Src.Count > t2.Src.Count) {
					return -1;
				} else if (t1.Src.Count == t2.Src.Count) {
					return 0;
				} else {
					return 1;
				}
			}));
		}

		public ScenarioStep findStep(string id) {
			return Steps.Find (step => step.Id == id);
		}
	}
}

