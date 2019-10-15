using SocialNetwork.Models;

namespace SocialNetwork.Logic.ILogic
{
    public interface IProfilePictureLogic
    {
        void UploadPicture(ProfilePicture profilePicture, User user);
    }
}
