import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import Footer from '../components/Footer';
import Header from '../components/Header';

function Home() {
    const [city, setCity] = useState('');
    const navigate = useNavigate();

    const handleSearch = () => {
        if (city.trim() !== '') {
            navigate(`/weather/${city}`);
        } else {
            alert('Please enter the name of a city.');
        }
    };

    const handleKeyPress = (e: React.KeyboardEvent<HTMLInputElement>) => {
        if (e.key === 'Enter') {
            handleSearch();
        }
    };

    return (
        <>
            <div className="grid grid-rows-[auto_1fr_auto] min-h-screen">
                <Header />
                <main className="bg-gray-100 dark:bg-gray-900 text-gray-800 dark:text-gray-200">
                    <section className="flex justify-center min-h-full pt-40 px-6 lg:px-8">
                        <div className="text-center sm:w-full sm:max-w-md lg:max-w-lg">
                            <h1 className="text-3xl font-bold tracking-tight">
                                Enter the name of a city
                            </h1>
                            <div className="mt-8 flex flex-col items-center space-y-6">
                                <input
                                    type="text"
                                    placeholder="San Salvador, Paris, Madrid..."
                                    value={city}
                                    onChange={(e) => setCity(e.target.value)}
                                    onKeyDown={handleKeyPress}
                                    className="w-full px-6 py-4 text-lg border border-gray-300 dark:border-gray-700 rounded-lg shadow-md focus:outline-none focus:ring-2 focus:ring-blue-500 dark:bg-gray-800 dark:text-gray-200"
                                />
                                <button
                                    onClick={handleSearch}
                                    className="px-8 py-2 text-lg font-medium text-white bg-blue-500 rounded-lg hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 transition-colors"
                                >
                                    Search
                                </button>
                            </div>
                        </div>
                    </section>
                </main>
                <Footer />
            </div>
        </>
    );
}

export default Home;