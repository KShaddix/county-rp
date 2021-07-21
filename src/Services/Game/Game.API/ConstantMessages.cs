﻿namespace CountyRP.Services.Game.API
{
    public static class ConstantMessages
    {
        // Общие сообщения

        public static string CountItemPerPageMoreThan100 = "Количество записей на странице должно быть от 1 до 100";

        public static string InvalidCountItemPerPage = "Количество записей на странице должно быть 1 и больше";

        public static string InvalidPageNumber = "Номер страницы должен быть 1 и выше";

        // Игроки

        public static string PlayerNotFoundById = "Игрок с ID {0} не найден";

        public static string PlayerInvalidLoginLength = "Длина логина игрока должна быть от 3 до 32 символов";

        public static string PlayerInvalidLogin = "Логин игрока должен состоять из цифр, символов латинского алфавита и специальных символов";

        public static string PlayerInvalidPasswordLength = "Длина пароля должна быть от 8 до 64 символов";

        public static string PlayerInvalidPassword = "Пароль должен состоять из символов латинского алфавита и специальных символов";

        public static string PlayerAlreadyExistedWithLogin = "Игрок с таким логином уже существует";

        // Персонажи

        public static string PersonNotFoundById = "Персонаж с ID {0} не найден";

        public static string PersonInvalidNameLength = "Длина имени персонажа должна быть от 3 до 32 символов";

        public static string PersonInvalidName = "Имя персонажа должно состоять из цифр, символов латинского алфавита и специальных символов";

        public static string PersonAlreadyExistedWithName = "Игрок с таким именем уже существует";

        // Админские уровни

        public static string AdminLevelNotFoundById = "Админский уровень с ID {0} не найден";

        // Внешности

        public static string AppearanceNotFoundById = "Внешность с ID {0} не найдена";

        // Банкоматы

        public static string AtmNotFoundById = "Банкомат с ID {0} не найден";

        // Бизнесы

        public static string BusinessNotFoundById = "Бизнес с ID {0} не найден";

        // Фракции

        public static string FactionNotFoundById = "Фракция с ID {0} не найдена";

        // Группировки

        public static string GangNotFoundById = "Группировка с ID {0} не найдена";

        // Гаражи

        public static string GarageNotFoundById = "Гараж с ID {0} не найден";

        // Дома

        public static string HouseNotFoundById = "Дом с ID {0} не найден";

        // Раздевалки

        public static string LockerRoomNotFoundById = "Раздевалка с ID {0} не найдена";

        // Помещения

        public static string RoomNotFoundById = "Помещение с ID {0} не найдено";

        // Телепорты

        public static string TeleportNotFoundById = "Телепорт с ID {0} не найден";

        // Транспортные средства

        public static string VehicleNotFoundById = "Транспортное средство с ID {0} не найдено";
    }
}