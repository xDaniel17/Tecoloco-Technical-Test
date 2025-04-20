import { IWeatherService } from '../interfaces/IWeatherService';
import { GetCurrentWeatherRequest } from '../models/GetCurrentWeatherRequest';
import { GetDailyForecastRequest } from '../models/GetDailyForecastRequest';
import { BaseResponse } from '../models/BaseResponse';
import { WeatherData } from '../models/WeatherData';

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL;// 'https://localhost:7124/api';//pendiente configurar .env

export class WeatherService implements IWeatherService {
    async getCurrentWeather(request: GetCurrentWeatherRequest): Promise<BaseResponse<WeatherData>> {
        console.log('Fetching current weather data... ' + API_BASE_URL);
        const url = `${API_BASE_URL}/weather/current?city=${encodeURIComponent(request.city)}`;
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(`HTTP Error: ${response.status}`);
        }
        return (await response.json()) as BaseResponse<WeatherData>;
    }

    async getDailyForecast(request: GetDailyForecastRequest): Promise<BaseResponse<WeatherData[]>> {
        const params = new URLSearchParams();
        params.append('city', request.city);
        if (request.days) params.append('days', request.days.toString());
        if (request.page) params.append('page', request.page.toString());
        if (request.pageSize) params.append('pageSize', request.pageSize.toString());

        const url = `${API_BASE_URL}/weather/forecast?${params.toString()}`;
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(`HTTP Error: ${response.status}`);
        }
        return (await response.json()) as BaseResponse<WeatherData[]>;
    }
}