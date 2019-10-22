using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;

namespace SocialNetwork.Logic
{
    public class ProfilePictureLogic : IProfilePictureLogic
    {
        private readonly IProfilePictureRepository _profilePictureRepository;

        public ProfilePictureLogic(IProfilePictureRepository profilePictureRepository)
        {
            _profilePictureRepository = profilePictureRepository;
        }

        public void UploadPicture(ProfilePicture profilePicture, User user)
        {
            _profilePictureRepository.UploadPicture(profilePicture, user);
        }

        public ProfilePicture GetProfilePicture(User user)
        {
            return _profilePictureRepository.GetProfilePicture(user);
        }
    }
}
