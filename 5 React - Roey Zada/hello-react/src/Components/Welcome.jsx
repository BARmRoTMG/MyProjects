import './Welcome.css';

const Welcome = (props) => {

    const name = props.name;
    const age = props.age;

    return (
        <>
            <h1 className="Welcome">Hello {name}, Age: {age}</h1>
            {props.children}
        </>
    )

    //return React.createElement("h1", null, "Hello Mosh in React"); //REACT
}

export default Welcome;