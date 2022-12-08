class Person {

    name: string;
    age: number;
    address: string;

    constructor(name: string = "", age: number = 0, address: string = ""){
        this.name = name;
        this.age = age;
        this.address = address;
    }

    greet(){
        return "Hey, nice to meet you, my name is " + this.name;
    }
}

export default Person;