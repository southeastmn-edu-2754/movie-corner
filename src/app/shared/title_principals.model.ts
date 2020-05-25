import { Title_Basics  } from './title_basics.model';
import { Name_Basics } from './namebasics.model';

export class Title_Principals {
    constructor(
        public tconst: string,
        public ordering: number,
        public nconst: string,
        public category: string,
        public job: string,
        public characters: string,
        // public nconstNavigation: Name_Basics,
        // public tconstNavigation: Title_Basics,
){}
    }


