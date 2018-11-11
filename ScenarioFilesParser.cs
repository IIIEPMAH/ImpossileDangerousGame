using System.IO;
using System.Json;
using System.Linq;
using System.Collections.Generic;

namespace ImpossileDangerousGame
{
    public class ScenarioFilesParser
    {      
        private static HistoryItem parseItem(JsonObject obj)
        {
            JsonValue id;
            JsonValue num;
            obj.TryGetValue("id", out id);
            obj.TryGetValue("num", out num);
            return new HistoryItem((string)id, (int)num);
        }
        
        private static Var parseVar(JsonObject obj)
        {
            JsonValue text;
            JsonValue next;
            obj.TryGetValue("text", out text);
            obj.TryGetValue("next", out next);
            List<string> nextList = ((JsonArray)next).Select(s => (string)s).ToList();           
            return new Var((string)text, nextList);
        }

        private static ScenarioStep parseStep(JsonObject obj)
        {
            JsonValue prev;
            JsonValue id;
            JsonValue text;
            JsonValue vars;
            obj.TryGetValue("prev", out prev);
            obj.TryGetValue("id", out id);
            obj.TryGetValue("text", out text);
            obj.TryGetValue("vars", out vars);
            List<HistoryItem> prevList;
            if (prev != null) {
                prevList = ((JsonArray)prev).Select(o => parseItem((JsonObject)o)).ToList();
            }
            else {
                prevList = new List<HistoryItem>();
            }
            List<Var> varList = ((JsonArray)vars).Select(v => parseVar((JsonObject)v)).ToList();
            return new ScenarioStep(prevList, (string)id, (string)text, varList);
        }
        
        public static Scenario ParseScenario(string stepsFile) 
        {
            JsonValue steps = JsonValue.Parse(File.ReadAllText(stepsFile));
            List<ScenarioStep> stepsList = ((JsonArray)steps).Select(s => parseStep((JsonObject)s)).ToList();
            return new Scenario(stepsList);
        }
    }
}

