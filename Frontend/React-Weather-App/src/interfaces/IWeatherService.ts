import { GetCurrentWeatherRequest } from '../models/GetCurrentWeatherRequest';
import { GetDailyForecastRequest } from '../models/GetDailyForecastRequest';
import { BaseResponse } from '../models/BaseResponse';
import { WeatherData } from '../models/WeatherData';

export interface IWeatherService {
    getCurrentWeather(request: GetCurrentWeatherRequest): Promise<BaseResponse<WeatherData>>;
    getDailyForecast(request: GetDailyForecastRequest): Promise<BaseResponse<WeatherData[]>>;
}