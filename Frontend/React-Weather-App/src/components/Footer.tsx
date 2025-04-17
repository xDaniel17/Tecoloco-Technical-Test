
export const Footer = () => {
    const currentYear = new Date().getFullYear();
    return (
        <footer aria-label="Footer" className="py-8 bg-pink-200 dark:bg-[rgb(128,216,208)]">
            <div className="container mx-auto md:px-16 text-white text-center">
                <p>&copy; {currentYear} Developed by Team DD</p>
            </div>
        </footer>
    );
};

export default Footer;