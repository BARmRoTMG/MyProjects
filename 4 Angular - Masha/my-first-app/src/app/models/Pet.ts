import Person from "./Person";

class Pet {
    name: string;
    type: string;
    owner: Person;

    constructor(name: string, type: string, owner: Person){
        this.name = name;
        this.type = type;
        this.owner = owner;
    }
}

export default Pet;