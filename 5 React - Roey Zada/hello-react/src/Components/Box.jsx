import "./Box.css"

const Box = (props) => {
    const title = props.title;
    const info = props.info;
    const content = props.content;

    return (
        <div className="Box">
            <h1>{title}</h1>
            <h3>{info}</h3>
            <div className="content">
                <h3>{content}</h3>
            </div>
        </div>
    )
}

export default Box;