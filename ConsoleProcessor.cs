using System;

namespace ImpossileDangerousGame
{
	public class ConsoleProcessor
	{
		public static int ProcessStep(ScenarioStep step) 
		{
			Console.WriteLine (step.Text);

			for (int i = 1; i <= step.Vars.Count; i++) {
				Console.Write (i);
				Console.Write (". ");
				Console.WriteLine (step.Vars[i - 1].Text);
			}

			string ans = "";
			int res;
			while (true) {
				ans = Console.ReadLine ();
				bool tryRes = Int32.TryParse (ans, out res);
				if (tryRes) {
					if (res > 0 && res <= step.Vars.Count) {
						break;
					}
				}
				Console.WriteLine ("Попробуйте наконец-то попасть по нужной кнопке!!! Этож, блин, слоооожно!!!!!");
			}

			return res - 1;
		}
	}
}

