import { useState } from 'react';
import '../styles/Header.css';

export const Header = () => {
    const [mobileNavOpen, setMobileNavOpen] = useState(false);

    return (
        <header className="relative bg-gray-100 dark:bg-gray-900">
            <nav className="py-4 border-b border-gray-200 dark:border-gray-700">
                <div className="container mx-auto px-4 flex items-center justify-between">
                    <a href="/home" className="inline-block">
                        <img className="mx-auto w-32 dark:hidden" src="https://www.tecoloco.com.sv/img/logos/logo-tecoloco-sv.svg" alt="Logo" />
                        <img className="mx-auto w-32 hidden dark:block" src="https://www.tecoloco.com.sv/img/logos/logo-tecoloco-sv.svg" alt="Logo" />
                    </a>
                    <ul className="hidden md:flex space-x-8">
                        <li className="hover:scale-105 transition-transform">
                            <a className="text-gray-800 dark:text-gray-200 hover:text-blue-500 dark:hover:text-blue-400 text-lg font-medium" href="/home">Home</a>
                        </li>
                        <li className="hover:scale-105 transition-transform">
                            <a className="text-gray-800 dark:text-gray-200 hover:text-blue-500 dark:hover:text-blue-400 text-lg font-medium" href="/about">About</a>
                        </li>
                        <li className="hover:scale-105 transition-transform">
                            <a className="text-gray-800 dark:text-gray-200 hover:text-blue-500 dark:hover:text-blue-400 text-lg font-medium" href="/contact">Contact</a>
                        </li>
                    </ul>
                    <button
                        onClick={() => setMobileNavOpen(!mobileNavOpen)}
                        className="md:hidden text-gray-800 dark:text-gray-200 hover:text-blue-500 dark:hover:text-blue-400"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            className="h-8 w-8"
                            fill="none"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                        >
                            <path
                                strokeLinecap="round"
                                strokeLinejoin="round"
                                strokeWidth={2}
                                d="M4 6h16M4 12h16m-7 6h7"
                            />
                        </svg>
                    </button>
                </div>
            </nav>
            {mobileNavOpen && (
                <div className="fixed inset-0 z-50 md:hidden">
                    <nav className="fixed top-0 left-0 bottom-0 w-full max-w-xs bg-gray-100 dark:bg-gray-900 border-r border-gray-200 dark:border-gray-700 p-6">
                        <div className="flex items-center justify-between mb-4">
                            <a href="#" className="inline-block">
                                { }
                                <img className="mx-auto w-32 dark:hidden" src="https://www.tecoloco.com.sv/img/logos/logo-tecoloco-sv.svg" alt="Logo" />
                                <img className="mx-auto w-32 hidden dark:block" src="https://www.tecoloco.com.sv/img/logos/logo-tecoloco-sv.svg" alt="Logo" />
                            </a>
                            <button
                                onClick={() => setMobileNavOpen(false)}
                                className="text-gray-800 dark:text-gray-200 hover:text-blue-500 dark:hover:text-blue-400"
                            >
                                <svg width="32" height="32" viewBox="0 0 32 32" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <path
                                        d="M23.2 8.79999L8.80005 23.2M8.80005 8.79999L23.2 23.2"
                                        stroke="currentColor"
                                        strokeWidth="1.5"
                                        strokeLinecap="round"
                                        strokeLinejoin="round"
                                    ></path>
                                </svg>
                            </button>
                        </div>
                        <ul className="space-y-6 pt-5">
                            <li className="hover:scale-105 transition-transform">
                                <a className="text-gray-800 dark:text-gray-200 hover:text-blue-500 dark:hover:text-blue-400 text-lg font-medium" href="/home">Home</a>
                            </li>
                            <li className="hover:scale-105 transition-transform">
                                <a className="text-gray-800 dark:text-gray-200 hover:text-blue-500 dark:hover:text-blue-400 text-lg font-medium" href="/about">About</a>
                            </li>
                            <li className="hover:scale-105 transition-transform">
                                <a className="text-gray-800 dark:text-gray-200 hover:text-blue-500 dark:hover:text-blue-400 text-lg font-medium" href="/contact">Contact</a>
                            </li>
                        </ul>
                    </nav>
                </div>
            )}
        </header>
    );
};

export default Header;