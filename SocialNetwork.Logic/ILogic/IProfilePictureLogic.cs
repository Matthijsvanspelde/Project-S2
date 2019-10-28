using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic.ILogic
{
    public interface IProfilePictureLogic
    {
        void UploadPicture(ProfilePicture profilePicture, User user);
        ProfilePicture GetProfilePicture(User user);
    }
}
