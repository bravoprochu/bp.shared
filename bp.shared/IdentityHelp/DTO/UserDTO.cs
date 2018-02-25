using bp.shared.DTO;
using System.Collections.Generic;

namespace bp.shared.IdentityHelp.DTO
{
    public class UserDTO:StatusDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<RoleDTO> Roles { get; set; }
    }
}
