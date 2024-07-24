import { getDefaultTags } from "../../api/tag";
import { useEffect, useState } from "react";
import { TagDisplayDTO } from "../../models/tag/TagDisplayDTO";
import { TagType } from "../../enums/TagType";
import BookDisplayDTO from "../../models/books/BookDisplayDTO";

interface useTagManagementProps{
    tagType: TagType;
    book: BookDisplayDTO;
}

export default function useTagManagement({tagType, book} : useTagManagementProps){
    const [tags, setTags] = useState<TagDisplayDTO[]>([]);
    const [selectedTag, setSelectedTag] = useState<TagDisplayDTO | null>(null);

    useEffect(() => {
        const fetchTags = async () => {
            try{
                const fetchedTags = await getDefaultTags(tagType);
                
                setTags(fetchedTags);
            }catch(error){
                console.log("Failed to fetch tags: ", error);
            }
        }

        fetchTags();
    }, [tagType]);

    function handleTagSelection(tag: TagDisplayDTO){
        setSelectedTag(tag)
    }

    function handleTagAddition(){
        if (selectedTag == null || book.tagIds.length > 4){
            return;
        }

        if(!book.tagIds.includes(selectedTag.tagId)){
            setBook(prevBook => ({
                ...prevBook,
                tagIds: [...prevBook.tagIds, selectedTag.tagId]
            }));

        }else{
            console.log(selectedTag);
        }
    }


}