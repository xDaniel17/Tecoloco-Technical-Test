import Footer from '../components/Footer';
import Header from '../components/Header';
import { useNavigate } from 'react-router-dom';

function NotFound() {
    const navigate = useNavigate();

    const handleGoHome = () => {
        navigate('/');
    };

    return (
        <>
            <div className="grid grid-rows-[auto_1fr_auto] min-h-screen">
                <Header />
                <main className="bg-gray-100 dark:bg-gray-900 text-gray-800 dark:text-gray-200">
                    <section className="flex flex-col items-center justify-center min-h-full py-16 px-6 lg:px-8">
                        <div className="text-center">
                            <h1 className="text-5xl font-bold tracking-tight mb-6">
                                404 - Page Not Found
                            </h1>
                            <p className="text-lg mb-8">
                                Sorry, the page you are looking for does not exist.
                            </p>
                            <button
                                onClick={handleGoHome}
                                className="px-8 py-3 text-lg font-medium text-white bg-blue-500 rounded-lg hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 transition-colors"
                            >
                                Go back to Home
                            </button>
                        </div>
                    </section>
                </main>
                <Footer />
            </div>
        </>
    );
}

export default NotFound;