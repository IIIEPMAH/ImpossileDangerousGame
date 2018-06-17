using System;

namespace ImpossileDangerousGame
{
	public class ConsoleProcessor
	{
		public static int ProcessStep(ScenarioStep step) 
		{
			Console.WriteLine (step.Text);

			for (int i = 1; i <= step.Variences.Count; i++) {
				Console.Write (i);
				Console.Write (". ");
				Console.WriteLine (step.Variences[i - 1]);
			}

			string ans = "";
			int res;
			while (true) {
				ans = Console.ReadLine ();
				bool tryRes = Int32.TryParse (ans, out res);
				if (tryRes) {
					if (res > 0 && res <= step.Variences.Count) {
						break;
					}
				}
				Console.WriteLine ("Попробуйте наконец-то попасть по нужной кнопке!!! Этож, блин, слоооожно!!!!!");
			};

				
			return res;
		}
	}
}

