# TopDownJumper

## Демо механики бесконечного джампера. Оригинальная игра - [Alley Bird](https://play.google.com/store/apps/details?id=com.orangenose.upper).

Проект реализован в рамках тестового задания на позицию Junior Unity Developer.

"Бесконечные" миры, с моей точки зрения, можно реализовать двумя способами:
1. непрерывная генерация объектов окружения и последующее их удаление за пределами вьюпорта;
2. использование одних и тех же объектов.

Используя первый способ, мы получим значительные потери оптимизации из-за постоянного вызова сборщика мусора. Конечно, можно не удалять объекты, но тогда есть риск столкнуться с потерей точности значений переменных типа float, в которых задаётся положение **любого** объекта. Это явление может вызывать появление артефактов, да и ОЗУ не бесконечная, чтобы хранить миллионы объектов.

Второй способ решает эти проблемы, поэтому я реализовал именно его.
Краткий алгоритм, отражающий мой подход:
1. создаётся пул платформ;
2. платформы размещаются на интервале 2.5f по оси Y;
3. **_при нажатии на пробел прыгают платформы, а не игрок_**;
4. если платформа оказалась ниже установленной границы, она перемещается наверх за пределы вьюпорта;
5. смотри пункт 4.

*Подробнее о том, как фиксируются платформы, можно узнать в префабе PlatformGroup.*
