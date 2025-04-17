import { useParams } from 'react-router-dom';
import { useWeather } from '../hooks/useWeather';
import Footer from '../components/Footer';
import Header from '../components/Header';
import Loading from '../components/Loading';
import NotFound from '../components/NotFound';
import WeatherCard from '../components/WeatherCard';
import ForecastList from '../components/ForecastList';
import { IWeatherService } from '../interfaces/IWeatherService';

const Weather = ({ weatherService }: { weatherService: IWeatherService }) => {
    const { id: city } = useParams();
    const { currentWeather, forecast, error, loading } = useWeather(city, weatherService);

    return (
        <>
            <div className="grid grid-rows-[auto_1fr_auto] min-h-screen">
                <Header />
                <main className="bg-gray-100 dark:bg-gray-900 text-gray-800 dark:text-gray-200">
                    <section className="flex flex-col items-center py-8 px-4">
                        {loading && <Loading />}
                        {error && <NotFound message={error} />}
                        {!loading && !error && currentWeather && <WeatherCard weather={currentWeather} />}
                        {!loading && !error && forecast && <ForecastList forecast={forecast} />}
                    </section>
                </main>
                <Footer />
            </div>
        </>
    );
};

export default Weather;