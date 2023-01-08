import Welcome from "./Welcome";
import Box from "./Box";

const App = (props) => {
  const age = props.age;

  const styleCss = {
    color: 'red',
    backgroundColor: 'yellow'
  }

  return (
    <>
      <h1>React App</h1>

      <Box
        title="React 1080"
        info="This is our react course's first lessson."
        content="this is content inside of a box.">
      </Box>

      <Welcome style={styleCss} name="Bar" age={age} children={<h3>Will this be rendered?</h3>}>
      </Welcome>
    </>
  )
}

export default App;