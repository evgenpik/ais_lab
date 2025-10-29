-- ========= ШАГ 1: ПОЛНАЯ ЗАЧИСТКА =========

-- Удаляем внешний ключ, если он существует
IF OBJECT_ID('dbo.FK_Games_Platforms', 'F') IS NOT NULL
BEGIN
    ALTER TABLE dbo.Games DROP CONSTRAINT FK_Games_Platforms;
    PRINT 'Внешний ключ удален.';
END
GO

-- Удаляем колонку PlatformId из таблицы Games, если она существует
IF COL_LENGTH('dbo.Games', 'PlatformId') IS NOT NULL
BEGIN
    ALTER TABLE dbo.Games DROP COLUMN PlatformId;
    PRINT 'Старая колонка PlatformId удалена из Games.';
END
GO

-- Удаляем и пересоздаем таблицу Platforms, чтобы быть уверенными, что она правильная
DROP TABLE IF EXISTS dbo.Platforms;
GO
CREATE TABLE dbo.Platforms (
    Id   uniqueidentifier NOT NULL PRIMARY KEY,
    Name nvarchar(100)    NOT NULL
);
GO
INSERT INTO Platforms (Id, Name) VALUES (NEWID(), 'PC'), (NEWID(), 'PlayStation 5'), (NEWID(), 'Xbox Series X'), (NEWID(), 'Nintendo Switch'), (NEWID(), 'Other');
GO
PRINT 'Таблица Platforms пересоздана и заполнена.';


-- ========= ШАГ 2: СОЗДАЕМ ВСЕ ЗАНОВО =========

-- Теперь, когда мы уверены, что колонки PlatformId нет, мы просто добавляем ее с правильным типом
ALTER TABLE dbo.Games ADD PlatformId uniqueidentifier NULL;
GO
PRINT 'Новая колонка PlatformId (Guid) добавлена в таблицу Games.';

-- Теперь, когда обе колонки (Platforms.Id и Games.PlatformId) гарантированно имеют тип uniqueidentifier,
-- создаем внешний ключ.
ALTER TABLE dbo.Games ADD CONSTRAINT FK_Games_Platforms 
FOREIGN KEY (PlatformId) REFERENCES dbo.Platforms(Id);
GO
PRINT 'Внешний ключ FK_Games_Platforms успешно создан.';

PRINT 'БАЗА ДАННЫХ ГОТОВА!';