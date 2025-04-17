export const NotFound = ({ message }: { message: string }) => {
    return (
        <div className="text-center">
            <h1 className="text-2xl font-bold text-red-500">{message}</h1>
            <p className="text-lg text-gray-700 dark:text-gray-200 mt-4">
                Please check the city name and try again.
            </p>
        </div>
    );
};

export default NotFound;