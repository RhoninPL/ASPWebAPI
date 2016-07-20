using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASPWebAPI.Models;
using ASPWebAPI.Services;

namespace ASPWebAPI.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository _repository;
        public ContactController()
        {
            _repository = new ContactRepository();
        }

        public IEnumerable<Contact> Get()
        {
            return _repository.GetAllContact();
        }

        public HttpResponseMessage Post(Contact contact)
        {
            this._repository.SaveContact(contact);
            var response = Request.CreateResponse<Contact>(System.Net.HttpStatusCode.Created, contact);
            return response;
        }


    }
}
