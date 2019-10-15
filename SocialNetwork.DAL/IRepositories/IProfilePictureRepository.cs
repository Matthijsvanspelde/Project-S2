using SocialNetwork.Models;

namespace SocialNetwork.DAL.IRepositories
{
    public interface IProfilePictureRepository
    {
        void UploadPicture(ProfilePicture profilePicture, User user);
    }
}
