# ( БЕТА ВЕРСИЯ. ПРОГРАММА НА СТАДИИ РАЗРАБОТКИ )
# MSteerHelp

**MSteerHelp** — это инструмент для улучшения управления в игре Assetto Corsa, позволяя игрокам использовать мышь для управления автомобилем. Проект включает в себя эмуляцию руля и помощник для управления мышью, созданный для обеспечения более натурального и интуитивного управления.

## Основные Функциональности
- Управление автомобилем с помощью мыши с функцией самовозрата по энерции автомобиля.
- Плавное нажатие педали газа.
- ABS ( кпнока Вкл/Выкл) 
- Настройка чувствительности мыши через графический интерфейс.
- Настройка чувствительности и интенсивности сопративления руля через стандартные настройки (FFB) в игре Assetto Corsa
  
*******************************************************************************************************************************************************************************************************************************************
## Установка Вариант 1
1. Скачайте и распакуйте архив - ![Beta2](https://github.com/Tr1stx/MSteerHelp/raw/master/Beta2.zip)
2. Установите Vjoy
3. Запустите MSteerHelp.exe от имени Администратора - ВАЖНО

## Установка Вариант 2
1. Склонируйте репозиторий или загрузите архив с последней версией проекта.
2. Откройте проект в Visual Studio и соберите его.
3. Скачайте и подключите библиотеку "assettocorsasharedmemory"  *
4. Запустите исполняемый файл и настройте параметры через предложенный графический интерфейс.

*******************************************************************************************************************************************************************************************************************************************
## Настройка Assetto Corsa ( Рекомендуется ВАРИАНТ 1 )  
 Рекомендуемые настройки помощи внутри игры - ![image](https://github.com/Tr1stx/MSteerHelp/assets/71893240/8d30a3ed-ce13-4ede-b2ae-8f2ccee09fe6)



   Вариант 1 (готовые профили)
1. CSP (FFB) - https://acstuff.ru/s/H9jRyW
2. AssettoCorsa управление (ТОЛЬКО ДЛЯ РУЛЯ) - https://acstuff.ru/s/XGxkjz

Вариант 2(скриншоты)

ВАЖНО- ДЛЯ ТОГО ЧТО БЫ НАЗНАЧИТЬ ОСИ VJOY НУЖНО ЗАПУСТИТЬ MSteerHelp 
НАЖАТЬ НА НУЖНУЮ ОСЬ - НАЖАТЬ "TAB" - НАЗНАЧИТ КНОПКУ - НАЖАТЬ СНОВА "TAB" И НАЗНАЧИТ СЛЕДУЮЩУЮ ОСЬ В ТАКОМ ЖЕ ПОРЯДКЕ.
( НАЗНАЧЕНИЕ КНОПОК СМОТРЕТЬ НИЖЕ) -![image](https://github.com/Tr1stx/MSteerHelp/assets/71893240/de09e7c1-ac82-46a5-a282-f060521ee2d0)



1. CSP (FFB) - ![CustomShaderSetting](https://github.com/Tr1stx/MSteerHelp/assets/71893240/cf25691d-d77a-4fae-9c1d-a885a84877f4)


2. AssettoCorsa управление (ТОЛЬКО ДЛЯ РУЛЯ) - ![IngameSetting](https://github.com/Tr1stx/MSteerHelp/assets/71893240/19ff9ed0-913f-402c-af7c-48d3a18fee63)

3. ОБЯЗАТЕЛЬНО - назачения переключения скоростей.


## Инструкция использывания 
1. После запуска MSteerHelp.exe появиться окно с настройкой чувствительности и ваш курсор уйдет влевый нижний экран , это означает что все запустилось.
2. Нажмите "TAB" для освобождения курсора мышки и запустите Assetto Corsa.
3. Для повторного включения снова нажмите "TAB".

   
***************************************************************************************
## Назначение Кнопок и Оси Vjoy
- Мышь - Руль - Vjoy Ось X
- W - Газ - Vjoy Ось Y
- S - Тормоз - Vjoy Ось Z
- C - Сцепление - Vjoy Ось RX  ( не нужно если включено автоматическое сцепление в игре)
- Пробел - Ручной тормоз - Vjoy Ось RY
- Q - кнопка 1 - Vjoy button 1(Используется для понижения передачи) 
- E - Кнопка 2 - Vjoy button 2(Используется для повышения передачи) 
  *************************************************************************************** 


## Технические Детали
- Проект создан на C# с использованием WPF для графического интерфейса.
- Используется библиотека SharpDX для работы с DirectInput и XInput.
- Библиотека assettocorsasharedmemory для работы с API Assetto Corsa
- Vjoy в качестве драйвера для эмуляции виртуального руля

## Зависимости 
- [SharpDX](https://www.sharpdx.org/) 
- [vJoy](http://vjoystick.sourceforge.net/site/)
- [assettocorsasharedmemory](https://github.com/robgray/assettocorsasharedmemory/tree/master)*
- [.NET6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) -( ВАЖНОЕ , необходимо к установки ) 
___________________________________________________________________________________________________________________________________________________________________________________________________________________________________________

## Контактная Информация
Discord - tristx#9407

## Лицензия
Проект распространяется под лицензией MIT. Смотрите файл [`LICENSE`](https://github.com/Tritstx/MSteerHelp/blob/master/LICENSE.txt) для полного текста лицензии.
