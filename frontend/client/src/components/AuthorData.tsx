import { BookData } from "./BookData";

export interface AuthorData {
    authorId: number;
    name: string;
    dateOfBirth: Date;
    books: BookData[];
}

export const getAuthors = async (): Promise<AuthorData[]> =>
{
    await wait(500);
    return authors;
};

const wait = (ms: number) : Promise<void> => {
    return new Promise(resolve => setTimeout(resolve, ms));
}

const authors: AuthorData[] = [
    {
        authorId: 1,
        name: "J.K. Rowling",
        dateOfBirth: new Date(),
        books: [
            {
                bookId: 1,
                title: "The Great Gatsby",
                cover: "https://example.com/great-gatsby-cover.jpg",
                content: "The Great Gatsby is a novel...",
                genre: "Fiction",
                rating: 8.5,
            },
            {
                bookId: 2,
                title: "To Kill a Mockingbird",
                cover: "https://example.com/to-kill-a-mockingbird-cover.jpg",
                content: "To Kill a Mockingbird is a novel...",
                genre: "Fiction",
                rating: 6.4,
            },
        ],
    },
    {
        authorId: 2,
        name: "Agatha Christie",
        dateOfBirth: new Date(),
        books: [],
    },
];