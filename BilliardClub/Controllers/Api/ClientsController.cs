using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using BilliardClub.Models;

namespace BilliardClub.Controllers.Api
{
    public class ClientsController : ApiController
    {
        private ApplicationDbContext _context;

        public ClientsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        //GET /api/customer/1
        public Client GetClient(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.ClientId == id);

            if (client == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return client;
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateClient(Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Clients.Add(client);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + client.ClientId), client);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateClient(int id, Client client)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var clientInDb = _context.Clients.SingleOrDefault(c => c.ClientId == id);

            if (clientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            clientInDb.Name = client.Name;
            clientInDb.Birthdate = client.Birthdate;
        }

        //DELETE /api/clients/1
        [HttpDelete]
        public void DeleteClient(int id)
        {
            var clientInDb = _context.Clients.SingleOrDefault(c => c.ClientId == id);

            if (clientInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Clients.Remove(clientInDb);
            _context.SaveChanges();

        }
    }
}
