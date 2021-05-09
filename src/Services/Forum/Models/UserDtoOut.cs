﻿namespace CountyRP.Services.Forum.Models
{
    public class UserDtoOut
    {
        public int Id { get; }
        public string Login { get; }
        public string GroupId { get; }
        public int Reputation { get; }
        public int Posts { get; }
        public int Warnings { get; }

        public UserDtoOut(
            int id,
            string login,
            string groupId,
            int reputation,
            int posts,
            int warnings)
        {
            Id = id;
            Login = login;
            GroupId = groupId;
            Reputation = reputation;
            Posts = posts;
            Warnings = warnings;
        }
    }
}
