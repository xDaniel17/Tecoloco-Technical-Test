import { WeatherData } from './WeatherData';

export interface GetDailyForecastResponse {
    resultCode: number;
    totalRecords: number;
    totalPages: number;
    currentPage: number;
    pageSize: number;
    messages: string[];
    content: WeatherData[];
}