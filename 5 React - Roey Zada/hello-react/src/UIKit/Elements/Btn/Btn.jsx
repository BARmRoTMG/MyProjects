import Line from '../../Layouts/Line/Line';
import Icon from '../Icon/Icon';
import './Btn.css';

export const Btn = ({children, onClick, i}) => {
    return (
        <button className='Btn' onClick={onClick}>
            <Line>
                {i && <Icon i={i} />}
                {children}
            </Line>
        </button>
    )
}

export const LinkBtn = () => {
    return (
        <h4>Link Button</h4>
    )
}

export default Btn;