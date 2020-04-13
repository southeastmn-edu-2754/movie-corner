export class User {
    constructor(
        public userId: number,
        public userName: string,
        public fullName: string,
        public password: string,
        public created: Date
)
    { }
}

export interface UserIface {
    userId: number,
    userName: string,
    fullName: string,
    password: string,
    created: Date


}