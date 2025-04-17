export interface WeatherData {
    Id: number;
    City: string;
    CountryCode: string;
    Temperature: number;
    MinTemperature: number;
    MaxTemperature: number;
    Condition?: string;
    Date: Date;
}