# 🛡️ Perimeter Defense Prototype

A real-time automated defense system prototype built in Unity, where AI-driven enemies attempt to breach a secured zone while an autonomous sentry detects, prioritizes, and neutralizes threats.

---

## 🎯 Overview

This project demonstrates a **perimeter security system simulation** featuring:

* Autonomous enemy agents using pathfinding
* Intelligent sentry system with detection and targeting logic
* Real-time combat using raycasting
* Modular and optimized architecture

The focus of this prototype is **AI behavior, mathematical logic, and system design**, rather than visual fidelity.

---

## 🚀 Live Demo

* 🌐 **WebGL Build:** [Play in Browser](https://perimeterdefenseprototypeashish.netlify.app/)
* 💻 **Windows Build:** [Download EXE](https://drive.google.com/drive/folders/1tqCgUgOsWkBXAN8h5-CZUb4GpkIyU6bd?usp=sharing)
* Demo Video (YouTube): https://youtu.be/amPEQl-oRAs

---

## ⚙️ Core Features

### 🪖 Enemy AI (NavMesh)

* Uses Unity NavMesh for pathfinding
* Dynamic spawning from predefined points
* Randomized movement speed for varied behavior
* Modular Health system

---

### 🔫 Automated Sentry System

* Detects enemies using radius-based scanning
* Target prioritization:

  * Closest enemy
  * Highest health enemy
* Smooth rotation toward targets
* Continuous laser-based shooting using raycasting
* Line-of-sight ready structure

---

### 🎯 Combat System

* Raycast-based hit detection
* Damage system with health reduction
* Death handling with animation support
* Continuous laser visualization using LineRenderer
* Audio feedback during firing

---

### 🧠 System Design Highlights

* Clean modular scripts:

  * `EnemyAI`
  * `Health`
  * `Spawner`
  * `SentryDetection`
* Optimized spawning with enemy limits
* Separation of responsibilities (AI, combat, spawning)

---

## 🎮 Controls

This is a **fully automated simulation**:

* No player input required
* System runs autonomously

---

## 🛠️ Tech Stack

* **Engine:** Unity (3D)
* **Language:** C#
* **AI:** NavMesh Pathfinding
* **Rendering:** LineRenderer (laser system)

---

## 🎨 Assets Used

* Soldier model & animations: Mixamo
* Weapon model: Sketchfab
* Environment assets: Free/placeholder assets

> All assets are used for demonstration purposes only.

---

## 👤 Author

**Ashish Mittal**
Unity Game Developer

---

## 📬 Submission

This project was developed as part of a **Technical Assignment: Perimeter Defense Prototype**, focusing on system design, AI behavior, and optimization under time constraints.

---
