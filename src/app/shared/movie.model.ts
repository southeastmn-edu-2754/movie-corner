export class Movie {
    constructor(
        public tconst: string,
        public primaryTitle: string,
        public originalTitle: string,
        public isAdult: boolean,
        public startYear: number,
        public endYear: number,
        public runtimeMinutes: number,
        public genres: string
        ) { }
}