# 🎲 Board Game Library API

A simple RESTful API for managing a board game library, allowing users to register, borrow, return, and delete board games.

## 📌 Features

- Register new board games
- List all available games
- Borrow and return games
- Delete games from the library

---

## 🚀 API Endpoints
### ➕ Register a New Game
**POST** `/games`

Registers a new board game in the library.

### 📋 List All Games

**GET** `/games`

Returns a list of all board games in the library.

### ❌ Delete a Game

**DELETE** `/games/{name}`

Deletes a board game from the library.

### 📦 Borrow a Game

**POST** `/borrow-game/{game}?user={user}&days={days}`

Borrows a game from the library for a specified user for the specified number of days.

### 🔁 Return a Game

**POST** `/return-game/{game}`

Returns a previously borrowed game to the library.
