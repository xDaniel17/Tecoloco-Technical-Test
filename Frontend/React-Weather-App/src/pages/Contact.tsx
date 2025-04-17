import Footer from '../components/Footer';
import Header from '../components/Header';

function Contact() {

    return (
        <>
            <div className="grid grid-rows-[auto_1fr_auto] min-h-screen">
                <Header></Header>
                <main className='bg-white dark:bg-[rgb(50,54,59,1)] text-black dark:text-white'>
                    <section className="flex min-h-full flex-col py-16 px-6 lg:px-8">
                        <div className="sm:mx-auto sm:w-full sm:max-w-2xl lg:max-w-4xl">
                            <h1 className="mt-10 text-center text-2xl font-bold tracking-tight text-black dark:text-white">
                                Weather Forecast for the
                                Current Week in San Salvador
                            </h1>
                        </div>
                    </section>
                </main>
                <Footer></Footer>
            </div>
        </>
    )
}

export default Contact
