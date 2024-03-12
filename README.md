Ссылка на Itch.io проекта: https://enelm.itch.io/nst

Версия Unity 2022.3.21f1

Названия файлов в Assets/ говорят за себя
Разбор файлов внутри Scripts/

Проект обязан начинаться в InitScene, а инициализироваться с помощью Game.cs

###О каждом файле в отдельности
- Scripts/Extensions добавляет экстеншены к скриптам. Пока только для Action, где есть безопасный вызов каждого делегата в экшене
- Scripts/Inputs отвечает за инпут игрока, чтобы внутри кода писать, как можно меньше
- Scripts/Interfaces ответственен за UI. Пока есть только попап с сообщением о координате
- Scripts/Scenes нужен для отделения работы с сценами
- Scripts/Times хранит в себе таймер для засекания времени и Time, являющийся заменой юнитёвского Update у монобехов, только не привязанным к монобеху, а статическим
- Scripts/Players взаимодействует с инпутом для модификации местоположения на сетке
- Scripts/Grids хранит текущее местоположение и данные о сетке
- Scripts/Painters нужен для отображения на кубах текущего местоположения
- Scripts/Initializes нужен, поскольку возникла необходимость с порядке вызова (execution order в unity)

Данными выступают скриптейбл объекты и grid.cs, контроллерами являются player.cs и painter.cs. Роль вью берут на себя meshRenderer

###Трудности в выполнении задания (2)
Самым сложным (по времени отладки и написания) можно выделить алгоритм. А так, всегда есть мысли, как, например, можно улучшить архитектуру, сделать код опрятнее и т.д, учитывая, что проект крошечный, и тем непривычный) Обычно разворачиваю сразу большие заготовленные пакеты для написания качественной архитектуры. Тут это только Input.cs и Time.cs

###Предложения по улучшению (3)
Механика бесконечного скролла в любую сторону напоминает некий бесшовный мир, например движение по сфере, где в конечном счёте мы всё равно вернёмся на прошлое место
Но, пока это лишь абстрактный алгоритм. Могу ещё лишь дополнить, что, как тестовое задание, можно ещё чуть дополнить задание архитектурными пунктами