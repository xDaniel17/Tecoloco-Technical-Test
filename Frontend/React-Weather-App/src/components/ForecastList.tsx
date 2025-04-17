import { WeatherData } from '../models/WeatherData';

const ForecastList = ({ forecast }: { forecast: WeatherData[] }) => {
    const getWeatherIcon = (condition: string) => {
        if (condition.includes("sunny")) return "☀️";
        if (condition.includes("clear")) return "☀️";
        if (condition.includes("cloudy")) return "☁️";
        if (condition.includes("rain")) return "🌧️";
        if (condition.includes("thunder")) return "⛈️";
        return "🌤️";
    };

    return (
        <div className="w-full max-w-md mt-8">
            <ul>
                {forecast.map((day, index) => (
                    <li
                        key={index}
                        className="flex justify-between items-center py-2 border-b border-gray-300 dark:border-gray-700"
                    >
                        <div className="flex items-center gap-4">
                            <span className="text-2xl font-bold">{getWeatherIcon(day.condition!)}</span>
                            <span className="capitalize text-gray-700 dark:text-gray-300">
                                {new Date(day.date).toLocaleDateString("en-US", {
                                    weekday: "long",
                                })}
                            </span>
                        </div>
                        <div className="text-right">
                            <p className="text-lg font-semibold">
                                {day.maxTemperature}° / {day.minTemperature}°
                            </p>
                            <p className="text-sm text-gray-600 dark:text-gray-400">{day.condition}</p>
                        </div>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ForecastList;