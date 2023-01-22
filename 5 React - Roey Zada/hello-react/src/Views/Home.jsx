import { Line, LinkBtn, Btn, Icon } from 'UIKit';

export const Home = () => {

    const handleClick = () => {
        console.log('clicked!!');
    }

    return (
        <div>
            <Line>
                <LinkBtn />
                <Icon i="home" />
                <Icon i="favorite" />
                <Btn i="home" onClick={handleClick}>CLICK</Btn>
                <Btn onClick={handleClick}>CLICK</Btn>
            </Line>
        </div>
    )
}