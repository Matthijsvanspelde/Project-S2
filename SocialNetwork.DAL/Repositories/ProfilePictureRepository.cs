using SocialNetwork.DAL.IContexts;
using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    public class ProfilePictureRepository : IProfilePictureRepository
    {
        private readonly IProfilePictureContext _profilePictureContext;

        public ProfilePictureRepository(IProfilePictureContext profilePictureContext)
        {
            _profilePictureContext = profilePictureContext;
        }

        public void UploadPicture(ProfilePicture profilePicture, User user)
        {
            _profilePictureContext.UploadPicture(profilePicture, user);
        }

        public ProfilePicture GetProfilePicture(User user)
        {
            return _profilePictureContext.GetProfilePicture(user);
        }

    }
}
