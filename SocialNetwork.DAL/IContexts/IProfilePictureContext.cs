using SocialNetwork.Models;

namespace SocialNetwork.DAL.IContexts
{
    public interface IProfilePictureContext
    {
        void UploadPicture(ProfilePicture profilePicture, User user);
        ProfilePicture GetProfilePicture(User user);
    }
}
