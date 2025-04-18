import { test, expect } from '@playwright/test';

test.describe('Weather Page E2E Tests', () => {
    const mockCity = 'San Salvador';

    test.beforeEach(async ({ page }) => {
        await page.goto(`http://localhost:5173/weather/${encodeURIComponent(mockCity)}`);
    });

    test('should display loading spinner while fetching data', async ({ page }) => {
        const loadingText = page.locator('text=Loading...');
        await expect(loadingText).toBeVisible();
    });

    test('should display current weather and forecast when data is loaded', async ({ page }) => {
        const loadingText = page.locator('text=Loading...');
        await loadingText.waitFor({ state: 'hidden' });

        const weatherCard = page.locator('div[data-testid="weather-card"]');
        await expect(weatherCard).toBeVisible();

        const forecastList = page.locator('div[data-testid="forecast-list"]');
        await expect(forecastList).toBeVisible();
    });

    test('should display error message when API fails', async ({ page }) => {
        const invalidCity = '12345';
        await page.goto(`http://localhost:5173/weather/${encodeURIComponent(invalidCity)}`);

        const loadingText = page.locator('text=Loading...');
        await loadingText.waitFor({ state: 'hidden' });

        const errorMessage = page.locator('text=Please check the city name and try again.');
        const errorHeading = page.locator('h1.text-red-500');
        await expect(errorHeading).toHaveText('Error fetching weather data. Please try again later.');
        await expect(errorMessage).toBeVisible();
    });
});