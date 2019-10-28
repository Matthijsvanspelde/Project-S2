using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IContexts
{
    public interface IProfilePictureContext
    {
        void UploadPicture(ProfilePicture profilePicture, User user);
        ProfilePicture GetProfilePicture(User user);
    }
}
