

    export class Phone {
        id: any;
        description: string;
        number: string;

        constructor() {
            this.id = '';
            this.description = '';
            this.number = '';            
        }
    }

    export class Person {
        id: any;
        name: string;
        dateBirth: string;
        phones: Phone[];

        constructor() {
            this.id = '';
            this.name = '';
            this.dateBirth = '';            
        }
    }

