
export class Title_Basics {
    constructor(
        public tconst: number,
        public titleType: string,
        public primaryTitle: string,
        public originalTitle: string,
        public isAudit: number,
        public startYear: number,
        public endYear: number,
        public runtimeMinutes: number,
        public genres: string,
){}
    }
export interface Title_BasicsIface {

    tconst: number,
    titleType: string,
    primaryTitle: string,
    originalTitle: string,
    isAudit: number,
    startYear: number,
    endYear: number,
    runtimeMinutes: number,
    genres: string,

}
