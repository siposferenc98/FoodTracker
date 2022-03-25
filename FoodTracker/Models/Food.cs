using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.Models
{
    internal class Food
    {
        public string Name { get; init; }

        public Food(string name)
        {
            Name = name;
        }
    }
}
