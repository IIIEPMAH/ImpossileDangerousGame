using System;
using System.Collections.Generic;

namespace ImpossileDangerousGame
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Scenario scenario = ScenarioFilesParser.ParseScenario ("test.json");
            List<Tuple<ScenarioStep, int>> history = new List<Tuple<ScenarioStep, int>> ();
            while (true) {
                string nextId = TransitionSearcher.Search (history, scenario);
                if (nextId == "<none>") {
                    break;
                }
                ScenarioStep nextStep = scenario.FindStep (nextId);
                if (nextStep == null) {
                    Console.Write ("ID ");
                    Console.Write (nextId);
                    Console.Write (" NOT FOUND");
                }
                int var = ConsoleProcessor.ProcessStep (nextStep);
                history.Add (Tuple.Create (nextStep, var));
            }
        }
    }
}
