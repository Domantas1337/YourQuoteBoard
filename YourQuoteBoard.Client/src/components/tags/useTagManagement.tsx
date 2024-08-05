// useTagManagement.ts
import { useState, useEffect } from 'react';
import { TagDisplayDTO } from "../../models/tag/TagDisplayDTO";
import { getDefaultTags } from "../../api/tag";
import { TagType } from "../../enums/TagType";

export default function useTagManagement(tagType: TagType, maxTags: number = 5) {
  const [tags, setTags] = useState<TagDisplayDTO[]>([]);
  const [selectedTag, setSelectedTag] = useState<TagDisplayDTO | null>(null);
  const [selectedTagIds, setSelectedTagIds] = useState<string[]>([]);

  useEffect(() => {
    const fetchTags = async () => {
      try {
        const fetchedTags = await getDefaultTags(tagType);

        setTags(fetchedTags);
      } catch (error) {
        console.log("Failed to fetch tags: ", error);
      }
    };

    fetchTags();
  }, [tagType]);

  function handleTagSelection(tag: TagDisplayDTO) {
    setSelectedTag(tag);
  }

  function handleTagAddition() {
    if (selectedTag == null || selectedTagIds.length >= maxTags) {
      return;
    }

    if (!selectedTagIds.includes(selectedTag.tagId)) {
      setSelectedTagIds(prevIds => [...prevIds, selectedTag.tagId]);
    } else {
      console.log("Tag already selected:", selectedTag);
    }
  }

  function removeTag(tagToRemove: string) {
    setSelectedTagIds(prevIds => prevIds.filter(id => id !== tagToRemove));
  }

  return { 
    tags, 
    selectedTag, 
    selectedTagIds,
    handleTagSelection, 
    handleTagAddition,
    removeTag
  };
}