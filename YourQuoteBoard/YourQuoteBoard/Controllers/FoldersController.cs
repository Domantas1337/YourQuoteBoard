using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourQuoteBoard.DTO.Folder;
using YourQuoteBoard.Filters;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoldersController(IFolderService _folderService) : ControllerBase
    {
        /// <summary>
        /// Adds a folder for a user to store quotes.
        /// </summary>
        /// <param name="folderCreateDTO">DTO for folder creation.</param>
        /// <response code="200">Folder added.</response>
        /// <response code="404">User not foind</response>
        [HttpPost("add-quote-folder")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> AddQuoteFolder(FolderCreateDTO folderCreateDTO)
        {
            var userId = HttpContext.Items["UserId"] as string;

            var addedFolder = await _folderService.AddQuoteFolderAsync(folderCreateDTO, userId);
            return Ok(addedFolder);
        }

        /// <summary>
        /// Gets all the folders a user created. Mainly for displaying.
        /// </summary>
        /// <response code="200">Folder fetched.</response>
        /// <response code="404">User not foind</response>
        [HttpGet("all-quote-folders-display")]
        [ServiceFilter(typeof(ValidateUserFilter))]
        public async Task<IActionResult> GetQuoteFoldersForDisplay()
        {
            var userId = HttpContext.Items["UserId"] as string;

            var folders = await _folderService.GetQuoteFoldersForDisplayAsync(userId);
            return Ok(folders);
        }

        /// <summary>
        /// Adds a quote to a folder.
        /// </summary>
        /// <param name="folderId">The id of the folder.</param>
        /// <param name="quoteId">The id of the quote.</param>
        /// <response code="200">The quote was added to the folder.</response>
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

        /// <summary>
        /// Get the quotes stored in a folder.
        /// </summary>
        /// <param name="folderId">The id of the folder.</param>
        /// <response code="200">Quotes fetched.</response>
        [Authorize]
        [HttpGet("quote/{folderId}")]
        public async Task<IActionResult> GetQuoteFolderContent(Guid folderId)
        {
            var folderContent = await _folderService.GetQuoteFolderContentAsync(folderId);
            return Ok(folderContent);
        }

        /// <summary>
        /// Deletes a folder
        /// </summary>
        /// <param name="folderId">The id of the folder.</param>
        /// <response code="200">Folder deleted.</response>
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
