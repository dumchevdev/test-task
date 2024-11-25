# Тестовое задание (Unit Developer)

>Тестовое задание было выполнено за 5 часов без использования сторонних плагинов и фреймворков. 
> Все основные требования были соблюдены, а также реализованы бонусные механики.

## Примечание:
Физический движок Unity не является детерминированным, и, поскольку без физики не обойтись, приходится жертвовать точностью поведения клонов. 
Они не могут точно повторить путь оригинального персонажа, если на них воздействовать физически, например, перегородить им путь. 
В противном случае, поскольку я записываю скорость, с которой игрок движется в каждом из направлений, клоны могут точно повторить его путь.

## Управление:
- **A, D / Left, Right** — передвижение игрока
- **Space / W** — прыжок
- **R** — создание нового клона
- **C** — смена цвета у игрока
- **Left Shift** — временное ускорение

## Основные требования:
1. Перемещение персонажа:
    - Управление персонажем в 2D-пространстве: движение влево/вправо и прыжки.
2. Создание клона:
    - При нажатии клавиши <b>R</b>.
        - Персонаж возрождается на стартовой точке.
        - Создается клон, который появляется также на стартовой точке и повторяет все действия оригинального персонажа которые он выполнял от момента предыдущего возрождения до создания данного клона.
3. Физическое взаимодействие:
    - Клоны и оригинальный персонаж должны физически взаимодействовать друг с другом (например, сталкиваться, толкаться).

## Бонусные фичи (опционально):
1. Случайная смена цвета:
    - Добавьте возможность изменения цвета персонажа при нажатии определенной клавиши, чтобы цвет менялся случайным образом.
2. Ускорение персонажа:
    - Реализуйте возможность временного ускорения персонажа при нажатии на определенную кнопку
