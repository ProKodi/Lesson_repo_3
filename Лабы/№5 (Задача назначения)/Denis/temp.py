



# pip install ortools
from ortools.linear_solver import pywraplp


def solve_assignment(costs):
    n = len(costs)

    solver = pywraplp.Solver.CreateSolver("CBC")  # MIP-решатель

    # --- Переменные x[i][j] ∈ {0,1} ---
    x = [[solver.IntVar(0, 1, f'x_{i}_{j}')
          for j in range(n)] for i in range(n)]

    # --- Каждый исполнитель → ровно одна работа ---
    for i in range(n):
        solver.Add(sum(x[i][j] for j in range(n)) == 1)

    # --- Каждая работа → ровно одному исполнителю ---
    for j in range(n):
        solver.Add(sum(x[i][j] for i in range(n)) == 1)

    # --- Целевая функция ---
    solver.Minimize(
        sum(costs[i][j] * x[i][j] for i in range(n) for j in range(n))
    )

    status = solver.Solve()

    if status != pywraplp.Solver.OPTIMAL:
        print("Решение не найдено")
        return

    print("Оптимальное назначение найдено")
    print("Минимальная стоимость:", solver.Objective().Value(), "\n")

    print("Назначения (исполнитель → работа):")
    for i in range(n):
        for j in range(n):
            if x[i][j].solution_value() == 1:
                print(f"Исполнитель {i + 1} → Работа {j + 1} (стоимость {costs[i][j]})")


costs = [
    [3, 2, 7, 8, 5, 5],
    [3, 5, 7, 6, 6, 10],
    [5, 2, 3, 2, 1, 3],
    [4, 2, 6, 9, 2, 7],
    [2, 8, 9, 8, 2, 3],
    [1, 9, 8, 8, 3, 9]
]

solve_assignment(costs)


'''
3, 2, 7, 8, 5, 5
3, 5, 7, 6, 6, 10
5, 2, 3, 2, 1, 3
4, 2, 6, 9, 2, 7
2, 8, 9, 8, 2, 3
1, 9, 8, 8, 3, 9


'''