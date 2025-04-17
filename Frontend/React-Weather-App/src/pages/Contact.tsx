import Footer from '../components/Footer';
import Header from '../components/Header';

function Contact() {
    return (
        <>
            <div className="grid grid-rows-[auto_1fr_auto] min-h-screen">
                <Header />
                <main className="bg-gray-100 dark:bg-gray-900 text-gray-800 dark:text-gray-200">
                    <section className="flex min-h-full flex-col items-center py-16 px-6 lg:px-8">
                        <div className="text-center sm:w-full sm:max-w-2xl lg:max-w-4xl">
                            <h1 className="text-4xl font-bold mb-6">Contact</h1>
                            <p className="text-lg mb-4">
                                Contact Information:
                            </p>
                            <div className="mt-8 space-y-6 text-left mx-auto max-w-md">
                                <div className="flex items-center">
                                    <span className="font-semibold w-32">Name:</span>
                                    <span>Douglas Daniel Herrera Magaña</span>
                                </div>
                                <div className="flex items-center">
                                    <span className="font-semibold w-32">Email:</span>
                                    <a
                                        href="mailto:xdaniel.h@gmail.com"
                                        className="text-blue-500 hover:underline"
                                    >
                                        xdaniel.h@gmail.com
                                    </a>
                                </div>
                                <div className="flex items-center">
                                    <span className="font-semibold w-32">Phone:</span>
                                    <a
                                        href="tel:+50377471284"
                                        className="text-blue-500 hover:underline"
                                    >
                                        +503 7747 1284
                                    </a>
                                </div>
                                <div className="flex items-center">
                                    <span className="font-semibold w-32">Profession:</span>
                                    <span>Computer Science Engineer</span>
                                </div>
                                <div className="flex items-center">
                                    <span className="font-semibold w-32">Master's Degree:</span>
                                    <span>Software Architecture</span>
                                </div>
                                <div className="flex items-center">
                                    <span className="font-semibold w-32">Experience:</span>
                                    <span>Over 9 years of experience in software development</span>
                                </div>
                            </div>
                        </div>
                    </section>
                </main>
                <Footer />
            </div>
        </>
    );
}

export default Contact;