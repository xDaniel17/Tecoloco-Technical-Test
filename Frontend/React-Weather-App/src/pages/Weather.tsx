import { useParams } from 'react-router-dom';
import { useEffect, useState } from 'react';
import Footer from '../components/Footer';
import Header from '../components/Header';
import { IWeatherService } from '../interfaces/IWeatherService';
import { WeatherData } from '../models/WeatherData';

const Weather = ({ weatherService }: { weatherService: IWeatherService }) => {
    const { id: city } = useParams();
    const [currentWeather, setCurrentWeather] = useState<WeatherData | null>(null);
    const [forecast, setForecast] = useState<WeatherData[] | null>(null);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        if (!city) return;

        const fetchWeatherData = async () => {
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
                setError('No se pudo obtener la información del clima.');
            }
        };

        fetchWeatherData();
    }, [city, weatherService]);

    const getWeatherIcon = (condition: string) => {
        if (condition.includes("Sunny")) return "☀️";
        if (condition.includes("Clear")) return "☀️";
        if (condition.includes("Cloudy")) return "☁️";
        if (condition.includes("Rain")) return "🌧️";
        if (condition.includes("Thunder")) return "⛈️";
        return "🌤️";
    };

    return (
        <>
            <div className="grid grid-rows-[auto_1fr_auto] min-h-screen">
                <Header />
                <main className="bg-gradient-to-b from-black to-[#2c1758] text-white">
                    <section className="flex flex-col items-center py-8 px-4">
                        {error ? (
                            <h1 className="text-2xl font-bold text-red-500">{error}</h1>
                        ) : (
                            <>
                                {currentWeather && (
                                    <div className="w-full max-w-md p-6 bg-gradient-to-b from-[#5a2d82] to-[#3b2961] rounded-lg shadow-lg text-center">
                                        <h2 className="text-lg font-medium uppercase tracking-wide text-gray-300 mb-2">
                                            Temperatura actual en
                                            <br />
                                            {currentWeather.city}, {currentWeather.countryCode}
                                        </h2>
                                        <div className="flex justify-center items-center gap-4 mb-4">
                                            <span className="text-7xl">
                                                {getWeatherIcon(currentWeather.condition!)}
                                            </span>
                                            <div className="text-5xl font-bold">
                                                {currentWeather.temperature}°<span className="text-4xl">C</span>
                                            </div>
                                        </div>
                                        <div className="text-sm flex justify-around mt-4">
                                            <div>
                                                <p className="uppercase text-gray-400">Min</p>
                                                <p className="text-lg font-semibold">{currentWeather.minTemperature}°C</p>
                                            </div>
                                            <div>
                                                <p className="uppercase text-gray-400">Max</p>
                                                <p className="text-lg font-semibold">{currentWeather.maxTemperature}°C</p>
                                            </div>
                                        </div>
                                    </div>
                                )}

                                {forecast && (
                                    <div className="w-full max-w-md mt-8">
                                        <ul>
                                            {forecast.map((day, index) => (
                                                <li
                                                    key={index}
                                                    className="flex justify-between items-center py-2 border-b border-gray-600"
                                                >
                                                    <div className="flex items-center gap-4">
                                                        <span className="text-2xl font-bold">
                                                            {getWeatherIcon(day.condition!)}
                                                        </span>
                                                        <span className="capitalize text-gray-300">
                                                            {new Date(day.date).toLocaleDateString("es-ES", {
                                                                weekday: "long",
                                                            })}
                                                        </span>
                                                    </div>
                                                    <div className="text-right">
                                                        <p className="text-lg font-semibold">
                                                            {day.maxTemperature}° / {day.minTemperature}°
                                                        </p>
                                                        <p className="text-sm text-gray-400">{day.condition}</p>
                                                    </div>
                                                </li>
                                            ))}
                                        </ul>
                                    </div>
                                )}
                            </>
                        )}
                    </section>
                </main>
                <Footer />
            </div>
        </>
    );
};

export default Weather;