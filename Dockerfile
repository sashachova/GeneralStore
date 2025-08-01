FROM ubuntu:22.04

# Встановлюємо всі потрібні пакети
RUN apt-get update && apt-get install -y \
    openjdk-17-jdk \
    wget curl unzip \
    adb \
    git \
    libnss3 \
    gnupg lsb-release ca-certificates software-properties-common \
    && apt-get clean

# Встановлюємо Node.js 18 і Appium
RUN curl -fsSL https://deb.nodesource.com/setup_18.x | bash - && \
    apt-get install -y nodejs && \
    npm install -g appium && \
    appium driver install uiautomator2

# Встановлюємо .NET SDK 8.0.100
RUN wget https://dot.net/v1/dotnet-install.sh && \
    chmod +x dotnet-install.sh && \
    ./dotnet-install.sh --version 8.0.100 --install-dir /usr/share/dotnet

# Додаємо .NET у PATH
ENV PATH="/usr/share/dotnet:$PATH"

# Копіюємо всі файли проєкту
WORKDIR /app
COPY . .

# Запуск Appium + підключення до реального пристрою + запуск тестів
CMD ["sh", "-c", "nohup appium --port 4725 > appium.log 2>&1 & sleep 10 && adb connect 192.168.50.171:5555 && adb install -r ./General-Store.apk && dotnet test --no-build --logger \"console;verbosity=detailed\" && cat appium.log"]


