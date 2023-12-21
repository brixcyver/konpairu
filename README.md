<h1 align="center">Konpairu</h1>
<p align="center">
  <a href="https://github.com/davidkingroderos/konpairu/graphs/contributors">
    <img src="https://img.shields.io/github/contributors/davidkingroderos/konpairu?style=for-the-badge" />
  </a>
  <a href="https://github.com/davidkingroderos/konpairu/stargazers">
    <img src="https://img.shields.io/github/stars/davidkingroderos/konpairu?style=for-the-badge" />
  </a>
  <a href="https://github.com/davidkingroderos/konpairu/forks">
    <img src="https://img.shields.io/github/forks/davidkingroderos/konpairu?style=for-the-badge" />
  </a>
  <a href="https://github.com/davidkingroderos/konpairu/blob/main/LICENSE">
    <img src="https://img.shields.io/github/license/davidkingroderos/konpairu?style=for-the-badge" />
  </a>
</p>

Konpairu is a simple Java expression analyzer created using .NET MAUI (Multi-platform App UI). This application incorporates lexical, syntactical, and semantic analysis features.

## Screenshots
<p align="center">
  <img src="screenshots/windows-light.png" width="500">
  <img src="screenshots/android-light.png" width="250">
</p>
<p align="center">
   <img src="screenshots/android-dark.png" width="250">
  <img src="screenshots/windows-dark.png" width="500">
</p>

## Features

**Lexical Analyzer:**
The application includes a lexical analyzer responsible for tokenizing input source code or text, breaking it down into tokens for further analysis.

**Syntactical Analyzer:**
The syntactical analyzer parses the structure of the source code to ensure it conforms to the grammar rules of a specific programming language or syntax.

**Semantic Analyzer:**
This module performs deeper analysis, checking the meaning and context of the code, aiming to identify errors that might not be caught by the syntactical analysis alone.

## Installing

1. **Clone this repository**: Open a terminal or Git Bash and run the following command:

```bash
  git clone https://github.com/davidkingroderos/konpairu.git
```
2. **Navigate to the project directory**: Change the directory to the cloned project:

```bash
  cd konpairu
```

## Running the Project in Visual Studio

1. **Open Visual Studio**: Launch Visual Studio IDE.

2. **Open the project**: Click on `File` > `Open` > `Project/Solution...` and navigate to the directory where you cloned the repository. Select the solution file (usually with a .sln extension) and click `Open`.

3. **Restore NuGet packages (if applicable)**: If the project uses NuGet packages, right-click on the solution in the Solution Explorer and select `Restore NuGet Packages`.

4. **Build the solution**: Click on `Build` > `Build Solution` or press `Ctrl + Shift + B` to build the project.

5. **Set the startup project (if needed)**: Right-click on the desired project in the Solution Explorer and select `Set as Startup Project`.

6. **Run the project**: Press `F5` or click on `Debug` > `Start Debugging` to run the project.

## Contributing

We welcome contributions from the community to help improve our project. Please take a moment to review the following guidelines:

1. **Fork the repository**: Fork this repository to your GitHub account by clicking on the "Fork" button at the top right corner of the repository page.

2. **Clone the forked repository**: Clone the forked repository to your local machine:

```bash
   git clone https://github.com/your-username/konpairu.git
```
   
3. **Create a new branch**: Move into the project directory and create a new branch for your contributions:

```bash
   cd project-name
   git checkout -b feature/your-feature
```

4. **Make necessary changes**: Make your desired changes and ensure that the code follows the project's coding standards and guidelines.

5. **Commit your changes**: Commit your changes with a descriptive commit message:

```bash
  git add .
  git commit -m "blablabla"
```

6. **Push changes to your fork**: Push your changes to your forked repository:
  
```bash
   git push origin feature/your-feature
```

7: **Create a Pull Request (PR)**: Go to back to this repository. You should see a prompt to create a new Pull Request from your recently pushed branch. Fill in the PR template, explaining the changes introduced and any relevant information.

## License

This project is licensed under the [MIT License](https://github.com/davidkingroderos/konpairu/blob/main/LICENSE).
