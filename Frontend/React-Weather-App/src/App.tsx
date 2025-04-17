import './App.css'
import { Route, Routes } from 'react-router-dom';
import Weather from './pages/Weather';
import About from './pages/About';
import Contact from './pages/Contact';
import Home from './pages/Home';
import NotFound from './pages/NotFound';
import { WeatherService } from './services/WeatherService';


function App({ weatherService }: { weatherService: WeatherService }) {

  return (
    <>
      <Routes>
        <Route path="/" index element={<Home />} />
        <Route path="/home" index element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/contact" element={<Contact />} />
        <Route path="/weather/:id" element={<Weather weatherService={weatherService} />} />
        <Route path="*" element={<NotFound />} />
      </Routes>
    </>
  )
}

export default App
