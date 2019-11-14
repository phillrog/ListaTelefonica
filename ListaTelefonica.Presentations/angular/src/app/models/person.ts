

    export class Phone {
        Id: any;
        Description: string;
        Number: string;

        constructor() {
            this.Id = '';
            this.Description = '';
            this.Number = '';            
        }
    }

    export class Person {
        Id: any;
        Name: string;
        DateBirth: string;
        Phones: Phone[];

        constructor() {
            this.Id = '';
            this.Name = '';
            this.DateBirth = '';            
        }
    }

