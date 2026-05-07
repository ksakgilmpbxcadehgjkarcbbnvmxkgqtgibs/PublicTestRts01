# RTS Prototype (Unity)

Technical RTS prototype focused on scalable gameplay architecture, modular gameplay systems, and maintainable code practices.

The project explores approaches to building decoupled RTS gameplay systems using dependency injection, reactive programming, and asynchronous workflows in Unity.

### 🎮 Демонстрация геймплея:
![Демонстрация геймплея](Media/ReadMe.gif)

## Features

- RTS-style unit selection and movement

- Modular composable unit behaviour system

- Reactive event handling with UniRx

- Async operations via UniTask

- Dependency Injection using Zenject

- Loosely coupled gameplay architecture

- UI layer separated from gameplay domain logic

## Architecture

The project follows separation of concerns principles.

- Gameplay logic separated from presentation

- Modular unit behaviours

- Service-oriented gameplay systems

- Dependency injection via Zenject

## Tech Stack

| Area | Technology |
|---|---|
| Engine | Unity |
| Language | C# |
| DI | Zenject |
| Reactive | UniRx |
| Async | UniTask |

## Why

Zenject is used to reduce coupling between gameplay systems and improve extensibility.

UniRx is used for reactive event propagation between gameplay systems.

UniTask is used to simplify asynchronous gameplay flows without heavy coroutine chaining.

## Engineering Goals

This prototype is primarily focused on:

- scalable gameplay architecture
- maintainable gameplay systems
- separation of concerns
- low coupling between systems
- extensibility for future RTS mechanics

## Planned Features

- Unit combat system
- Fog of war
- Object pooling
- Addressables integration
- AI behaviours
- Mobile optimization
- Editor tooling

## Technical Focus

- gameplay architecture
- decoupled systems
- maintainability
- scalability
- reactive workflows
- dependency injection

## Project Structure

```
Assets/
 ├── Prefabs/
 ├── Scenes/
 ├── Media/
 └── Scripts/
		├── GameSettings
		├── Models
		├── Units
		└── Helpers
```