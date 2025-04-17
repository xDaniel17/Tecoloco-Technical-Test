export const Footer = () => {
    const currentYear = new Date().getFullYear();
    return (
        <footer
            aria-label="Footer"
            className="py-6 bg-gray-100 dark:bg-gray-900 border-t border-gray-300 dark:border-gray-700"
        >
            <div className="container mx-auto px-4 text-gray-700 dark:text-gray-300 text-center">
                <p className="text-sm">&copy; {currentYear} Developed by Daniel Herrera</p>
            </div>
        </footer>
    );
};

export default Footer;