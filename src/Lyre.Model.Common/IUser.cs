using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyre.Model.Common
{
    public enum UserRole : byte
    {
        USER = 0,
        EDITOR,
        ADMIN
    }
    public interface IUser
    {
        Guid UserID { get; set; }
        string Username { get; set; }
        string Hash { get; set; }
        string Salt { get; set; }
        
        UserRole Role { get; set; }
        DateTime? CreationTime { get; set; }

    }
}
