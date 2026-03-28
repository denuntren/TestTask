# У проєкті реалізовані:
- UI автотести (Selenium)
- API автотести (HttpClient + JSON)

---

## UI частина

Що робить тест:

- відкриває https://www.saucedemo.com/
- логіниться
- сортує товари (Price high → low)
- знаходить товар "Sauce Labs Bike Light"
- перевіряє назву і ціну:
    - у списку
    - у деталях
    - у корзині
- додає товар у корзину
- перевіряє, що товар доданий

Використано:
- Selenium WebDriver
- NUnit
- Page Object Pattern

---

## API частина

Реалізовано POST запит:
POST /client


Що перевіряється:

- статус код = 200
- відповідь містить ті ж дані, що і в запиті
- повертається id

Використано:
- HttpClient
- Newtonsoft.Json
- NUnit

---

## Важливо

API endpoint `https://test.lan` недоступний у моєму середовищі, тому тести не виконуються.
