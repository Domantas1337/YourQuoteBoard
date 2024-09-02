﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YourQuoteBoard.DTO.Folder;
using YourQuoteBoard.DTO.Rating;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FoldersController(IFolderService _folderService) : ControllerBase
    {
        [HttpPost("add-quote-folder")]
        public async Task<IActionResult> AddQuoteFolder(FolderCreateDTO folderCreateDTO)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                var addedFolder = await _folderService.AddQuoteFolderAsync(folderCreateDTO, userId);
                return Ok(addedFolder);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("all-quote-folders-display")]
        public async Task<IActionResult> GetQuoteFoldersForDisplay()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                var folders = await _folderService.GetQuoteFoldersForDisplayAsync(userId);
                return Ok(folders);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("add-quote/{folderId}")]
        public async Task<IActionResult> AddQuoteToFolderAsync(Guid folderId, [FromBody] Guid quoteId)
        {
            try
            {
                await _folderService.AddQuoteToFolderAsync(folderId, quoteId);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return BadRequest();
            }

            return Ok();
        }

        [Authorize]
        [HttpGet("quote/{id}")]
        public async Task<IActionResult> GetQuoteFolderContent(Guid id)
        {
            var folderContent = await _folderService.GetQuoteFolderContentAsync(id);
            return Ok(folderContent);
        }

        [HttpDelete("{folderId}")]
        public async Task<IActionResult> DeleteForderAsync(Guid folderId)
        {
            try
            {
                await _folderService.DeleteQuoteFolderAsync(folderId);
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

    }
}
