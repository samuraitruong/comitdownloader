import {Chapter} from './chapter'

export class Story {
    Name: string;
    Summary: string;
    CoverUrl: string;
    Categories: string[];
    Chapters: Chapter[]
    Author: string;
} 

export class GenreRes {
    Stories: Story[];
    PageSize: number;
    PageCount: number;
    TotalItems: number;
}
export class GenreInfo {
    Name: string;
    StoriesCount: number;
}
export class StoryListRes extends GenreRes{
}