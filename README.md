# КІНОТЕКА — практична робота №6

Мобільний каталог фільмів і серіалів на .NET MAUI (Android). Проєкт розширює роботу №5 сторінкою детальної інформації та модальним переходом між сторінками.

## Реалізовано
- Вибір одного елемента `CollectionView` (`SelectionMode="Single"`).
- Передавання вибраної моделі `Movie` через `SelectionChangedCommandParameter`.
- Окрема сторінка `DetailsPage` з постером, назвою, роком, рейтингом, описом та IMDb ID.
- `NavigationService` для відкриття деталей через `PushModalAsync`.
- Повернення до каталогу через `PopModalAsync`.
- Очищення `SelectedMovie` після повернення, щоб повторний тап по тому самому фільму працював.
- Автоматична збірка Android APK через GitHub Actions.

## Вимоги
- .NET 10 SDK
- workload `maui-android`
- Android SDK (для локальної збірки)
- Visual Studio 2022/2026 з компонентом .NET MAUI або .NET CLI

## Запуск у Visual Studio
1. Відкрийте `MovieCatalogApp.csproj`.
2. Дочекайтеся відновлення NuGet-пакетів.
3. Виберіть Android Emulator або підключений Android-пристрій.
4. Запустіть проєкт.

Каталог отримує дані з `https://api.imdbapi.dev/`, тому для завантаження списку потрібен інтернет.

## Збірка APK локально
У терміналі з каталогу проєкту:
```bash
dotnet workload install maui-android
dotnet restore MovieCatalogApp.csproj
dotnet publish MovieCatalogApp.csproj -f net10.0-android -c Debug -p:AndroidPackageFormat=apk -o ./artifacts/android
```
APK буде у `artifacts/android/`.

## Завантаження на GitHub і отримання APK
1. Створіть порожній репозиторій на GitHub.
2. Розпакуйте архів і відкрийте термінал у папці `MovieCatalogApp`.
3. Виконайте:
```bash
git init
git add .
git commit -m "Практична робота 6: сторінка деталей і навігація"
git branch -M main
git remote add origin https://github.com/ВАШ_ЛОГІН/НАЗВА_РЕПОЗИТОРІЮ.git
git push -u origin main
```
4. На GitHub відкрийте вкладку **Actions**. Workflow **Build Android APK** запускається автоматично після push (або натисніть **Run workflow**).
5. Відкрийте успішний запуск workflow, унизу в **Artifacts** завантажте `MovieCatalogApp-Android-APK`. Розпакуйте завантажений artifact — усередині буде APK.

## Структура
- `Models/` — модель фільму.
- `Views/` — головна сторінка та сторінка деталей.
- `ViewModels/` — логіка головного каталогу.
- `Services/` — API та сервіс навігації.
- `Controls/` — картка фільму.
- `.github/workflows/` — автоматична Android-збірка.

## Примітка щодо доказових скриншотів
У звітному архіві є ілюстративні макети двох екранів із позначкою «МАКЕТ». Це не скриншоти запущеного Android-застосунку. Для підтвердження фактичного запуску зробіть скриншоти емулятора/телефону після запуску проєкту та додайте їх до звіту.
