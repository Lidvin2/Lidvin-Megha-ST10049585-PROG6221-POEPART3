using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POEPART3
{
    internal class Recipes
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string FoodGroup { get; set; }
        public int Calories { get; set; }
    }
}
