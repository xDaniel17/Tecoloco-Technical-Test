import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import '@fontsource/roboto/400.css';
import { WeatherService } from './services/WeatherService';

// Crear una instancia de WeatherService
const weatherService = new WeatherService();

createRoot(document.getElementById('root')!).render(
  <BrowserRouter>
    <StrictMode>
      <App weatherService={weatherService} />
    </StrictMode>
  </BrowserRouter>,
)
