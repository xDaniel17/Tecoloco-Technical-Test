export interface GetDailyForecastRequest {
    city: string;
    days?: number;
    page?: number;
    pageSize?: number;
}