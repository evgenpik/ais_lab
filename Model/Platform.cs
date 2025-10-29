using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public class Platform : IDomainObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
