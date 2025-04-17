import Footer from '../components/Footer';
import Header from '../components/Header';

function About() {
    return (
        <>
            <div className="grid grid-rows-[auto_1fr_auto] min-h-screen">
                <Header />
                <main className="bg-gray-100 dark:bg-gray-900 text-gray-800 dark:text-gray-200">
                    <section className="flex min-h-full flex-col py-16 px-6 lg:px-8">
                        <div className="sm:mx-auto sm:w-full sm:max-w-2xl lg:max-w-4xl text-center">
                            <h1 className="text-4xl font-bold mb-6">About the Project</h1>
                            <p className="text-lg mb-4">
                                This project is a technical solution that integrates a microservice in ASP.NET Core with a front-end application to display the weekly weather forecast for San Salvador.
                            </p>
                            <p className="text-lg mb-4">
                                The application uses an external API to retrieve current weather data and forecasts, implementing resilience strategies such as caching and a circuit breaker pattern to handle API failures.
                            </p>
                            <p className="text-lg mb-4">
                                The goal is to ensure a smooth and reliable user experience by providing a responsive and user-friendly interface for checking the weather.
                            </p>
                            <h2 className="text-2xl font-semibold mt-8 mb-4">Features</h2>
                            <ul className="list-disc list-inside text-left mx-auto max-w-prose">
                                <li>ASP.NET Core microservice with RESTful endpoints.</li>
                                <li>Integration with an external weather data API.</li>
                                <li>Caching to optimize performance.</li>
                                <li>Error management with robust exception handling.</li>
                                <li>Responsive user interface developed in React.</li>
                            </ul>
                            <h2 className="text-2xl font-semibold mt-8 mb-4">Technologies Used</h2>
                            <ul className="list-disc list-inside text-left mx-auto max-w-prose">
                                <li>Backend: ASP.NET Core (.NET 8), Entity Framework.</li>
                                <li>Frontend: React with Tailwind CSS.</li>
                                <li>Testing: Unit and integration tests.</li>
                            </ul>
                        </div>
                    </section>
                </main>
                <Footer />
            </div>
        </>
    );
}

export default About;