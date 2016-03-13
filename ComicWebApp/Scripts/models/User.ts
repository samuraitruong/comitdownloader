
export class User {
    constructor(
        public Name: string,
        public Username: String,
        public Email: String,
        public Password: string,
        public Phone: string,
        public Genre: string,
        public DOB?: Date
    ) { };
} 