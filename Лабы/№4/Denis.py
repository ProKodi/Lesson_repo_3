



# pip install ortools
from ortools.linear_solver import pywraplp


def solve_transport(costs, supply, demand):
    m = len(supply) # число поставщиков
    n = len(demand)  # число потребителей

    solver = pywraplp.Solver.CreateSolver("GLOP")  # LP-решатель

    # --- Переменные x[i][j] ---
    x = [[solver.NumVar(0, solver.infinity(), f'x[{i},{j}]')
          for j in range(n)] for i in range(m)]

    # --- Ограничения по поставщикам ---
    for i in range(m):
        solver.Add(sum(x[i][j] for j in range(n)) <= supply[i])

    # --- Ограничения по потребителям ---
    for j in range(n):
        solver.Add(sum(x[i][j] for i in range(m)) >= demand[j])

    # --- Целевая функция ---
    solver.Minimize(
        sum(costs[i][j] * x[i][j] for i in range(m) for j in range(n))
    )

    status = solver.Solve()

    if status == pywraplp.Solver.OPTIMAL:
        print("Оптимальное решение найдено")
        print("Минимальная стоимость:", solver.Objective().Value())
        print("\nОптимальный план перевозок:")
        for i in range(m):
            print([x[i][j].solution_value() for j in range(n)])
    else:
        print("Оптимальное решение не найдено")


# ==== Пример задачи ====
costs = [
    [ 1,  5,  4, 2  ],
    [12, 10, 16, 8  ],
    [ 4, 13, 14, 10 ]
]

# потребители
demand = [20, 70, 10, 50]

# поставщики
supply = [30, 40, 80]


solve_transport(costs, supply, demand)