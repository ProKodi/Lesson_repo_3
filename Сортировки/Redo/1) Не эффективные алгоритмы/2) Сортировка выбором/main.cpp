



#include <iostream>


using namespace std;


/*
Так как для сортировки колекции необходимо 2 цикла 
    с количеством итераций n (n - размер коллекции),
    то сложность алгоритма = O(n^2)
    
Результатом алгоритма будет отсортированный массив 
*/




// сортировка по возрастанию
void sort_ass(int* arr, const int len_arr){
    for (int i = 0; i < len_arr - 1; i += 1){
        // В данном цикле находим самый минимальный элемент массива и ставим его на место i
        for (int ii = i + 1; ii < len_arr; ii += 1){
            if (arr[i] > arr[ii]){
                int temp = arr[ii]; 
                arr[ii] = arr[i];
                arr[i] = temp; 
            }
        }
    }
}


// сортировка по убыванию
void sort_des(int* arr, const int len_arr){
    for (int i = 0; i < len_arr - 1; i += 1){
        // В данном цикле находим самый максимальный элемент массива и ставим его на место i
        for (int ii = i + 1; ii < len_arr; ii += 1){
            if (arr[i] < arr[ii]){
                int temp = arr[ii]; 
                arr[ii] = arr[i];
                arr[i] = temp; 
            }
        }
    }
}


int main(){
    system("chcp 65001");
    // Обьявляем колекцию которую нужно отсортировать
    int arr[] = {4, 7, 2, 9, 7, 0, 1, 3, 6}; 

    // Отправляем массив в функцию сортировки
    sort_ass(arr, size(arr));

    cout << "["; 
    for (int i = 0; i < size(arr); i += 1){
        cout << arr[i] << ", "; 
    }
    cout << "\b\b]\n"; 


    // Отправляем массив в функцию сортировки
    sort_des(arr, size(arr));

    cout << "["; 
    for (int i = 0; i < size(arr); i += 1){
        cout << arr[i] << ", "; 
    }
    cout << "\b\b]\n"; 

    system("pause");
    return 0; 
}