using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using NamedServices.Microsoft.Extensions.DependencyInjection;

namespace LiteDBExample.Controllers {

    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase {
        private LiteRepository UsersRepo { get; }
        private LiteRepository ClientsRepo { get; }

        public TestController(NamedServiceResolver namedServiceResolver) {
            UsersRepo = namedServiceResolver.GetNamedService<LiteRepository>("users");
            ClientsRepo = namedServiceResolver.GetNamedService<LiteRepository>(LiteDbRepoNames.Clients);
        }

        #region Users

        [HttpGet("users")]
        public ActionResult<IEnumerable<UserDbModel>> GetAllUsers() {
            var users = UsersRepo.Fetch<UserDbModel>();
            return Ok(users);
        }

        [HttpGet("users/{username}")]
        public ActionResult<UserDbModel> GetUser(string username) {
            var user = UsersRepo.SingleOrDefault<UserDbModel>(model => model.Username == username);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("users")]
        public ActionResult PostUser([FromBody]UserDbModel userDbModel) {
            UsersRepo.Insert(userDbModel);
            return NoContent();
        }

        [HttpDelete("users/{username}")]
        public ActionResult DeleteUser(string username) {
            UsersRepo.Delete<UserDbModel>(model => model.Username == username);
            return NoContent();
        }


        #endregion

        #region Clients

        [HttpGet("clients")]
        public ActionResult<IEnumerable<ClientDbModel>> GetAllClients() {
            var users = ClientsRepo.Fetch<ClientDbModel>();
            return Ok(users);
        }

        [HttpGet("clients/{clientname}")]
        public ActionResult<ClientDbModel> GetClient(string clientname) {
            var user = ClientsRepo.SingleOrDefault<ClientDbModel>(model => model.Name == clientname);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("clients")]
        public ActionResult PostClient([FromBody]ClientDbModel userDbModel) {
            ClientsRepo.Insert(userDbModel);
            return NoContent();
        }

        [HttpDelete("clients/{clientname}")]
        public ActionResult DeleteClient(string clientname) {
            ClientsRepo.Delete<UserDbModel>(model => model.Username == clientname);
            return NoContent();
        }


        #endregion
    }
}
