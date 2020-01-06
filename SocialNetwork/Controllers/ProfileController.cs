using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using SocialNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SocialNetwork.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserLogic _userLogic;
        private readonly IPostLogic _postLogic;
        private readonly IFriendRequestLogic _friendRequestLogic;
        private readonly IProfilePictureLogic _profilePictureLogic;

        public ProfileController(IUserLogic userLogic, IPostLogic postLogic, IFriendRequestLogic friendRequestLogic, IProfilePictureLogic profilePictureLogic)
        {
            _userLogic = userLogic;
            _postLogic = postLogic;
            _friendRequestLogic = friendRequestLogic;
            _profilePictureLogic = profilePictureLogic;
        }

        public IActionResult Overview(User user)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                user.Id = (int)HttpContext.Session.GetInt32("Id");
                _userLogic.GetUserDetails(user);
                ProfilePicture profilePicture = _profilePictureLogic.GetProfilePicture(user);               
                ProfileViewModel profileViewModel = new ProfileViewModel()
                {
                    Id = user.Id,
                    Firstname = user.Firstname,
                    Middlename = user.Middlename,
                    Lastname = user.Lastname,
                    Birthdate = user.Birthdate,
                    Country = user.Country,
                    City = user.City,
                    Biography = user.Biography,
                    Img = profilePicture.Image,
                };
                profileViewModel.Posts = new List<Post>();
                profileViewModel.Posts.AddRange(_postLogic.GetPost(user));
                profileViewModel.Followers = new List<User>();
                profileViewModel.Followers.AddRange(_userLogic.GetFollowers(user));
                profileViewModel.Following = new List<User>();
                profileViewModel.Following.AddRange(_userLogic.GetFollowing(user));
                return View(profileViewModel);
            }
        }

        public IActionResult Edit(User user)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                user.Id = (int)HttpContext.Session.GetInt32("Id");
                _userLogic.GetUserDetails(user);
                ProfileViewModel profileViewModel = new ProfileViewModel()
                {
                    Firstname = user.Firstname,
                    Middlename = user.Middlename,
                    Lastname = user.Lastname,
                    Birthdate = user.Birthdate,
                    Country = user.Country,
                    City = user.City,
                    Biography = user.Biography
                };
                return View(profileViewModel);
            }
        }

        public IActionResult Post()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }

        public IActionResult PageNotFound()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }

        public IActionResult EditProfile(User user)
        {

            if (user.Middlename == null)
            {
                user.Middlename = "";
            }
            user.Id = (int)HttpContext.Session.GetInt32("Id");
            _userLogic.EditProfileDetails(user);
            return RedirectToAction("Overview", "Profile");
        }
       
        public IActionResult SearchedProfile(int Id)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                FriendRequest friendRequest = new FriendRequest();
                friendRequest.RecieverId = Id;
                friendRequest.SenderId = (int)HttpContext.Session.GetInt32("Id");
                User user = new User();
                user.Id = Id;
                if (_userLogic.DoesProfileExist(Id) == true)
                {
                    _userLogic.GetUserDetails(user);
                    ProfilePicture profilePicture = _profilePictureLogic.GetProfilePicture(user);
                    ProfileViewModel profileViewModel = new ProfileViewModel()
                    {
                        Id = user.Id,
                        Firstname = user.Firstname,
                        Middlename = user.Middlename,
                        Lastname = user.Lastname,
                        Birthdate = user.Birthdate,
                        Country = user.Country,
                        City = user.City,
                        Biography = user.Biography,
                        Img = profilePicture.Image,
                    };
                    profileViewModel.Requested = _friendRequestLogic.DoesFriendRequestExist(friendRequest);
                    profileViewModel.IsFollowing = _friendRequestLogic.IsFollowing(friendRequest);
                    profileViewModel.Posts = new List<Post>();
                    profileViewModel.Posts.AddRange(_postLogic.GetPost(user));
                    profileViewModel.Followers = new List<User>();
                    profileViewModel.Followers.AddRange(_userLogic.GetFollowers(user));
                    profileViewModel.Following = new List<User>();
                    profileViewModel.Following.AddRange(_userLogic.GetFollowing(user));
                    return View("Overview", profileViewModel);
                }
                else
                {
                    return View("PageNotFound", "Profile");
                }                
            }
        }

        public async Task<IActionResult> UploadPicture(IFormFile image)
        {
            ProfilePicture profilePicture = new ProfilePicture();
            User user = new User();
            user.Id = (int)HttpContext.Session.GetInt32("Id");
            if (image != null && image.Length > 0)
            {
                if (image.ContentType == "image/png" || image.ContentType == "image/jpeg" || image.ContentType == "image/gif")
                {
                    using (var stream = new MemoryStream())
                    {
                        await image.CopyToAsync(stream);
                        profilePicture.Image = stream.ToArray();
                    }
                    profilePicture.FileType = image.ContentType;
                    _profilePictureLogic.UploadPicture(profilePicture, user);
                    return RedirectToAction("Overview", "Profile");
                }                
            }            
            return RedirectToAction("Edit", "Profile");            
        }

        public async Task<IActionResult> SetPost (Post post, User user, IFormFile image)
        {
            user.Id = (int)HttpContext.Session.GetInt32("Id");
            post.Posted = DateTime.Now;            
            if (image != null && image.Length > 0)
            {
                if (image.ContentType == "image/png" || image.ContentType == "image/jpeg")
                {
                    using (var stream = new MemoryStream())
                    {
                        await image.CopyToAsync(stream);
                        post.Image = stream.ToArray();
                    }
                    _postLogic.SetPost(post, user);
                    return RedirectToAction("Overview", "Profile");
                }
            }
            return RedirectToAction("Post", "Profile");
        }

        public IActionResult DeletePost(Post post)
        {
            User user = new User();
            user.Id = (int)HttpContext.Session.GetInt32("Id");
            _postLogic.DeletePost(post, user);
            return RedirectToAction("Overview", "Profile");
        }

        public IActionResult SendFriendRequest(FriendRequest friendRequest)
        {
            friendRequest.SenderId = (int)HttpContext.Session.GetInt32("Id");
            friendRequest.Recieved = DateTime.Now;
            if (friendRequest.SenderId != friendRequest.RecieverId)
            {
                if (_friendRequestLogic.DoesFriendRequestExist(friendRequest) == false)
                {
                    if (_friendRequestLogic.IsFollowing(friendRequest) == false)
                    {
                        _friendRequestLogic.SendFriendRequest(friendRequest);
                    }
                }
            }            
            return RedirectToAction("SearchedProfile/" + friendRequest.RecieverId, "Profile");
        }

        public IActionResult LikePost(int PostId, int RecieverId)
        {
            User user = new User();
            user.Id = (int)HttpContext.Session.GetInt32("Id");
            Post post = new Post();
            post.PostId = PostId;
            if (_postLogic.AlreadyLiked(post, user) == false)
            {
                _postLogic.LikePost(post, user);
            }
            return RedirectToAction("SearchedProfile/" + RecieverId, "Profile");
        }
    }
}