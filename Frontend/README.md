# N-able-intenship  
# Frontend  

## Task 1
Написать функции/функцию, которая бы возвращала столбцы/строки из матрицы:

  const matrix = [[1,2,3,4], [5,6,7,8], [10, 11, 12, 13], [14,15,16,17]];    
  const rows = [...getRows(matrix)];    
  const cols = [...getCols(matrix)];  
  
## Task 2
Написать функцию, которая бы развернула массив в одномерный:

  const array = [...flat([1, [2, [3]]])]  
  
## Task 3
Написать итератор, который бы возвращал ключи, похожие на числа

  const o = {a: 1, 2: 3, b: 4, 5: 6, c: 7}; 
  const keys = [...o]; // ['2', '5']; 

## Task 4
Сделать квадрат и его грань под углом (css, js)

## Task 5
Сделать квадрат и кнопку [start video], при нажатии на которой будет отображаться видео с камеры в квадрате;  

## Task 6
Сделать игру "Найди пару"

## Task 7
### Отформатировать значение в зависимости от типа:

String => "application/text;base64,{base64EncodedString}"  
Number => "X.YZ" (float), "XXX" (integer)  

## Task 8

## Task 9
### Спарсить страницу онлайнера
Вывести все такие структуры {tittle, url, ing, description} новостных блоков
Function => fn.toSource()  
Array => "[a,b,c,d,...]"  
Object => "[[key, value], [key2, value2], …, [keyN, valueN]]"  
Date => "DD-MM-YYYY HH:ii:ss"    
RegExp (/test/) => "/test/"    


### Сделать валидацию и форматирование мобильных телефонов:

['80296758990','+375296758990','+375(29)6758990','+375(29)675-89-90','(029)675-89-90','6758990']  

// отформатированные номера:  
8 (029) 678-89-90  
+375 (29) 678-89-90  
(029) 678-89-90  
678-89-90  


### Формирователь строки на основе шаблона и параметров:

"{0} {1}".format([firstName, lastName]) // .format(["Vadym", "Vinnyk"]) => "Vadym Vinnyk"  
 
"{firstName} {lastName}".format({firstName: "Vadym", lastName: "Vinnyk"}) // "Vadym   Vinnyk";   

// ограничение, при отсутствии значения для форматирования, формат должен оставаться неизменным, т.е.  
"{length}".format([1]) === "{length}"  
"{0} {1}".format(['test']) === "test {1}"  
