import { useState } from "react";
import { Btn, Line } from "UIKit"

export const Counter = () => {
    const [value, setValue] = useState(0);

    const handleAdd = () => {
        setValue(value + 1);
        console.log('setState')
    }

    return (
        <>
            <Line>
                <h2>Count, {value}</h2>
                <Btn onClick={handleAdd}>Add</Btn>
            </Line>
        </>
    )

}