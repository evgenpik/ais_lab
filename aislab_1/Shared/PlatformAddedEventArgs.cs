using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    //то же самое, что и GameUpdateEventArgs, но для платформ
    internal class PlatformAddedEventArgs: EventArgs
    {
        public string PlatformName { get; set; }
    }
}
