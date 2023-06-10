using Microsoft.AspNetCore.Identity;

namespace HotelProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int> //primary key int
    {
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
