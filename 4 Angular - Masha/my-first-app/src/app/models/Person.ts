class Person {

    name: string;
    age: number;

    constructor(name: string = "", age: number = 0){
        this.name= name;
        this.age= age;
    }

    greet(){
        return "Hey, nice to meet you, my name is " + this.name;
    }
}

export default Person;