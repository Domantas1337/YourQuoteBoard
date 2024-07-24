import { useEffect, useState } from "react";
import { TagDisplayDTO } from "../../models/tag/TagDisplayDTO";
import { getDefaultTags } from "../../api/tag";
import { TagType } from "../../enums/TagType";

interface TagSelectParams{
    onSelectedFromList : (tag: TagDisplayDTO) => void;
    onTagAddition : () => void;
    tagType: TagType;
}

export default function TagSelect({onSelectedFromList, onTagAddition, tagType} : TagSelectParams){
    const [tags, setTags] = useState<TagDisplayDTO[]>([]);


    useEffect(() => {
        const fetchTags = async () => {
            try{
                const fetchedTags = await getDefaultTags(tagType);
                console.log(tagType);
                setTags(fetchedTags);
            }catch(error){
                console.log("Failed to fetch tags: ", error);
            }
        }

        fetchTags();
    }, [tagType]);

    return <div className="form-group tag-section">
                <label htmlFor="tagInput" className="default-label">Tags:</label>
                <div className="tag-input-container">
                    <select id="tagInput" className="tag-select"  onChange={(e) => onSelectedFromList(tags[parseInt(e.target.value)])}>
                        <option value="">Select a tag</option>
                        {tags && tags.map((tag, index) => (
                        <option key={tag.tagId} value={index}>{tag.name}</option>
                        ))}
                    </select>
                    <button type="button" className="add-tag-btn" onClick={onTagAddition}>Add Tag</button>
                </div>
            </div>
}