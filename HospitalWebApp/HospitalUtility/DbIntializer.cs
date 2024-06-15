using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalUtility
{
    public class DbIntializer : IDbIntializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManger<IdentityRole> roleManger;
        private ApplicationDbContext _context;

        public void IDbIntialize
        {
            throw new NotImplementedException();
    }



}
}