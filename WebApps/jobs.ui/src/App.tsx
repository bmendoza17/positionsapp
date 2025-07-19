import "./App.css"
import { Positions } from "./features/positions/positionsList"
import logo from "./assets/hikrulogo.jpg"

export const App = () => (
  <div className="App">
    <header className="App-header">
      <img src={logo} className="App-logo" alt="logo" />
      <Positions />
    </header>
  </div>
)
