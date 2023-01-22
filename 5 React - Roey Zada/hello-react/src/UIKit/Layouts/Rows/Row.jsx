import './Row.css';

export const Row = (props) => {
    return (
        <div className='Rows'>
            {props.children}
        </div>
    )
    
}

export default Row;