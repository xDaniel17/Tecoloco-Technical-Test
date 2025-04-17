import { useState } from 'react';
import '../styles/Header.css';

export const Header = () => {
    const [mobileNavOpen, setMobileNavOpen] = useState(false);
    const [darkMode, setDarkMode] = useState(false);

    const toggleDarkMode = () => {
        setDarkMode(!darkMode);
        document.documentElement.classList.toggle('dark', !darkMode);
    };

    return (
        <header className="relative bg-pink-200 dark:bg-[rgb(128,216,208)]">
            <nav className="py-6">
                <div className="container mx-auto px-4 flex items-center justify-between">
                    <a href="/home" className="inline-block">
                        <img className="mx-auto w-32 dark:hidden" src="/DD_logo_light.png" alt="Logo" />
                        <img className="mx-auto w-32 hidden dark:block" src="/DD_logo_dark.png" alt="Logo" />
                    </a>
                    <ul className="hidden md:flex space-x-8">
                        <li className="hover:scale-105">
                            <a className="text-white hover:text-pink-500 text-xl" href="/home">Home</a>
                        </li>
                        <li className="hover:scale-105">
                            <a className="text-white hover:text-pink-500 text-xl" href="/about">About</a>
                        </li>
                        <li className="hover:scale-105">
                            <a className="text-white hover:text-pink-500 text-xl" href="/contact">Contact</a>
                        </li>
                    </ul>
                    <div className="flex items-center space-x-4">
                        <button
                            className="hidden md:inline-block py-2.5 px-4 font-medium text-white border border-white hover:bg-white hover:text-pink-500 rounded-full transition duration-200"
                            onClick={toggleDarkMode}
                        >
                            {darkMode ? 'Light Mode' : 'Dark Mode'}
                        </button>
                        <button
                            className="md:hidden text-white"
                            onClick={() => setMobileNavOpen(!mobileNavOpen)}
                        >
                            <svg width="32" height="32" viewBox="0 0 32 32" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path d="M5.19995 23.2H26.7999" stroke="currentColor" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"></path>
                                <path d="M5.19995 16H26.7999" stroke="currentColor" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"></path>
                                <path d="M5.19995 8.79999H26.7999" stroke="currentColor" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"></path>
                            </svg>
                        </button>
                    </div>
                </div>
            </nav>
            {mobileNavOpen && (
                <div className="fixed inset-0 z-50 md:hidden">
                    <nav className="fixed top-0 left-0 bottom-0 w-full max-w-xs bg-pink-200 dark:bg-[rgb(128,216,208)] border-r-1 border-white rounded-2xl p-4">
                        <div className="flex items-center justify-between mb-4">
                            <a href="/home" className="inline-block">
                                <img className="mx-auto w-32 dark:hidden" src="/DD_logo_light.png" alt="Logo" />
                                <img className="mx-auto w-32 hidden dark:block" src="/DD_logo_dark.png" alt="Logo" />
                            </a>
                            <button onClick={() => setMobileNavOpen(false)} className="text-white">
                                <svg width="32" height="32" viewBox="0 0 32 32" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M23.2 8.79999L8.80005 23.2M8.80005 8.79999L23.2 23.2" stroke="currentColor" strokeWidth="1.5" strokeLinecap="round" strokeLinejoin="round"></path>
                                </svg>
                            </button>
                        </div>
                        <ul className="space-y-6 pt-5">
                            <li className="hover:scale-105">
                                <a className="text-white hover:text-pink-500 text-xl" href="/home">Home</a>
                            </li>
                            <li className="hover:scale-105">
                                <a className="text-white hover:text-pink-500 text-xl" href="/about">About</a>
                            </li>
                            <li className="hover:scale-105">
                                <a className="text-white hover:text-pink-500 text-xl" href="/contact">Contact</a>
                            </li>
                            <li className="hover:scale-105">
                                <button className="text-white hover:text-pink-500 text-xl" onClick={toggleDarkMode}>
                                    {darkMode ? 'Light Mode' : 'Dark Mode'}
                                </button>
                            </li>
                        </ul>
                    </nav>
                </div>
            )}
        </header>
    );
};

export default Header;