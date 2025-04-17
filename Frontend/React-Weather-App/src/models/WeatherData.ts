export interface WeatherData {
    id: number;
    city: string;
    countryCode: string;
    temperature: number;
    minTemperature: number;
    maxTemperature: number;
    condition?: string;
    date: Date;
}