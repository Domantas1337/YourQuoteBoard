using Microsoft.AspNetCore.Mvc;
using YourQuoteBoard.DTO.Tag;
using YourQuoteBoard.Entity;
using YourQuoteBoard.Enums;
using YourQuoteBoard.Interfaces.Service;

namespace YourQuoteBoard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController(ITagService _tagService) : Controller
    {

        [HttpPost("add-tag")]
        public async Task<IActionResult> AddTagAsync(TagCreateDTO tag)
        {
            var addedTag = await _tagService.AddTagAsync(tag);

            return Ok();
        }

        [HttpGet("all-tags")]
        public async Task<IActionResult> GetAllTags(ItemType tagType)
        {
            var tags = await _tagService.GetAllTagsAsync(tagType);
            
            return Ok(tags);
        }

        [HttpGet("default-tags")]
        public async Task<IActionResult> GetAllDefaultTags(ItemType tagType)
        {
            var tags = await _tagService.GetAllDefaultTagsAsync(tagType);

            return Ok(tags);
        }

    }
}
