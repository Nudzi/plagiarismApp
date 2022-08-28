﻿using plagiarism.Mobile.Services;
using plagiarismModel;
using plagiarismModel.Requests.UserImages;
using plagiarismModel.Requests.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly APIService _usersService = new APIService("users");
        private readonly APIService _userImagesService = new APIService("userImages");

        public ProfileViewModel()
        {
        }
        public Users _user = new Users();
        public byte[] byteImage { get; set; }
        public Users User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        byte[] _image;
        public byte[] Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        string _username = string.Empty;

        string _firstname = string.Empty;
        public string FirstName
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }
        string _lastname = string.Empty;
        public string LastName
        {
            get { return _lastname; }
            set { SetProperty(ref _lastname, value); }
        }
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        string _passwordConf = string.Empty;
        public string PasswordConf
        {
            get { return _passwordConf; }
            set { SetProperty(ref _passwordConf, value); }
        }

        Boolean _isVisiblePic = true;
        public Boolean VisiblePic
        {
            get { return _isVisiblePic; }
            set { SetProperty(ref _isVisiblePic, value); }
        }

        public async Task Init()
        {
            try
            {
                User = Global.LoggedUser;
                var user = await _usersService.GetById<Users>(User.Id);
                UserImagesSearchRequest request = new UserImagesSearchRequest
                {
                    UserId = user.Id
                };
                var image = await _userImagesService.Get<List<UserImages>>(request);
                Image = image[0].Image;
                VisiblePic = Image.Length != 0;
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error", "OK");
            }
        }
        public async Task SaveUserProfil(Image resultImage)
        {
            try
            {
                var gettedUser = Global.LoggedUser;

                var userInts = new List<int>();
                if (gettedUser.UserTypes == null)
                {
                    userInts.Add((int)plagiarismModel.Enums.UserTypes.User);
                }
                else
                {
                    foreach (var item in gettedUser.UserTypes)
                        userInts.Add(item.UserTypeId);
                }
                UsersInsertRequest request = new UsersInsertRequest();
                request.Id = gettedUser.Id;
                request.Email = gettedUser.Email;
                request.Status = true;
                request.FirstName = gettedUser.FirstName;
                request.LastName = gettedUser.LastName;
                request.Password = Password;
                request.PasswordConfirmation = PasswordConf;
                request.Telephone = gettedUser.Telephone;
                request.UserName = gettedUser.UserName;
                request.UserTypes = userInts;


                if (request != null)
                {
                    if(!User.FirstName.Equals(""))
                        request.FirstName = User.FirstName;

                    if (!User.LastName.Equals(""))
                        request.LastName = User.LastName;

                    if (!User.Telephone.Equals(""))
                        request.Telephone = User.Telephone;

                    request.UserAddressId = Global.LoggedUser.UserAddressId;
                    await _usersService.Update<Users>(request.Id, request);
                    var glob = await _usersService.GetById<Users>(request.Id);
                    Global.LoggedUser = glob;

                    if (resultImage.Source != null)
                    {
                        UserImagesSearchRequest imagesSearchRequest = new UserImagesSearchRequest
                        {
                            UserId = gettedUser.Id
                        };
                        var image = await _userImagesService.Get<List<UserImages>>(imagesSearchRequest);
                        UserImagesUpsertRequest userImagesUpsertRequest = new UserImagesUpsertRequest
                        {
                            Id = image[0].Id,
                            Image = byteImage,
                            ImageThumb = byteImage,
                            UserId = gettedUser.Id
                        };
                        await _userImagesService.Update<UserImages>(image[0].Id ,userImagesUpsertRequest);
                    }
                    await Application.Current.MainPage.DisplayAlert("Success", "Successfuly edited! ", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Cannot save right now, try later!", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}