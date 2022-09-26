using System.Collections.Generic;

namespace SEDC.Lamazon.Domain.Enitities
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string Key { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
