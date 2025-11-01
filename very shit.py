



class IterationTableString:
    """Итератор для строки таблички"""
    def __init__(self, data: any, start_index: int = 0, end_index: int = 0, step: int = 1):
        self.data = data
        self.select_index = start_index - 1

        if(end_index <= 0):  end_index += len(self.data)
        self.end_index = end_index

        self.step = step; 


    def __next__ (self) -> float:
        """Возвращает следующий эллемент итерации"""
        self.select_index += self.step

        if self.select_index < self.end_index:  return self.data[self.select_index]
        
        raise StopIteration


    def __iter__(self) -> "IterationTableString": 
        """Должен вернуть итератор для класса."""
        return self


class TableString:
    ...

class TableString:
    """Строка для таблички"""
    def __init__(self, *args: tuple):
        for i in args:
            if(type(i) not in (int, float)):  raise TypeError("В строке есть не число")
            
        self.values = [float(i) for i in args]


    def __repr__(self) -> str:  return f"[{", ".join([str(i) for i in self.values])}]"
    
    def __str__(self) -> str:  return f"[{", ".join([str(i) for i in self.values])}]"
        

    def __len__(self) -> int:  return len(self.values)


    def __getitem__(self, index:(int | slice)) -> float:  return self.values[index]


    def __iter__(self) -> "IterationTableString":  return IterationTableString(self)


    def __check_other(self, data: TableString | float | int) -> None:
        """ Проверка данных на корректность по типу и значению

        Args:
            data (TableString | float | int): Данные для проверки
        """
        if(type(data) in (int, float)):  return;

        if(type(data) == TableString):
            if(len(self) != len(data)):  raise ValueError("Строки не равны по длине")
            return
        
        raise TypeError("Подан не верный тип данных")


    def __add__(self, other: TableString | float | int) -> "TableString":
        """ Случай вида: c = a + b """
        self.__check_other(other)
        if(type(other) in (int, float)):  return TableString(*[i + other for i in self.values])
        elif(type(other) == TableString): return TableString(*[self.values[i] + other[i] for i in range(len(self.values))])

    def __iadd__(self, other: TableString | float | int) -> "TableString":
        """ Случай вида: a += b """
        self.__check_other(other)
        if(type(other) in (int, float)):  self.values = [i + other for i in self.values]
        elif(type(other) == TableString):  self.values = [self.values[i] + other[i] for i in range(len(self.values))]
        return self


    def __sub__(self, other: TableString | float | int) -> "TableString":
        """ Случай вида: c = a - b """
        self.__check_other(other)
        if(type(other) in (int, float)):  return TableString(*[i - other for i in self.values])
        elif(type(other) == TableString):  return TableString(*[self.values[i] - other[i] for i in range(len(self.values))])

    def __isub__(self, other: TableString | float | int) -> "TableString":
        """ Случай вида: a -= b """
        self.__check_other(other)
        if(type(other) in (int, float)):  self.values = [i - other for i in self.values]
        elif(type(other) == TableString): self.values = [self.values[i] - other[i] for i in range(len(self.values))]
        return self


    def __mul__(self, other: TableString | float | int) -> "TableString":
        """ Случай вида: c = a * b """
        self.__check_other(other)
        if(type(other) in (int, float)):  return TableString(*[i * other for i in self.values])
        elif(type(other) == TableString):  return TableString(*[self.values[i] * other[i] for i in range(len(self.values))])
    
    def __imul__(self, other: TableString | float | int) -> "TableString":
        """ Случай вида: a *= b """
        self.__check_other(other)
        if(type(other) in (int, float)):  self.values = [i * other for i in self.values]
        elif(type(other) == TableString):  self.values = [self.values[i] * other[i] for i in range(len(self.values))]
        return self





    
test1 = TableString(-2, 3, 1, 0, 0, 6)
test2 = TableString(1, 3, 0, 1, 0, 15)
test3 = TableString(3, -1, 0, 0, 1, 15) # реш
testf = TableString(-1, 3, 0, 0, 0, 0)

print(test1 + (test3 * (2/3)))
print(test2 - (test3 * (1/3)))
print(test3)
print(testf + (test3 * (1/3)))


