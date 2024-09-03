using Microsoft.AspNetCore.Mvc;
using YourQuoteBoard.DTO.Tag;
using YourQuoteBoard.Enums;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController(ITagService _tagService) : ControllerBase
    {
        /// <summary>
        /// Add a tag.
        /// </summary>
        /// <param name="tag">DTO for tag creation.</param>
        /// <response code="200">Tag added.</response>
        [HttpPost("add-tag")]
        public async Task<IActionResult> AddTagAsync(TagCreateDTO tag)
        {
            var addedTag = await _tagService.AddTagAsync(tag);
            return Ok();
        }

        /// <summary>
        /// Gets all tags of specified type.
        /// </summary>
        /// <param name="tagType">Type of tags.</param>
        /// <response code="200">Tags fetched.</response>
        [HttpGet("all-tags")]
        public async Task<IActionResult> GetAllTags(ItemType tagType)
        {
            var tags = await _tagService.GetAllTagsAsync(tagType);
            return Ok(tags);
        }

        /// <summary>
        /// Gets all of the daufault tahs for a specified type.
        /// </summary>
        /// <param name="tagType">Type of tags.</param>
        /// <response code="200">Tags fetched.</response>
        [HttpGet("default-tags")]
        public async Task<IActionResult> GetAllDefaultTags(ItemType tagType)
        {
            var tags = await _tagService.GetAllDefaultTagsAsync(tagType);
            return Ok(tags);
        }
    }
}
