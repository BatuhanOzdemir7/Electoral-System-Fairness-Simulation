# Electoral System Fairness Simulation

![Language](https://img.shields.io/badge/Language-C%23-blue) ![License](https://img.shields.io/badge/License-MIT-green) ![Status](https://img.shields.io/badge/Status-Completed-success)

This project is a C# simulation designed to analyze the trade-off between **"Fairness in Representation"** and **"Stability in Government"** within electoral systems. It compares the currently used **D'Hondt Method** (Turkey) against a custom-developed algorithm focused on minimizing representation error: the **"Iterative Equity Model."**

---

## 🚀 The Backstory: An Algorithmic "Rediscovery"

When I started this project, my primary goal was to address the representation unfairness I observed in local election results, particularly in my home city of Yalova. I aimed to write an algorithm that would mathematically **"minimize the representation error"** for smaller districts.

Without consulting existing political science literature, I developed an iterative logic that calculates the "victimization level" (deviation from the ideal quota) of each district at every step and assigns seats to the most underrepresented district.

> **💡 The "Reinvention" Moment**
> After implementing and testing my "Batuhan Equity Model," I conducted a literature review and discovered that I had **independently re-derived** a variation of the **Hare-Niemeyer (Largest Remainder) Method**.
>
> **Key Takeaway:** This project serves as a proof of concept for my algorithmic problem-solving skills. I reached a standard political science solution through pure logic and error analysis, without prior knowledge of the specific method. While the mathematical results converge with Hare-Niemeyer, my implementation differs by using a **dynamic, iterative error-minimization loop** rather than a static sort of remainders.

---

## 📊 Systems Compared

### System 1: The "Iterative Equity Model" (My Implementation)
* **Core Principle:** Fairness in Representation.
* **Logic:**
    1.  Calculates the ideal "theoretical" number of seats for each district based on population.
    2.  In a loop, calculates the current deviation (error) between the *actual* representation and the *ideal* representation for every district.
    3.  Assigns the next seat to the district with the highest negative deviation (the most "unfairly" treated district at that specific moment).
* **Outcome:** Protects the representation of smaller districts and minimizes wasted votes.

### System 2: Pure D'Hondt Method (Current System)
* **Core Principle:** Stability in Government.
* **Logic:** Divides the total votes of each district by 1, 2, 3... and assigns seats to the highest resulting quotients.
* **Outcome:** Favors larger districts/parties significantly (the "Bonus Seat" effect) to ensure a stable majority, often at the expense of fairness.

---

## 💻 Technical Implementation

The project is built with **C#** and adheres to **Object-Oriented Programming (OOP)** principles.

### The Algorithm (Iterative Error Minimization)
Unlike the standard implementation of the Largest Remainder method (which sorts static remainders), my approach uses a dynamic loop to recalculate the "Error Margin" after every single seat assignment:

```csharp
// Core Logic Snippet: Iterative Error Calculation
while (currentSeats < totalSeats)
{
    // 1. Calculate the real-time "Error Margin" for each district
    for (int i = 0; i < districtCount; i++)
    {
        theoreticalRatio[i] = (float)seats[i] * 100.0f / (float)currentSeats;
        errorMargin[i] = theoreticalRatio[i] - actualPopulationRatio[i]; 
        // Result: How far is the current reality from the ideal math?
    }

    // 2. Find the district with the lowest error margin (most underrepresented)
    // and assign the next seat there.
    // ...
}
```

## 📈 Sample Output (Yalova Simulation)
The program runs a comparative analysis on real population data and calculates a final **"Unfairness Score"** (Average Percentage Deviation). *A lower score indicates a fairer system.*

    ------------------------------
    HOW TO ENSURE A FAIR ASSEMBLY
    ------------------------------
    
    --- SYSTEM 1: ITERATIVE EQUITY MODEL ---
    SYSTEM 1 - Overall Unfairness Score (Avg. Pct. Deviation):  % 4.12
    
    --- SYSTEM 2: PURE D'HONDT METHOD ---
    SYSTEM 2 - Overall Unfairness Score (Avg. Pct. Deviation):  % 12.85
    
    ------------------------------
    FINAL COMPARISON
    ------------------------------
    Result: The Iterative Equity Model produced a fairer outcome than Pure D'Hondt for this dataset.

##🛠️ Installation & Usage
To run this simulation on your local machine:
1. Clone the repository:
    	git clone [https://github.com/BatuhanOzdemir7/Electoral-System-Fairness-Simulation.git](https://github.com/BatuhanOzdemir7/Electoral-System-Fairness-Simulation.git)
2. Navigate to the project directory:
    	cd Electoral-System-Fairness-Simulation
3. Run using the .NET SDK:
    	dotnet run

##📝 License
This project is licensed under the MIT License.

------------


Author: Batuhan Özdemir
Computer Engineering Student | Bursa Uludağ University
