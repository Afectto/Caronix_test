Сделала систему сохранения через файл т.к. у меня под рукой был готовый вариант просто поправил его для текущей задачи

Атрибуты врага (Имя и Награда за убийство) передавал между сценами с помошью PlayerPrefs что бы показать что и с ними я умею работать

Сохранение происходят при завершении игры и при каждом переходе между сценами, это наверное излишне но я решил перестраховаться

Загрузка происходит при старте игры со следующим исходом:
  1) Если есть что загружать то открывается сразу экран Поиск врага
  2) Если загружать нечего то открывается Встречающий экран

Создание нового врага (загрузка) происходит через метод NewEnemy в SpawnEnemy, там используется лямбда-выражение что бы данные присваивались и заглушка исчезала только после того как данные будут получены, а это гарантиреутся с помощью callback

SaveLoad и SceneController сделаны Singlton'ом что бы спокойно можно было переключаться между сценами и сохранять в любой момент
