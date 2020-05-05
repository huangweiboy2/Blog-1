﻿using Meowv.Blog.Application.Common;
using Meowv.Blog.ToolKits.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using static Meowv.Blog.Domain.Shared.MeowvBlogConsts;

namespace Meowv.Blog.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
    public class CommonController : AbpController
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        /// <summary>
        /// 必应每日壁纸，返回图片URL
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("bing/imgUrl")]
        public async Task<ServiceResult<string>> GetBingImgUrlAsync()
        {
            return await _commonService.GetBingImgUrlAsync();
        }

        /// <summary>
        /// 必应每日壁纸，直接返回图片
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("bing/imgFile")]
        public async Task<FileContentResult> GetBingImgFileAsync()
        {
            var url = await _commonService.GetBingImgFileAsync();

            return File(url.Result, "image/jpeg");
        }
    }
}