



#include <iostream>


using namespace std;


/*
Так как для сортировки колекции необходимо 2 цикла 
    с количеством итераций n (где n - размер коллекции),
    то сложность алгоритма в худшем случае = O(n^2), в лучшем случае = O(nk)

Результатом алгоритма будет отсортированный массив 
*/




// сортировка по возрастанию
void sort_ass(int* arr, const int len_arr){
    for (int i = 1; i < len_arr; i += 1){
        // В данном цикле мы сортируем массив куском от 0 до ii 
        for (int ii = i; ii > 0; ii -= 1){
            // Если предыдущий элемент больше текущего
            if (arr[ii - 1] > arr[ii]){
                int temp = arr[ii - 1]; 
                arr[ii - 1] = arr[ii];
                arr[ii] = temp; 
            }
            // Если предыдущий элемент меньше текущего (часть массива отсортированна)
            else{
                break;
            }
        }
    }
}


// сортировка по убыванию
void sort_des(int* arr, const int len_arr){
    for (int i = 1; i < len_arr; i += 1){
        // В данном цикле мы сортируем массив куском от 0 до ii 
        for (int ii = i; ii > 0; ii -= 1){
            // Если предыдущий элемент меньше текущего
            if (arr[ii - 1] < arr[ii]){
                int temp = arr[ii - 1]; 
                arr[ii - 1] = arr[ii];
                arr[ii] = temp; 
            }
            // Если предыдущий элемент больше текущего (часть массива отсортированна)
            else{
                break;
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