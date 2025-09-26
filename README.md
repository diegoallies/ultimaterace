

# 🏎️ The Ultimate Race  

A quirky, **Top Gear–style racing simulation** built as part of a technical assessment for Causal Nexus.  
The project combines a **C#/.NET 6 backend (Web API)** with an **Angular frontend** to simulate and visualize the progress of different vehicles on an epic journey from Cairo to Cape Town.  

---

## 🚀 Features  
- **Race Simulation Logic**
  - Vehicles compete with unique conditions (fuel, breakdowns, battery, etc.)
  - Leaderboard tracking with proper ordinal placement (`1st`, `2nd`, `3rd`, etc.)
  - Graceful race termination once all vehicles finish  

- **Backend (.NET 6 Web API)**
  - Endpoints to start a race, fetch current status, and view leaderboard
  - Built with ASP.NET Core, Swagger/OpenAPI included  

- **Frontend (Angular 17)**
  - Simple landing page + Race Status component
  - Displays live leaderboard in a clean table format  
  - Styled with SCSS  

---

## 🛠️ Tech Stack  
- **Backend**: C# / .NET 6 (ASP.NET Core Web API)  
- **Frontend**: Angular 17, SCSS  
- **Other**: Swagger UI for API docs  

---

## 📦 Getting Started  

### Backend Setup
```bash
# Navigate into backend project
cd ultimaterace.api

# Run the API
dotnet run
```
The API will be available at:  
👉 `http://localhost:5241/swagger`

---

### Frontend Setup
```bash
# Navigate into Angular project
cd race-ui

# Install dependencies
npm install

# Run Angular dev server
ng serve
```
The app will be available at:  
👉 `http://localhost:4200`

---

## 📸 Screenshots  

**Swagger API**  
_Endpoints to check race status and leaderboard_  
![swagger-example](docs/swagger.png)

**Angular Frontend**  
_Live leaderboard view_  
![ui-example](docs/ui.png)  

---

## 📌 Roadmap  
- [ ] Add start/stop race controls from UI  
- [ ] Display vehicle events (breakdowns, refuels, etc.)  
- [ ] Add persistent storage (SQLite/Postgres)  
- [ ] Polish leaderboard UI with charts  

---

## 🤝 Contributing  
Pull requests are welcome! For major changes, please open an issue first to discuss what you’d like to change.  

---

## 📄 License  
MIT License © 2025 Diego Allies  
