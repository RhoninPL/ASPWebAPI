using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPWebAPI.Models;

namespace ASPWebAPI.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";

        public ContactRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new List<Contact>
                    {
                        new Contact()
                        {
                            Id = 1,
                            Name = "Linkin Park"
                        },
                        new Contact()
                        {
                            Id = 2,
                            Name = "Limp Bizkit"
                        },
                    };

                    ctx.Cache[CacheKey] = contacts;
                }
            }
        }

        public IEnumerable<Contact> GetAllContact()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return ctx.Cache[CacheKey] as IEnumerable<Contact>;
            }

            return new List<Contact>
            {
                new Contact()
                {
                    Id = 0,
                    Name = "Pustka"
                }
            };
        }

        public bool SaveContact(Contact contact)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ctx.Cache[CacheKey] as List<Contact>;
                    currentData.Add(contact);
                    ctx.Cache[CacheKey] = currentData;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }
    }
}