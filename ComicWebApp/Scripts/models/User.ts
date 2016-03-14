
export interface ValidationResult {
    [key: string]: boolean;
}

export class User {
    constructor(
        public Name: string,
        public Username: string,
        public Email: string,
        public Password: string,
        public Phone: string,
        public Genre: string,
        public DOB?: Date
    ) { };
} 