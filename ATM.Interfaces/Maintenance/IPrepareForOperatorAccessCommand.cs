using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Interfaces.Maintenance
{
    public interface IPrepareForOperatorAccessCommand
    {
        void Do();

        void Undo();
    }
}
