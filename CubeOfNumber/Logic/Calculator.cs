using System;

namespace Logic
{
    public class Calculator
    {
        public Action ErrorAction { get; set; } //gets location of func error
        public Action<string> ResulatAction { get; set; } //gets location of func printresult
        public Action ExitAction { get; set; }
        public Action PrintCubedAction { get; set; }

        public void GetCubeOfNumber(string num)
        {
            if (num.Equals("EXIT") || num.Equals("exit"))
            {
                ExitAction?.Invoke();
                return;
            }

            if (int.TryParse(num, out int res))
            {
                res = res * res * res;
                ResulatAction?.Invoke(res.ToString());
            } else
                ErrorAction?.Invoke(); //calls location

            PrintCubedAction?.Invoke();
        }
    }
}
