import { useState } from "react"
import { Btn, Line } from "UIKit"

export const ColorSwitch = () => {
    const [isRed, setIsRed] = useState(true);

    const handleSwitch = () => {
        setIsRed(!isRed);
    }

    const styleCss = {
        color: isRed ? 'red' : 'blue'
    }

    return (
        <Line>
            <h3 style={styleCss}>Look at my color</h3>
            <Btn onClick={handleSwitch}>Switch</Btn>
        </Line>
    )
}