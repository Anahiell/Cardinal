using CardinalL.Data.Entityes;
using CardinalL.DataService;
using CardinalL.views.ViewModels;
using Microsoft.EntityFrameworkCore;

public class DataServ
{
    private readonly DataContext dataContext;

    public DataServ(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public async Task<UserViewModel> LoadUserProfileDataAsync(int userId)
    {
        var user = await dataContext.Users.SingleOrDefaultAsync(u => u.Id == userId);

        var userViewModel = new UserViewModel
        {
            Name = user.Name,
            Password = user.Password,
            Email = user.Email,
            Phone = user.Phone,
            Login = user.Login,
            AvatarImage = ConvertorImg.ConvertByteArrayToImage(user.AvatarData)
        };

        return userViewModel;
    }

    public async Task<List<FriendViewModel>> LoadFriendsAsync(int userId)
    {
        var user = await dataContext.Users.Include(u => u.Friends).SingleOrDefaultAsync(u => u.Id == userId);

        var friends = await Task.WhenAll(user.Friends.Select(async friend =>
        {
            var friendUser = await dataContext.Users.SingleOrDefaultAsync(u => u.Id == friend.User2Id);

            return new FriendViewModel
            {
                Name = friendUser.Name,
                Status = friend.Status,
                AvatarImage = ConvertorImg.ConvertByteArrayToImage(friendUser.AvatarData)
            };
        }));

        return friends.ToList();
    }

    // Добавьте методы для других моделей представления (например, чаты)
}
