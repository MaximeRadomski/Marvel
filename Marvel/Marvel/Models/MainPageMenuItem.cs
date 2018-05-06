using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel.Views
{

    public class MainPageMenuItem
    {
        public MainPageMenuItem()
        {
        }
        public string ImagePath { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}