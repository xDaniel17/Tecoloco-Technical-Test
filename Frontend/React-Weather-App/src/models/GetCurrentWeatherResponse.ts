import { WeatherData } from './WeatherData';

export interface GetCurrentWeatherResponse {
    resultCode: number;
    messages: string[];
    content: WeatherData;
}