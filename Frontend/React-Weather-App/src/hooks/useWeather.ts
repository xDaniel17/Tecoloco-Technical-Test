import { useState, useEffect } from 'react';
import { IWeatherService } from '../interfaces/IWeatherService';
import { WeatherData } from '../models/WeatherData';

export const useWeather = (city: string | undefined, weatherService: IWeatherService) => {
    const [currentWeather, setCurrentWeather] = useState<WeatherData | null>(null);
    const [forecast, setForecast] = useState<WeatherData[] | null>(null);
    const [error, setError] = useState<string | null>(null);
    const [loading, setLoading] = useState<boolean>(false);

    useEffect(() => {
        if (!city) {
            setError('No se ingreso una ciudad');
            return;
        }

        const fetchWeatherData = async () => {
            setLoading(true);
            try {
                const currentWeatherResponse = await weatherService.getCurrentWeather({ city });
                if (currentWeatherResponse.content) {
                    const currentWeatherData: WeatherData = {
                        id: currentWeatherResponse.content.id,
                        city: currentWeatherResponse.content.city,
                        countryCode: currentWeatherResponse.content.countryCode,
                        temperature: currentWeatherResponse.content.temperature ?? 0,
                        minTemperature: currentWeatherResponse.content.minTemperature ?? 0,
                        maxTemperature: currentWeatherResponse.content.maxTemperature ?? 0,
                        condition: currentWeatherResponse.content.condition || 'N/A',
                        date: new Date(currentWeatherResponse.content.date),
                    };
                    setCurrentWeather(currentWeatherData);
                }

                const forecastResponse = await weatherService.getDailyForecast({ city, days: 7 });
                if (forecastResponse.content) {
                    const forecastData: WeatherData[] = forecastResponse.content.map((day: any) => ({
                        id: day.id,
                        city: day.city,
                        countryCode: day.countryCode,
                        temperature: day.temperature ?? 0,
                        minTemperature: day.minTemperature ?? 0,
                        maxTemperature: day.maxTemperature ?? 0,
                        condition: day.condition || 'N/A',
                        date: new Date(day.date),
                    }));
                    setForecast(forecastData);
                }
            } catch (err) {
                console.error('Error fetching weather data:', err);
                setError('Error fetching weather data. Please try again later.');
            } finally {
                setLoading(false);
            }
        };

        fetchWeatherData();
    }, [city, weatherService]);

    return { currentWeather, forecast, error, loading };
};