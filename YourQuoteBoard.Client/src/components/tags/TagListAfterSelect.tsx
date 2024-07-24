import { TagDisplayDTO } from "../../models/tag/TagDisplayDTO"

interface TagListAfterSelectProps{
    selectedTagIds: string[];
    tags: TagDisplayDTO[];
    onRemoveTag: (tagId: string) => void;
}

export default function TagListAfterSelect({selectedTagIds, tags, onRemoveTag}: TagListAfterSelectProps){


    return  <div className="selected-tags">
                {selectedTagIds.map((tag, index) => (
                    <span key={index} className="tag">
                        {tags.find(t => t.tagId === tag)!.name}
                        <button type="button" className="remove-tag-btn" onClick={() => onRemoveTag(tag)}>
                            ×
                        </button>
                    </span>
                ))}
            </div>
}