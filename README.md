# Tennis API 🎾

API REST développée en .NET 8 permettant de récupérer les statistiques des joueurs de tennis à partir d’un fichier JSON fourni dans le cadre du test technique de L’Atelier.

---

## 🚀 Contexte du projet

Ce projet a été réalisé dans le cadre du test technique backend de L’Atelier.

Objectifs :
- Créer une API REST simple
- Retourner des statistiques sur des joueurs de tennis
- Respecter les bonnes pratiques backend
- Déployer l’application sur le cloud
- Fournir une documentation claire

---

## 🛠️ Technologies utilisées

- .NET 8
- ASP.NET Core Web API
- Swagger / OpenAPI
- xUnit
- Render (Cloud Hosting)

---

## 📂 Architecture du projet

Le projet est organisé de la manière suivante :

- `Controllers/` → endpoints REST
- `Services/` → logique métier
- `Models/` → modèles de données
- `Data/` → lecture des données JSON
- `Tests/` → tests unitaires

---

## 📊 Fonctionnalités

L’API permet de :

- Récupérer les joueurs
- Obtenir les statistiques d’un joueur
- Trier les joueurs selon leurs performances
- Calculer certaines statistiques globales
- Gérer les erreurs et exceptions

---

## ▶️ Lancer le projet en local

### 1. Cloner le repository

```bash
git clone https://github.com/Aymen244/TennisApi.git
```

### 2. Aller dans le dossier

```bash
cd TennisApi
```

### 3. Restaurer les dépendances

```bash
dotnet restore
```

### 4. Lancer l’application

```bash
dotnet run
```

---

## 🧪 Tester l’API

Swagger est disponible localement via :

```bash
http://localhost:xxxx/swagger
```

---

## ☁️ Application déployée

Swagger en ligne :

https://tennisapi-92jt.onrender.com/swagger/index.html

---

## 📁 Repository GitHub

https://github.com/Aymen244/TennisApi.git

---

## ✅ Points travaillés

- Architecture claire
- Respect des principes REST
- Gestion des exceptions
- Code propre et maintenable
- Tests unitaires
- Déploiement cloud
- Documentation Swagger

---

## 📌 Améliorations possibles

- Ajouter une base de données
- Ajouter JWT Authentication
- Dockeriser l’application
- Ajouter CI/CD GitHub Actions
- Ajouter plus de tests d’intégration

---

## 👨‍💻 Auteur

Développé par Aymen Mhirsi dans le cadre du test technique backend de L’Atelier.
