using DUTAdmissionSystem.App_Resources.Constants;
using DUTAdmissionSystem.Areas.StudentArea.Services.Components;
using DUTAdmissionSystem.Areas.StudentArea.Services.ModelDTOs;
using DUTAdmissionSystem.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.StudentArea.Controllers
{
    public class AchievementController : ApiController
    {
        private readonly IAchievementService _achievementService;
        public AchievementController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }
        [HttpGet]
        [ActionName("GetAchievements")]
        public IHttpActionResult GetAchievements()
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                var result = _achievementService.GetAchievements(idUser);
                if (result == null)
                    return BadRequest(AppMessage.BadRequestNotFound);
                return Ok(result);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpPost]
        [ActionName("AddAchievement")]
        // [Authorize]
        public IHttpActionResult AddAchievement([FromBody]Achievement Achievement)
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(_achievementService.AddAchievement(Achievement, idUser));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpPut]
        [ActionName("UpdateAchievement")]
        public IHttpActionResult UpdateAchievement([FromBody]Achievement Achievement)
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _achievementService.UpdateAchievement(Achievement, idUser);
                return Ok(_achievementService.UpdateAchievement(Achievement, idUser));
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
        [HttpDelete]
        [ActionName("DeleteAchievement")]
        public IHttpActionResult DeleteAchievement(int id)
        {
            try
            {
                int idUser = FunctionCommon.GetIdUserByToken(Request.GetAuthorizationHeader());
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                _achievementService.DeleteAchievement(idUser, id);
                return Ok();
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
