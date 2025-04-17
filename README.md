# Tecoloco Technical Test

## Overview

This project is a solution for the Tecoloco technical test. It consists of a backend microservice developed in ASP.NET Core (.NET 8) and a front-end application built with React and TypeScript. The system integrates with an external weather data API to retrieve current and forecast weather information, specifically for San Salvador, and displays it in a user-friendly interface.

The project demonstrates proficiency in:
- Backend and frontend development.
- API integration.
- Implementation of caching and resilience strategies (e.g., circuit breaker).
- Robust error handling.
- Comprehensive unit and integration testing.

---

## Features

### Backend
- **RESTful Endpoints**:
  - `GET /weather/current`: Retrieves current weather data.
  - `GET /weather/forecast`: Retrieves a 7-day weather forecast.
- **Resilience and Optimization**:
  - Implements in-memory caching to prevent redundant API calls.
  - Circuit breaker pattern to gracefully handle API failures.
- **Data Persistence**:
  - Stores historical weather data using Entity Framework and relational database migrations.
- **Error Logging**:
  - Integrated Serilog for structured logging of operations, API calls, and errors.
- **Testing**:
  - Unit tests for core business logic.
  - Integration tests for API communication and database operations.

### Frontend
- **Responsive Interface**:
  - Displays weekly weather forecasts for San Salvador.
  - User-friendly and mobile-friendly design.
- **Functionality**:
  - Fetches weather data using backend endpoints.
  - Displays key details such as:
    - Date.
    - High/Low temperatures.
    - Weather condition (e.g., cloudy, sunny).
    - Graphical representation (e.g., weather icons).
  - Includes search functionality for querying weather data by city.

---

## Technologies Used

### Backend
- **Framework**: ASP.NET Core (.NET 8).
- **Database**: Entity Framework with a relational database.
- **Logging**: Serilog for structured logging.

### Frontend
- **Framework**: React with TypeScript.
- **Styling**: Tailwind CSS.

### Testing
- Unit and integration tests for both backend and frontend.

---

## Setup and Installation

### Prerequisites
- **Backend**:
  - [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher).
  - Relational database (e.g., SQL Server or PostgreSQL).
- **Frontend**:
  - [Node.js](https://nodejs.org/) (version 18 or higher).
  - [npm](https://www.npmjs.com/).

### Backend
1. Clone the repository:
   ```bash
   git clone https://github.com/xDaniel17/Tecoloco-Technical-Test.git
   ```
2. Navigate to the `backend` directory:
   ```bash
   cd Tecoloco-Technical-Test/backend
   ```
3. Set up the database:
   - Update the connection string in `appsettings.json`.
   - Apply migrations:
     ```bash
     dotnet ef database update
     ```
4. Run the backend:
   ```bash
   dotnet run
   ```

### Frontend
1. Navigate to the `frontend` directory:
   ```bash
   cd Tecoloco-Technical-Test/frontend
   ```
2. Install dependencies:
   ```bash
   npm install
   ```
3. Configure the backend URL:
   - Update the `REACT_APP_BACKEND_URL` in `.env` to point to the backend server.
4. Run the frontend:
   ```bash
   npm start
   ```

---

## How It Works

### Backend
- The backend exposes RESTful endpoints to fetch weather data from an external API (e.g., OpenWeatherMap).
- Responses are cached for 10 minutes to reduce redundant API calls.
- Implements a circuit breaker pattern to handle failures gracefully.

### Frontend
- The frontend communicates with the backend to fetch current weather and forecast data.
- Displays the data using a responsive and visually appealing user interface.

---

## Testing

### Backend
- Run the tests:
  ```bash
  dotnet test
  ```

### Frontend
- Run the tests:
  ```bash
  npm test
  ```



## Evaluation Criteria

1. **Code Quality**:
   - Clear, maintainable, and follows best practices.
2. **Technical Depth**:
   - Effective use of caching, circuit breaker patterns, and error handling.
3. **Testing Rigor**:
   - Comprehensive unit and integration tests.
4. **Integration**:
   - Seamless communication between backend and frontend.

---

## Author

**Douglas Daniel Herrera Magaña**  
- Email: [xdaniel.h@gmail.com](mailto:xdaniel.h@gmail.com)  
- LinkedIn: [LinkedIn Profile](https://www.linkedin.com/in/ddhm92/)  
- Phone: +503 7747 1284  

---