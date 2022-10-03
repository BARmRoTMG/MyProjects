using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class GetCubedNumber
    {
        public Action<string> GetCubedNumberAction { get; set; }
        public Action ErrorAction { get; set; }

        public void GetCubeOfNumber(string input)
        {
            if (int.TryParse(input, out int result))
            {
                result = result * result * result;
                GetCubedNumberAction?.Invoke(result.ToString());

            }
            else
                ErrorAction?.Invoke();
        }
    }
}
