class Movie {
    name: string;
    year: number;
    description: string;
    image: string;
    isWatched: boolean;

    constructor(name: string, year: number, description: string, image: string, isWatched: boolean) {
        this.name = name;
        this.year = year;
        this.description = description;
        this.image = image;
        this.isWatched = isWatched;
    }
}

export default Movie;