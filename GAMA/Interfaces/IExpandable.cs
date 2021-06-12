using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMA.Interfaces
{
    interface IExpandable
    {
        bool IsExpanded { get; set; }

        void Expand();
        void Collapse();
        void ToggleExpandState();
    
        event EventHandler Collapsed;
        event EventHandler Expanded;
    }
}
