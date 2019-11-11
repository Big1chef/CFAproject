using CFA.API.DTO;
using CFA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CFA.API.Controllers
{
    [RoutePrefix("api/score")]
    public class ScoreController : ApiController
    {
        private readonly IScoreService _scoreService;
        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Score([FromBody]InputDTO inputDTO)
        {
            int score = 0;
            int level = 0;
            int res = _scoreService.Add(inputDTO.input, score, level);
            if (res != -1)
            {
                return Ok(res);
            }
            else {
                return BadRequest("invalid input");
            }
        }
    }
}
