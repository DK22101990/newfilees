﻿using CFS.BusinessLogic.IBusinessLogic;
using CFS.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CFS.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class AccountController : Controller
    {
        #region Variables

        private readonly IAccountLogic _iAccountLogic;
        private readonly IConfiguration _configuration;
        #endregion Variables

        #region Constructor
        public AccountController(IAccountLogic iAccountLogic, ILoggerFactory factory)
        {
            factory.CreateLogger<AccountController>();
            _iAccountLogic = iAccountLogic;
        }
        #endregion

        #region Actions 

        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns></returns>
        [Route("GetAllAccounts")]
        [HttpGet]
        public async Task<List<AccountListViewModel>> GetAccountList()
        {
            return await _iAccountLogic.GetAccountList();
        }
        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns></returns>
        [Route("GetAllSprints")]
        [HttpGet]
        public async Task<List<SprintViewModel>> GetSprintList(int SowId)
        {
            return await _iAccountLogic.GetSprintList(SowId);
        }
        /// <summary>
        /// Get All Complience Types
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        [Route("GetAllComplianceTypes")]
        [HttpGet]
        public async Task<List<ComplianceTypeViewModel>> GetComplianceTypeList(int StageId)
        {
            return await _iAccountLogic.GetComplianceTypeList(StageId);
        }

        /// <summary>
        /// Get Agile Questions
        /// </summary>
        /// <param name="ComplianceTypeId"></param>
        /// <param name="ProjectId"></param>
        /// <param name="AccountId"></param>
        /// <param name="SowId"></param>
        /// <param name="StageId"></param>
        /// <param name="SprintId"></param>
        /// <returns></returns>
        [Route("GetAgileQuestions")]
        [HttpGet]
        public async Task<List<AgileQuestionViewModel>> GetAgileQuestionList(int ComplianceTypeId,
            int ProjectId,
            int AccountId,
            int SowId,
            int StageId,
            int SprintId)
        {
            return await _iAccountLogic.GetAgileQuestionList(ComplianceTypeId,
                ProjectId,
                AccountId,
                SowId,
                StageId,
                SprintId);
        }

        /// <summary>
        /// Get Project KickStart Questions
        /// </summary>
        /// <param name="ComplianceTypeId"></param>
        /// <param name="ProjectId"></param>
        /// <param name="AccountId"></param>
        /// <param name="SowId"></param>
        /// <param name="StageId"></param>        
        /// <returns></returns>
        [Route("GetProjectKickStartQuestions")]
        [HttpGet]
        public async Task<List<ProjectKickStartQuestionViewModel>> GetProjectKickStartQuestionList(int ComplianceTypeId,
            int ProjectId,
            int AccountId,
            int SowId,
            int StageId)
        {
            return await _iAccountLogic.GetProjectKickStartQuestionList(ComplianceTypeId,
                ProjectId,
                AccountId,
                SowId,
                StageId);
        }

        /// <summary>
        /// Get All Complience Types
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        [Route("GetAllProjectList")]
        [HttpGet]
        public async Task<List<ProjectViewModel>> GetProjectList(int AccountId)
        {
            return await _iAccountLogic.GetProjectList(AccountId);
        }

        /// <summary>
        /// Get All Project
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        [Route("GetAllSOWList")]
        [HttpGet]
        public async Task<List<SOWViewModel>> GetSOWList(int ProjectId)
        {
            return await _iAccountLogic.GetSOWList(ProjectId);
        }

        /// <summary>
        /// Get All SOW
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <param name="ComplianceTypeId"></param>
        /// <returns></returns>
        [Route("GetAllStageList")]
        [HttpGet]
        public async Task<List<StageViewModel>> GetStageList()
        {
            return await _iAccountLogic.GetStageList();
        }

        /// <summary>
        /// Get All Questions
        /// </summary>
        /// <param name="StageId"></param>
        /// <param name="ComplianceTypeId"></param>
        /// <returns></returns>
        [Route("GetAllQuestionList")]
        [HttpGet]
        public async Task<List<QuestionListViewModel>> GetQuestionList(int StageId, int ComplianceTypeId)
        {
            return await _iAccountLogic.GetQuestionList(StageId, ComplianceTypeId);
        }       
        
        ///// <summary>
        ///// Insert Kick Start Response 
        ///// </summary>
        ///// <param name="kickStartResponse"></param>
        ///// <returns></returns>
        //[Route("InsertProjectKickStartQuestion")]
        //[HttpPost]
        //public async Task InsertProjectKickStartQuestion([FromBody] InsertQuestion kickStartResponse)
        //{
        //    await _iAccountLogic.InsertProjectKickStartQuestion(kickStartResponse);
        //}

        /// <summary>
        /// Insert SOW Start Question 
        /// </summary>
        /// <param name="kickStartResponse"></param>
        /// <returns></returns>
        [Route("InsertSOWKickStartQuestion")]
        [HttpPost]
        public async Task InsertSOWKickStartQuestion([FromBody] InsertQuestion SowQuestion)
        {
            await _iAccountLogic.InsertProjectKickStartQuestion(SowQuestion);
        }

        /// <summary>
        /// Insert Sprint Start Question 
        /// </summary>
        /// <param name="kickStartResponse"></param>
        /// <returns></returns>
        [Route("InsertSprintKickStartQuestion")]
        [HttpPost]
        public async Task InsertSprintKickStartQuestion([FromBody] InsertQuestion SprintQuestion)
        {
            await _iAccountLogic.InsertSprintKickStartQuestion(SprintQuestion);
        }

        /// <summary>
        /// Get Master Select List
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [Route("SelectList")]
        [HttpGet]
        public async Task<List<SelectListViewModel>> GetMasterList(string Entity)
        {
            return await _iAccountLogic.GetMasterList(Entity);
        }

        /// <summary>
        /// SaveSowQuestionResponse
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, DisableRequestSizeLimit]
        [Route("SaveSowQuestionResponse")]
        public async Task<ReturnResponseModel> SaveSowQuestionResponse([FromBody] SaveSowQuestionResponse request)
        {
            return await _iAccountLogic.SaveSowQuestionResponse(request);

        }

        /// <summary>
        /// SaveAgileQuestionResponse
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost, DisableRequestSizeLimit]
        [Route("SaveAgileQuestionResponse")]
        public async Task<ReturnResponseModel> SaveAgileQuestionResponse([FromBody] SaveAgileQuestionResponse request)
        {
            return await _iAccountLogic.SaveAgileQuestionResponse(request);

        }

        /// <summary>
        /// Delete Sow Question Response
        /// </summary>
        /// <param name="ArtefactId">document id</param>
        /// <returns></returns>
        [Route("DeleteSowQuestionResponse")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSowQuestionResponse(int ArtefactId)
        {
            ReturnResponseModel result = new ReturnResponseModel();
            result = await _iAccountLogic.DeleteSowQuestionResponse(ArtefactId);
            if (result.Status)
            {
                return NoContent();
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Delete Sprint Question Response
        /// </summary>
        /// <param name="ArtefactId">document id</param>
        /// <returns></returns>
        [Route("DeleteSprintQuestionResponse")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSprintQuestionResponse(int ArtefactId)
        {
            ReturnResponseModel result = new ReturnResponseModel();
            result = await _iAccountLogic.DeleteSprintQuestionResponse(ArtefactId);
            if (result.Status)
            {
                return NoContent();
            }
            return BadRequest(result);
        }

        /// <summary>
        /// Download Artefact
        /// </summary>
        /// <param name="ArtefactId"></param>
        /// <returns></returns>
        [Route("DownloadArtefact")]
        [HttpGet]
        public async Task<IActionResult> DownloadArtefact(int ArtefactId)
        {
            ArtefactDownload result = new ArtefactDownload();
            result = await _iAccountLogic.DownloadArtefact(ArtefactId);
            if (result.returnResponseModel.Status)
            {
                result.File = Convert.ToBase64String(System.IO.File.ReadAllBytes(result.FilePath));
                return Ok(result);
            }
            return BadRequest(result.returnResponseModel);
        }
        #endregion
    }
}
