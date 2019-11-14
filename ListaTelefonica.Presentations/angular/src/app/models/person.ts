namespace models {

    export interface Phone {
        Id: number;
        Description: string;
        Number: string;
    }

    export interface Person {
        Id: number;
        Name: string;
        DateBirth: string;
        Phones: Phone[];
    }

}