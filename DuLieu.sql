IF DB_ID(N'DuLieu') IS NULL
    CREATE DATABASE DuLieu;
GO
USE DuLieu;
GO
IF OBJECT_ID(N'dbo.CongViec', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CongViec
    (
        MaCongViec nvarchar(10) NOT NULL PRIMARY KEY,
        TenCongViec ntext NOT NULL,
        LuongThang nvarchar(8) NOT NULL
    );
    INSERT INTO dbo.CongViec (MaCongViec, TenCongViec, LuongThang)
    VALUES (N'cv1', N'Bán hàng', N'5000000'),
           (N'cv2', N'Vệ Sinh', N'2500000');
END
GO
