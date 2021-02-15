 --========
 --Objects
 --========
 DECLARE @objectId INT = 0;
 WHILE @objectId < 10
 BEGIN
     SET @objectId = @objectId + 1;
     INSERT INTO Objects
         (Id,[Name])
     VALUES(@objectId, 'Object-'+ CONVERT(VARCHAR, @objectId))
 END;

 --========
 --DataFields
 --========
 DECLARE @dataFieldId INT = 0;
 WHILE @dataFieldId < 10
 BEGIN
     SET @dataFieldId = @dataFieldId + 1;
     INSERT INTO DataFields
         (Id, [Name])
     VALUES(@dataFieldId, 'DataField-'+ CONVERT(VARCHAR, @dataFieldId))
 END;

  --========
 --Buildings
 --========
 DECLARE @buildingId INT = 0;
 WHILE @buildingId < 10
 BEGIN
     SET @buildingId = @buildingId + 1;
     INSERT INTO Buildings
         ([Name],[Location])
     VALUES('Building-'+ CONVERT(VARCHAR, @buildingId),
             'Location-'+ CONVERT(VARCHAR, @buildingId))
 END;


DECLARE @buildingIdForReading INT
DECLARE @objectIdForReading INT
DECLARE @dataFieldIdForReading INT
DECLARE @startTime DATETIME
DECLARE @endTime DATETIME
SET @buildingIdForReading = 0

WHILE @buildingIdForReading < 10
BEGIN
    SET @objectIdForReading = 0
    SET @dataFieldIdForReading = 0
    SET @buildingIdForReading = @buildingIdForReading + 1;
    WHILE @objectIdForReading < 10
    BEGIN
        SET @dataFieldIdForReading = 0
        SET @objectIdForReading = @objectIdForReading + 1;
        WHILE @dataFieldIdForReading < 10
        BEGIN
            SET @dataFieldIdForReading = @dataFieldIdForReading + 1;
            SET @startTime = CONVERT(datetime,'2018-06-01 00:00:00.000')
            SET @endTime = CONVERT(datetime,'20120-05-31 00:00:00.000')
            WHILE (@endTime > @startTime)
            BEGIN
                INSERT INTO Readings
                    ([BuildingId], [ObjectId], [DataFieldId], [Value], [Timestamp])
                VALUES(@buildingIdForReading,
                        @objectIdForReading,
                        @dataFieldIdForReading,
                        FLOOR(RAND()*60) + 20,
                        @startTime)
                --PRINT 'building added'
                -- PRINT 'buildingId '+ CONVERT(VARCHAR, @buildingIdForReading)
                --        +' objectId '+ CONVERT(VARCHAR, @objectIdForReading)
                --        +' dataFieldId '+ CONVERT(VARCHAR, @dataFieldIdForReading)
                --        +' value '+ CONVERT(VARCHAR, floor(rand()*60) + 20)
                --        +' startTime '+CONVERT(VARCHAR, @startTime)
                SET @startTime = DATEADD(MINUTE,1,@startTime)
            END
        END;
    END;
END;

--select count('') from Buildings
--select *from Buildings
--select *from objects
--select *from datafields
--select *from readings
-- delete Buildings
--truncate table Buildings
--delete readings
-- drop database reading