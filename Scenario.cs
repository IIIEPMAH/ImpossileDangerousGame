using System.Collections.Generic;

namespace ImpossileDangerousGame
{
    public class HistoryItem {
		public string Id { get; }
		public int Num { get; }

		public HistoryItem(string id, int num) 
		{
			Id = id;
			Num = num;
		}
	}

	public class Var
	{
		public string Text { get; }
		public List<string> Next { get; }

		public Var(string text, List<string> next)
		{
			Text = text;
			Next = next;        
		}
	}

	public class ScenarioStep
	{
		public List<HistoryItem> Prev { get; }
		public string Id { get; }
		public string Text { get; }
		public List<Var> Vars { get; }

		public ScenarioStep(List<HistoryItem> prev, string id, string text, List<Var> vars)
		{
			Prev = prev;
			Id = id;
			Text = text;
			Vars = vars;
		}
	}

	public class Scenario
	{
		public List<ScenarioStep> Steps { get; }

		public Scenario (List<ScenarioStep> steps)
		{
			Steps = steps;          
		}

		public ScenarioStep FindStep(string id) {
			return Steps.Find (step => step.Id == id);
		}
	}
}

