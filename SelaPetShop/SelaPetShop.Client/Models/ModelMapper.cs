using SelaPetShop.Data.Models;

namespace SelaPetShop.Client.Models
{
    public class ModelMapper
    {
        public static UserViewModel MapToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Username = user.Username,
                Password = user.Password
            };
        }
    }
}
