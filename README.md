# MSSS Data Software

A WPF desktop application built in C# for processing satellite sensor data using advanced sorting and searching algorithms. Developed for the Malin Space Science Systems (MSSS) as part of the Satellite Data Processing Project.

## Project Overview

This application reads raw numerical data from two satellite sensors (supposedly), processes it through a scientific formula provided by the `Galileo.dll`, stores it in LinkedLists, and provides sorting and binary search functionalities.

---

## Features

- Load and display raw sensor data from two streams
- Process data using configurable **Mean (Mu)** and **Standard Deviation (Sigma)**
- Sort using:
  - Selection Sort
  - Insertion Sort
- Search using:
  - Iterative Binary Search
  - Recursive Binary Search
- Display processing time for each algorithm
- User-friendly WPF interface with ListBox and ListView for visualization

---

## Technologies

- .NET 8 (Multi-platform App UI using WPF)
- C#
- Git + GitHub for version control
- Galileo.dll (provided by MSSS)
- LinkedList for sensor data storage
- Stopwatch class for timing algorithm execution

---

## Project Structure

```
MSSS-Data-Software/
│
├── /src/                   # Source code (WPF App)
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   └── LinkedListAlgorithms.cs
│
├── /docs/                  # Documentation
│   └── DesignSpec.docx
│
├── /lib/                   # External DLLs
│   └── Galileo.dll
│
├── README.md
└── .gitignore
```

---

## Getting Started

1. Clone the repo:
   ```
   git clone https://github.com/yourusername/MSSS-Data-Software.git
   ```
2. Open the solution in Visual Studio.
3. Build and run the application directly.

---

## Agile Workflow

This project follows an Agile development lifecycle using GitHub Projects.

- **To Do:** Feature planning, UI design
- **In Progress:** Core algorithm implementation
- **Done:** Sorting, searching, and processing components

> Check the Project Board on GitHub for current task status.

---

## License

This project is for educational purposes only.\
© 2025 Cody Husband / CITE Managed Services

---

## Author

**Cody Husband**\
Diploma of IT – TAFE WA\
GitHub: [https://github.com/zhytu](https://github.com/zhytu)

