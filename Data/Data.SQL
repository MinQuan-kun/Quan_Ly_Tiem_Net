CREATE DATABASE QLTiemNet
--DROP DATABASE QLTiemNet
-- DROP TABLE Users
-- DROP TABLE Menu
-- DROP TABLE Category
-- DROP TABLE Computers
-- DROP TABLE Cards
-- DROP TABLE Status
-- DROP TABLE Bill
Use QLTiemNet
GO

-- Bảng Users
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARBINARY(MAX) NOT NULL,
    Email VARCHAR(50),
    OTP VARCHAR(50),
    OTPDatesend DATETIME,
    OTPDatecreate DATETIME,
    CardID INT,
    Point DECIMAL(10, 2) DEFAULT 0.00, 
    Role NVARCHAR(500) CHECK (Role IN (N'Admin', N'Nhân viên', N'Người dùng')),
    Active NVARCHAR(500) CHECK (Active IN (N'đang hoạt động', N'Đã khóa')),
    DataActive DATETIME
);
-- Bảng thẻ
CREATE TABLE Cards (
    CardID INT PRIMARY KEY IDENTITY(1,1),  
    UserID INT,
    CardType NVARCHAR(500) CHECK (CardType IN (N'VIP', N'Thành viên')) NOT NULL,
    Stas NVARCHAR(500) CHECK (Stas IN (N'đang hoạt động', N'Đã khóa')),
    Balance DECIMAL(10, 2) DEFAULT 0.0
);
-- Bảng máy
CREATE TABLE Computers (
    ComputerID INT PRIMARY KEY IDENTITY(1,1),  
    ComputerName NVARCHAR(500) NOT NULL UNIQUE,
    Phankhuc NVARCHAR(500) CHECK (Phankhuc IN (N'Gaming', N'Tiêu chuẩn', N'VIP')) NOT NULL,
    Stas NVARCHAR(500) CHECK (Stas IN (N'Online', N'Bảo trì', N'Offline')) NOT NULL
);
-- Bảng menu
CREATE TABLE Menu (
    FoodID INT PRIMARY KEY IDENTITY(1,1),  
    CategoryID INT,
    FoodName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL,
    Image Image,
    Notes TEXT
);
-- Bảng hóa đơn
CREATE TABLE Bill (
    BillID INT PRIMARY KEY IDENTITY(1,1),  
    UserID INT NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);
-- Bảng thẻ loại
CREATE TABLE Category (
    CategoryID INT PRIMARY KEY IDENTITY(1,1), 
    CategoryName NVARCHAR(500) UNIQUE
);
-- Bảng trạng thái
CREATE TABLE Status (
    StationID INT PRIMARY KEY IDENTITY(1,1),  
    ComputerID INT,
    Stas NVARCHAR(500) CHECK (Stas IN (N'Online', N'Bảo trì', N'Offline')) NOT NULL,
    CurrentUserID INT,
    StartTime DATETIME,
    RemainingTime INT,
    Notes TEXT,
    FOREIGN KEY (CurrentUserID) REFERENCES Users(UserID) ON DELETE SET NULL
);

GO
-- Xử lý khóa ngoại cho bảng `user`
ALTER TABLE Users
    ADD CONSTRAINT FK_Card FOREIGN KEY (CardID) REFERENCES Cards(CardID);

-- Xử lý khóa ngoại cho bảng `Status`
ALTER TABLE Status
    ADD CONSTRAINT FK_Computer FOREIGN KEY (ComputerID) REFERENCES Computers(ComputerID);

-- Xử lý khóa ngoại cho bảng `Menu`
ALTER TABLE Menu
    ADD CONSTRAINT FK_Category FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID);


-- Thêm dữ liệu mẫu vào bảng Category
INSERT INTO Category (CategoryName)
VALUES 
(N'Cơm'),
(N'Nước uống'),
(N'Snack'),
(N'Mì'),
(N'Kem');

-- Thêm dữ liệu mẫu vào bảng Menu
INSERT INTO Menu (CategoryID, FoodName, Price, Quantity)
VALUES 
(1, N'Cơm gà', 25.000, 50),
(1, N'Cơm sườn', 25000, 50),
(1, N'Cơm trộn hàn quốc', 25.000, 50),
(1, N'Cơm chiên trứng ốp la', 25.000, 50),
(2, N'Sting', 15000, 70),
(2, N'Pepsi', 15000, 70),
(2, N'Sprite', 15000, 70),
(2, N'Coca cola', 15000, 70),
(3, N'Snack khoai tây', 10.000, 60),
(3, N'Snack ngô', 10000, 60),
(3, N'Snack bí đỏ', 10000, 60),
(3, N'Snack cua', 10000, 60),
(4, N'Mì tương đen', 25000, 50),
(4, N'Mì ý', 25000, 50),
(4, N'Mì ly', 10000, 50),
(4, N'Mì trộn', 25000, 50),
(5, N'Kem vani', 20000, 40),
(5, N'Kem socola', 20000, 40),
(5, N'Kem matcha', 20000, 40),
(5, N'Kem dâu', 20000, 40);

-- Dữ liệu cho bảng Computers
-- INSERT INTO Computers (ComputerName, Phankhuc, Stas)
-- VALUES
-- ('Comp01', N'VIP', 'Offline'),
-- ('Comp02', N'VIP', 'Offline'),
-- ('Comp03', N'VIP', 'Offline'),
-- ('Comp04', N'Gaming', 'Offline'),
-- ('Comp05', N'Tiêu chuẩn', 'Offline'),
-- ('Comp06', N'VIP', 'Offline'),
-- ('Comp07', N'Gaming', 'Offline');

-- Trigger cập nhật CardID
GO
CREATE TRIGGER trg_UpdateCardID
ON Cards
AFTER INSERT
AS
BEGIN
    -- Cập nhật CardID trong bảng Users
    UPDATE Users
    SET CardID = inserted.CardID
    FROM Users
    INNER JOIN inserted ON Users.UserID = inserted.UserID;
END;
-- DROP TRIGGER trg_UpdateCardID;

--1
-- INSERT INTO Users(FullName, username, Pass,	Point)
-- VALUES
-- (N'LmaoLmaoLmao', N'Nhonnn', '1234567', '0'),
-- (N'Bình 2 hòn', N'binhdz', '1234567', '1000'),
-- (N'Tín succc', N'tingay', '1234567', '1000'),
-- (N'Phương zũ', N'Cuctavang', '1234567', '1000'),
-- (N'Tỷ Phú', N'ITBOY', '1234567', '1000'),
-- (N'Nhờn', N'Lmao', '1234567', '0'),
-- (N'Dương404', N'Duongg', '1234567', '0'),
-- (N'Quản lý', N'Admin', '123','10000')

--2
-- INSERT INTO Cards(UserID, CardType, Stas, Balance)
-- VALUES
-- ('2', N'VIP', N'Đang hoạt động', '200.000'),
-- ('1', N'Thành viên', N'Đã khóa', '0'),
-- ('4', N'VIP', N'Đã khóa', '0'),
-- ('3', N'VIP', N'Đang hoạt động', '200.000'),
-- ('6', N'Thành viên', N'Đang hoạt động', '200.000'),
-- ('5', N'VIP',  N'Đã khóa', '0'),
-- ('7', N'Thành viên', N'Đang hoạt động', '200.000');

--Truy xuất tài khoản
GO
CREATE PROC GetAccoount
@username NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Users WHERE Username = @username
END 
-- DROP PROC GetAccount;

--Truy xuất đăng nhập
GO
CREATE PROC Go_Login
@username NVARCHAR(100), @password NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Users WHERE Username = @username AND Password = @password
END
-- DROP PROC Go_Login;

--Truy xuất danh mục 
GO
CREATE PROC GetMenu
@Category NVARCHAR(500)
AS 
BEGIN
    SELECT * 
    FROM Menu M
    JOIN Category CT ON CT.CategoryID = M.CategoryID
    WHERE CT.CategoryName = @Category
END
-- DROP PROC GetMenu;

--Truy vấn món ăn
GO
CREATE PROC GetFood
@Name NVARCHAR(500)
AS
BEGIN 
    SELECT *
    FROM Menu
    WHERE FoodName = @Name
END
-- DROP PROC GetFood;

--Tạo trigger thay đổi số tiền trong ví
GO
CREATE TRIGGER Up_Money
ON Bill
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON; -- Bỏ thông báo ảnh hưởng của trigger

    -- Trừ tiền khi thêm hóa đơn mới
    IF EXISTS (SELECT 1 FROM inserted)
    BEGIN
        UPDATE Cards
        SET Balance = Balance - i.TotalAmount
        FROM Cards w
        INNER JOIN inserted i ON w.UserID = i.UserID
        WHERE w.Stas = N'Đang hoạt động';
    END

    -- Hoàn tiền khi xóa hóa đơn
    IF EXISTS (SELECT 1 FROM deleted)
    BEGIN
        UPDATE Cards
        SET Balance = Balance + d.TotalAmount
        FROM Cards w
        INNER JOIN deleted d ON w.UserID = d.UserID
        WHERE w.Stas = N'Đang hoạt động';
    END

    -- Cập nhật tiền khi sửa hóa đơn (UPDATE)
    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        UPDATE Cards
        SET Balance = Balance - i.TotalAmount + d.TotalAmount
        FROM Cards w
        INNER JOIN inserted i ON w.UserID = i.UserID
        INNER JOIN deleted d ON w.UserID = d.UserID
        WHERE w.Stas = N'Đang hoạt động';
    END
END
GO
-- DROP TRIGGER Up_Money;

-- Trigger xử lý khi cập nhật điểm và loại thẻ
GO
CREATE TRIGGER trg_UpdatePoints
ON Cards
AFTER UPDATE
AS
BEGIN
    DECLARE @UserID INT, @Balance DECIMAL(10, 2), @Points DECIMAL(10, 2);

    -- Lấy thông tin từ bảng inserted
    SELECT @UserID = UserID, @Balance = Balance FROM inserted;

    -- Tính điểm tích lũy = số tiền nạp * 0.002
    SET @Points = @Balance * 0.002;

    -- Cập nhật điểm tích lũy trong bảng Users
    UPDATE Users
    SET Point = Point + @Points
    WHERE UserID = @UserID;
END;
-- DROP TRIGGER trg_UpdatePoints

DECLARE @ImageData VARBINARY(MAX);
--Ảnh lấy từ Resources thế vào chỗ C:user

-- Cập nhật ảnh cho món ăn "Cơm gà"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Comga.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Cơm gà';

-- Cập nhật ảnh cho món ăn "Cơm sườn"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Comsuon.PNG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Cơm sườn';

-- Cập nhật ảnh cho món ăn "Cơm trộn hàn quốc"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\ComtronHanquoc.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Cơm trộn hàn quốc';

-- Cập nhật ảnh cho món ăn "Cơm chiên trứng ốp la"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Comchientrungopla.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Cơm chiên trứng ốp la';

-- Cập nhật ảnh cho món ăn "Sting"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Sting.PNG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Sting';

-- Cập nhật ảnh cho món ăn "Pepsi"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Pepsi.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Pepsi';

-- Cập nhật ảnh cho món ăn "Sprite"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Sprite.PNG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Sprite';

-- Cập nhật ảnh cho món ăn "Coca cola"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Cocacola.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Coca cola';

-- Cập nhật ảnh cho món ăn "Snack khoai tây"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Snackkhoaitay.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Snack khoai tây';

-- Cập nhật ảnh cho món ăn "Snack ngô"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Snackngo.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Snack ngô';

-- Cập nhật ảnh cho món ăn "Snack bí đỏ"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Snackbido.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Snack bí đỏ';

-- Cập nhật ảnh cho món ăn "Snack cua"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Snackcua.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Snack cua';

-- Cập nhật ảnh cho món ăn "Mì tương đen"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Mituongden.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Mì tương đen';

-- Cập nhật ảnh cho món ăn "Mì ý"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Miy.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Mì ý';

-- Cập nhật ảnh cho món ăn "Mì ly"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Mily.PNG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Mì ly';

-- Cập nhật ảnh cho món ăn "Mì trộn"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Mitron.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Mì trộn';

-- Cập nhật ảnh cho món ăn "Kem vani"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Kemvani.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Kem vani';

-- Cập nhật ảnh cho món ăn "Kem socola"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Kemsocola.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Kem socola';

-- Cập nhật ảnh cho món ăn "Kem dâu"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Kemdau.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Kem dâu';

-- Cập nhật ảnh cho món ăn "Kem matcha"
-- Đọc ảnh từ file vào biến @ImageData
SELECT @ImageData = BulkColumn
FROM OPENROWSET(BULK 'C:\Users\ASUS\Pictures\Món ăn\Kemmatcha.JPG', SINGLE_BLOB) AS img;

-- Cập nhật ảnh vào bảng Menu
UPDATE Menu
SET Image = @ImageData
WHERE FoodName = N'Kem matcha';