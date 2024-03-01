using System;
using System.Collections.Generic;

namespace AAE2023_Music_Player
{
    [Serializable]
    public class User 
    {
        // this class is used to objectify the users of the application
        private List<Track> _favorites = new List<Track>();
        private string _username;
        private int _userID;
        public List<Track> Favorites
        {
            get => _favorites;
            set => _favorites = value;
        }
        public string Username
        {
            get => _username;
        }
        public int UserID
        {
            get => _userID;
        }
        // constructor
        public User(string username,int id)
        {
            _username = username;
            _userID = id;
        }
    }
}
