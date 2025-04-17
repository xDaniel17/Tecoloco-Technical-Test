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
            alert('Por favor, ingrese el nombre de una ciudad.');
        }
    };

    return (
        <>
            <div className="grid grid-rows-[auto_1fr_auto] min-h-screen">
                <Header></Header>
                <main className="bg-white dark:bg-[rgb(50,54,59,1)] text-black dark:text-white">
                    <section className="flex justify-center min-h-full pt-52 px-6 lg:px-8">
                        <div className="text-center sm:w-full sm:max-w-md lg:max-w-lg">
                            <h1 className="text-3xl font-bold tracking-tight text-black dark:text-white">
                                Digite el nombre de una ciudad
                            </h1>
                            <div className="mt-8 flex flex-col items-center space-y-6">
                                <input
                                    type="text"
                                    placeholder="San Salvador, Paris, Madrid..."
                                    value={city}
                                    onChange={(e) => setCity(e.target.value)}
                                    className="w-full px-6 py-4 text-lg border border-gray-300 rounded-lg shadow-md focus:outline-none focus:ring-2 focus:ring-pink-500 dark:bg-gray-800 dark:border-gray-700 dark:text-white"
                                />
                                <button
                                    onClick={handleSearch}
                                    className="px-8 py-2 text-lg font-medium text-white bg-pink-500 rounded-lg hover:bg-pink-600 focus:outline-none focus:ring-2 focus:ring-pink-500"
                                >
                                    Consultar
                                </button>
                            </div>
                        </div>
                    </section>
                </main>
                <Footer></Footer>
            </div>
        </>
    );
}

export default Home;