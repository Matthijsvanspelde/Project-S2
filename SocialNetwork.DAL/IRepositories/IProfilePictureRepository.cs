using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IRepositories
{
    public interface IProfilePictureRepository
    {
        void UploadPicture(ProfilePicture profilePicture, User user);
        ProfilePicture GetProfilePicture(User user);
    }
}
