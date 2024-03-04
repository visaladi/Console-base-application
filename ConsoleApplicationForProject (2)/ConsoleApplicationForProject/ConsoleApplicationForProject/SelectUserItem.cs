using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationForProject
{
    public class SelectUserItem
    {
        public string Option { get; set; }
        public bool Selection { get; set; }

        public SelectUserItem(string option, bool selection)
        {
            this.Option = option;
            this.Selection = selection;

        }
    }
}
