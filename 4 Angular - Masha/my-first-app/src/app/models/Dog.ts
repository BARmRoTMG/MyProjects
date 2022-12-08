import IDestroy from "../Interfaces/IDestroy";
import ISpeakable from "../Interfaces/ISpeakable";
import Person from "./Person";
import Pet from "./Pet";

class Dog extends Pet implements ISpeakable, IDestroy {
    furniture: string = "Couch";
    voice: string = "how how";

    constructor(name: string, type: string, owner: Person) {
        super(name, type, owner)
    }

    destroy(furniture: string): string {

        return `Oh no, the ${furniture} was destroyed!`;
    }
    speak(): string {
        return this.voice;
    }
}

export default Dog;