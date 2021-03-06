﻿using System;
using System.Collections.Generic;
using System.Text;
using Weather.App.Infrastructure.Repositories;

namespace Weather.App.Domain.Aggregates
{
    public class User : IRootAggregate
    {
        private IRepository _repo; 

        private string _emailAddress;
        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                if (IsValidEmailAddress(value))
                {
                    _emailAddress = value;
                }
                else
                {
                    throw new ArgumentException("Email address is invalid", nameof(value));
                } 
            }
        }

        public IList<string> Locations { get; private set; }

        public User()
        {
            _repo = new MongoRepository();
        }

        public User AddWeatherLocation(string location)
        {
            if (Locations == null)
            {
                Locations = new List<string>();
            }

            Locations.Add(location);

            return this;
        }

        public User Save()
        {
            var output = _repo.CreateAsync(this).Result;
            return this;
        }

        private bool IsValidEmailAddress(string email)
        {
            try
            { 
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        
        public static class Factory
        {
            public static User CreateNew()
            { 
                return new User();
            }
        }
    }
}
