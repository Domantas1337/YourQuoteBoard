import { apiClient } from "../apiClient";
import { TagType } from "../enums/TagType";
import { TagDisplayDTO } from "../models/tag/TagDisplayDTO";

export async function getDefaultTags(tagType: TagType): Promise<TagDisplayDTO[]>{
    const response = await apiClient.get(`/api/Tag/all-tags?tagType=${tagType}`);
    const tags = response.data

    return tags;
}