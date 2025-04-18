# Tecoloco Technical Test

## Overview

This repository contains the solution for the Tecoloco technical test, which includes a backend microservice developed with **ASP.NET Core (.NET 8)** and a frontend application built using **React** and **TypeScript**. The application integrates with an external weather API to display current and forecast weather data for various cities, with a primary focus on **San Salvador**.

This project demonstrates:
- Full-stack development proficiency.
- Integration with third-party APIs.
- Implementation of caching and resilience strategies (e.g., **circuit breaker**).
- Robust error handling and logging.
- Comprehensive **unit and integration testing** for both frontend and backend.

---

## Features

### Backend
- **RESTful API Endpoints**:
  - `GET /weather/current`: Fetches current weather data.
  - `GET /weather/forecast`: Fetches a 7-day weather forecast.
- **Resilience and Optimization**:
  - Implements **in-memory caching** to reduce redundant API calls.
  - Uses the **circuit breaker pattern** to gracefully handle external API failures.
- **Data Persistence**:
  - Historical weather data storage using **Entity Framework** and relational database migrations.
- **Structured Logging**:
  - Integrated **Serilog** for structured logging of operations, API calls, and errors.
- **Testing**:
  - Comprehensive **unit tests** for business logic.
  - **Integration tests** for API communication and database interactions.

### Frontend
- **Responsive UI**:
  - Displays current weather and 7-day forecasts.
  - Mobile-friendly and accessible interface.
- **Features**:
  - Search functionality to fetch weather data for any city.
  - Displays:
    - Date and day of the week.
    - High/low temperatures.
    - Weather conditions (e.g., cloudy, sunny, rainy).
  - Dynamic weather icons for better visualization.
- **Error Handling**:
  - Gracefully handles errors such as invalid city names or API issues with user-friendly messages.

---

## Technologies Used

### Backend
- **Framework**: ASP.NET Core (.NET 8)
- **Database**: Entity Framework with SQL Server/PostgreSQL
- **Logging**: Serilog for structured logging
- **Resilience**: Polly for circuit breaker implementation

### Frontend
- **Framework**: React with TypeScript
- **Styling**: Tailwind CSS
- **State Management**: React Hooks

### Testing
- **Backend**: xUnit and Moq for unit and integration tests
- **Frontend**: Jest and React Testing Library for unit tests

---

## Setup and Installation

### Prerequisites
- **Backend**:
  - [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher)
  - Relational database (e.g., SQL Server or PostgreSQL)
- **Frontend**:
  - [Node.js](https://nodejs.org/) (version 18 or higher)
  - [npm](https://www.npmjs.com/)

---

### Backend Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/xDaniel17/Tecoloco-Technical-Test.git
   ```
2. Navigate to the backend directory:
   ```bash
   cd Tecoloco-Technical-Test/backend
   ```
3. Configure the database:
   - Update the connection string in `appsettings.json`.
   - Apply migrations:
     ```bash
     dotnet ef database update
     ```
4. Run the backend server:
   ```bash
   dotnet run
   ```

### Frontend Setup
1. Navigate to the frontend directory:
   ```bash
   cd Tecoloco-Technical-Test/frontend
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Configure the backend URL:
   - Create a `.env` file and set the `REACT_APP_BACKEND_URL` variable:
     ```
     REACT_APP_BACKEND_URL=http://localhost:5000
     ```
4. Run the frontend development server:
   ```bash
   npm start
   ```

---

## How It Works

### Backend
- The backend communicates with an external weather API (e.g., OpenWeatherMap) to fetch real-time weather data and forecasts.
- The API responses are cached for **10 minutes** using in-memory caching to optimize performance.
- Implements a **circuit breaker pattern** to handle external API downtime gracefully.

### Frontend
- The frontend sends requests to the backend to fetch weather data.
- It renders the data in a visually appealing and responsive interface, showing:
  - **Current weather**: Displays the temperature, condition, and city.
  - **7-day forecast**: Displays daily high/low temperatures and conditions.

---

## Testing

### Backend
Run the backend tests:
```bash
dotnet test
```

### Frontend
Run the frontend tests:
```bash
npx playwright test
```

---

## Deployment

### Backend
1. Build the project:
   ```bash
   dotnet publish -c Release -o ./publish
   ```
2. Deploy the `publish` folder to your preferred server or cloud provider.

### Frontend
1. Build the production-ready application:
   ```bash
   npm run build
   ```
2. Deploy the `build` folder to your preferred hosting provider.

---

## Author

**Douglas Daniel Herrera Magaña**  
- **Email**: [xdaniel.h@gmail.com](mailto:xdaniel.h@gmail.com)  
- **LinkedIn**: [LinkedIn Profile](https://www.linkedin.com/in/ddhm92/)  
- **Phone**: +503 7747 1284  

---