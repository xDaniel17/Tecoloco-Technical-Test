import { test, expect } from '@playwright/test';

test.describe('Home Page E2E Tests', () => {
    test.beforeEach(async ({ page }) => {
        await page.goto('http://localhost:5173');
    });

    test('should display input field and search button', async ({ page }) => {
        const inputField = page.locator('input[placeholder="San Salvador, Paris, Madrid..."]');
        const searchButton = page.locator('button:has-text("Search")');

        await expect(inputField).toBeVisible();
        await expect(searchButton).toBeVisible();
    });

    test('should navigate to weather page when a city is entered and search is clicked', async ({ page }) => {
        const cityName = 'San Salvador';

        await page.fill('input[placeholder="San Salvador, Paris, Madrid..."]', cityName);

        await page.click('button:has-text("Search")');

        await expect(page).toHaveURL(`http://localhost:5173/weather/${encodeURIComponent(cityName)}`);
    });

    test('should display an alert when search is clicked without entering a city', async ({ page }) => {
        page.on('dialog', async (dialog) => {
            expect(dialog.message()).toBe('Please enter the name of a city.');
            await dialog.dismiss();
        });

        await page.click('button:has-text("Search")');
    });

    test('should trigger search when pressing Enter key after typing a city', async ({ page }) => {
        const cityName = 'Madrid';

        const inputField = page.locator('input[placeholder="San Salvador, Paris, Madrid..."]');
        await inputField.fill(cityName);
        await inputField.press('Enter');

        await expect(page).toHaveURL(`http://localhost:5173/weather/${encodeURIComponent(cityName)}`);
    });
});