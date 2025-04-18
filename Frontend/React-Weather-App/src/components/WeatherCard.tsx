import { WeatherData } from '../models/WeatherData';

const WeatherCard = ({ weather }: { weather: WeatherData }) => {
    const getWeatherIcon = (condition: string) => {
        if (condition.includes("sunny")) return "☀️";
        if (condition.includes("clear")) return "☀️";
        if (condition.includes("cloudy")) return "☁️";
        if (condition.includes("rain")) return "🌧️";
        if (condition.includes("thunder")) return "⛈️";
        return "🌤️";
    };

    return (
        <div className="w-full max-w-md p-6 bg-gray-200 dark:bg-gray-800 rounded-lg shadow-lg text-center" data-testid="weather-card">
            <h2 className="text-lg font-medium uppercase tracking-wide text-gray-700 dark:text-gray-300 mb-2">
                Current temperature in
                <br />
                {weather.city}, {weather.countryCode}
            </h2>
            <div className="flex justify-center items-center gap-4 mb-4">
                <span className="text-7xl">{getWeatherIcon(weather.condition!)}</span>
                <div className="text-5xl font-bold">
                    {weather.temperature}°<span className="text-4xl">C</span>
                </div>
            </div>
            <div className="text-sm flex justify-around mt-4">
                <div>
                    <p className="uppercase text-gray-600 dark:text-gray-400">Min</p>
                    <p className="text-lg font-semibold">{weather.minTemperature}°C</p>
                </div>
                <div>
                    <p className="uppercase text-gray-600 dark:text-gray-400">Max</p>
                    <p className="text-lg font-semibold">{weather.maxTemperature}°C</p>
                </div>
            </div>
        </div>
    );
};

export default WeatherCard;