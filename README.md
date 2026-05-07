# RTS Prototype (Unity)

Технический RTS-прототип, сфокусированный на масштабируемой игровой архитектуре и чистом коде.  
Technical RTS prototype focused on scalable gameplay architecture and clean code practices.

### 🎮 Демонстрация геймплея:
<video src="Media/ReadMe.mp4" autoplay loop muted playsinline width="100%"></video>

## Features / Возможности

- RTS-механика выбора и перемещения юнитов  
  RTS-style unit selection and movement

- Поведение юнитов разделено на независимые модульные компоненты  
  Unit behaviour split into modular components

- Реактивная обработка событий с использованием UniRx  
  Reactive event handling with UniRx

- Асинхронные операции через UniTask  
  Async operations via UniTask

- Dependency Injection с использованием Zenject  
  Dependency Injection using Zenject

- Слабо связанная игровая архитектура  
  Decoupled gameplay systems

- Базовый UI для выбора юнитов  
  Basic UI for unit selection

## Architecture / Архитектура

Проект построен с использованием принципов разделения ответственности.  
The project follows separation of concerns principles.

- Игровая логика отделена от представления  
  Gameplay logic separated from presentation

- Модульное поведение юнитов  
  Modular unit behaviours

- Сервис-ориентированная архитектура  
  Service-oriented systems

- Dependency Injection через Zenject  
  Dependency injection via Zenject

## Tech Stack / Технологии

- Unity
- C#
- Zenject
- UniRx
- UniTask