import IDestroy from "../Interfaces/IDestroy";
import ISpeakable from "../Interfaces/ISpeakable";
import Person from "./Person";
import Pet from "./Pet";

class Cat extends Pet implements ISpeakable, IDestroy {
    toys: string[] = [];
    voice: string = "meow meow";
    furniture: string = "Table";
    
    constructor(name: string, type: string, owner: Person) {
        super(name, type, owner)
    }
    destroy(furniture:string): string {
        return `Oh no, the ${furniture} was destroyed!`;
    }

    speak(): string {
        return this.voice;
    }
}

export default Cat;