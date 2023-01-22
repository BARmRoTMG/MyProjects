import { useState } from "react"
import { Btn, Line, Row } from "UIKit"

export const Combined = () => {
    const [count, setCount] = useState(0);
    const [isRed, setIsRed] = useState(true);

    const handleAdd = () => {
        setCount(count + 1);
    }
    
    const handleSwitch = () => {
        setIsRed(!isRed);
    }
    const styleCss = {
        color: isRed ? 'red' : 'blue'
    }
    
    return (
        <Row>
            <h2 style={styleCss}>Combined: {count}</h2>
            <Line>
                <Btn onClick={handleAdd}>Add</Btn>
                <Btn onClick={handleSwitch}>Switch</Btn>
            </Line>
        </Row>
    )
}