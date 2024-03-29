﻿using AdvertApp.Business.Interfaces;
using AdvertApp.Common.Enums;
using AdvertApp.Dtos;
using AdvertApp.UI.Extensions;
using AdvertApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdvertApp.UI.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IApplicationService _applicationService;
        public ApplicationController(IAppUserService appUserService, IApplicationService applicationService)
        {
            _appUserService = appUserService;
            _applicationService = applicationService;
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Send(int advertId)
        {
            var userId = Convert.ToInt32((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            bool applicationCheck = _applicationService.CheckUserApplicationAsync(advertId, userId).Result;
            if (applicationCheck)
                return RedirectToAction("AdvertDetail", "Home", new {id=advertId});
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);

            ViewBag.GenderId = userResponse.Data.GenderId;

            var items = Enum.GetValues(typeof(MilitaryStatusType));
            var list = new List<MilitaryStatusListDto>();
            foreach (int item in items)
            {
                list.Add(new()
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                });
            }

            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

            return View(new ApplicationCreateModel()
            {
                AdvertisementId = advertId,
                AppUserId = userId
            });
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Send(ApplicationCreateModel model)
        {
            ApplicationCreateDto dto = new();
            if (model.CvFile != null || model.PhotoFile != null)
            {
                dto.CvPath = await CreateFile(model.CvFile, "cvFiles");
                dto.PhotoPath = await CreateFile(model.PhotoFile, "photoFiles");
            }

            dto.ApplicationStatusId = model.ApplicationStatusId;
            dto.AdvertisementId = model.AdvertisementId;
            dto.AppUserId = model.AppUserId;
            dto.PostponeEndDate = model.PostponeEndDate;
            dto.MilitaryStatusId = model.MilitaryStatusId;
            dto.WorkExperience = model.WorkExperience;
            dto.AppliedDate = model.AppliedDate;

            var response = await _applicationService.CreateAsync(dto);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                var userId = Convert.ToInt32((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
                var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);
                ViewBag.GenderId = userResponse.Data.GenderId;

                var items = Enum.GetValues(typeof(MilitaryStatusType));
                var list = new List<MilitaryStatusListDto>();
                foreach (int item in items)
                {
                    list.Add(new()
                    {
                        Id = item,
                        Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                    });
                }
                ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");
                return View(model);
            }
            return RedirectToAction("AdvertList", "Home");
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> List()
        {
            var list = await _applicationService.GetListAsync(ApplicationStatusType.Applied);
            return View(list);
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> SetStatus(int applicationId,ApplicationStatusType type)
        {
            await _applicationService.SetStatusAsync(applicationId, type);
            return RedirectToAction("List");
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ApprovedList()
        {
            var list = await _applicationService.GetListAsync(ApplicationStatusType.InterviewCall);
            return View(list);
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> RejectedList()
        {
            var list = await _applicationService.GetListAsync(ApplicationStatusType.Negative);
            return View(list);
        }

        [Authorize(Roles ="Member")]
        public async Task<IActionResult> AppliedList()
        {
            var userId = Convert.ToInt32((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var list = await _applicationService.GetUserApplications(userId);
            return View(list);
        }

        [Authorize(Roles ="Member")]
        public async Task<IActionResult> Remove(int applicationId)
        {
            var response = await _applicationService.RemoveAsync(applicationId);
            return this.ResponseRediretAction(response, "AppliedList");
        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","cvFiles",fileName);
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }

        private async Task<string> CreateFile(IFormFile file, string fileDirectory)
        {
            var fileName = Guid.NewGuid().ToString();
            var exName = Path.GetExtension(file.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileDirectory, fileName + exName);
            var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return fileName+exName;
        }
    }
}
