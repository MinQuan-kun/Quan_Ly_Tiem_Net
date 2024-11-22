CREATE DATABASE QLTiemNet
--DROP DATABASE QLTiemNet
-- DROP TABLE Users
-- DROP TABLE Menu
-- DROP TABLE Category
-- DROP TABLE Computers
-- DROP TABLE Wallet
-- DROP TABLE Cards
-- DROP TABLE Status
-- DROP TABLE Bill
Use QLTiemNet
GO
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),  
    FullName NVARCHAR(100) NOT NULL,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Pass VARCHAR(255) NOT NULL,
    CardID INT NULL,
    Point INT DEFAULT 0,
    WalletID INT,
    Notes TEXT
);

CREATE TABLE Wallet (
    WalletID INT PRIMARY KEY IDENTITY(1,1),  
    UserID INT,
    Stas NVARCHAR(500) CHECK (Stas IN (N'đang hoạt động', N'Đã khóa')),
    Balance DECIMAL(10, 2) DEFAULT 0.0
);

CREATE TABLE Cards (
    CardID INT PRIMARY KEY IDENTITY(1,1),  
    UserID INT,
    CardType NVARCHAR(500) CHECK (CardType IN (N'VIP', N'Thành viên')) NOT NULL
);

CREATE TABLE Computers (
    ComputerID INT PRIMARY KEY IDENTITY(1,1),  
    ComputerName NVARCHAR(500) NOT NULL UNIQUE,
    Phankhuc NVARCHAR(500) CHECK (Phankhuc IN (N'Gaming', N'Tiêu chuẩn', N'VIP')) NOT NULL,
    Stas NVARCHAR(500) CHECK (Stas IN (N'Online', N'Bảo trì', N'Offline')) NOT NULL
);


CREATE TABLE Menu (
    FoodID INT PRIMARY KEY IDENTITY(1,1),  
    CategoryID INT,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Quantity INT NOT NULL,
    Image VARCHAR(255),
    Notes TEXT
);

CREATE TABLE Bill (
    BillID INT PRIMARY KEY IDENTITY(1,1),  
    UserID INT NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);

CREATE TABLE Category (
    CategoryID INT PRIMARY KEY IDENTITY(1,1), 
    CategoryName NVARCHAR(500) UNIQUE
);

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


ALTER TABLE Users
	ADD CONSTRAINT FK_WalletID 
	FOREIGN KEY (WalletID) REFERENCEs Wallet(WalletID)

ALTER TABLE Users
	ADD CONSTRAINT FK_Card 
	FOREIGN KEY (CardID) REFERENCEs Cards(CardID)

ALTER TABLE Status
	ADD CONSTRAINT FK_Computer
	FOREIGN KEY(ComputerID) REFERENCES Computers(ComputerID)
	
ALTER TABLE Menu
	ADD CONSTRAINT FK_Category
	FOREIGN KEY(CategoryID) REFERENCEs Category(CategoryID)

INSERT INTO Category(CategoryName)
VALUES 
(N'Cơm'),
(N'Nước uống'),
(N'Snack'),
(N'Mì'),
(N'Kem')

INSERT INTO Menu(CategoryID, Name, Price, Quantity)
VALUES 
('1',  N'Cơm gà', '25.000', '50'),
('1',  N'Cơm sườn', '25.000', '50'),
('1',  N'Cơm trộn hàn quốc', '25.000', '50'),
('1',  N'Cơm chiên trứng ốp la', '25.000', '50'),
('2',  N'Sting', '15.000', '70'),
('2',  N'Pepsi', '15.000', '70'),
('2',  N'Sprite', '15.000', '70'),
('2',  N'Coca cola', '15.000', '70'),
('3',  N'Snack khoai tây', '10.000', '60'),
('3',  N'Snack ngô', '10.000', '60'),
('3',  N'Snack bí đỏ', '10.000', '60'),
('3',  N'Snack cua', '10.000', '60'),
('4',  N'Mì tương đen', '25.000', '50'),
('4',  N'Mì ý', '25.000', '50'),
('4',  N'Mì ly', '25.000', '50'),
('4',  N'Mì trộn', '25.000', '50'),
('5',  N'Kem vani', '20.000', '40'),
('5',  N'Kem socola', '20.000', '40'),
('5',  N'Kem matcha', '20.000', '40'),
('5',  N'Kem dâu', '20.000', '40')

INSERT INTO Computers(ComputerName, Phankhuc, Stas)
VALUES
('Comp01', N'VIP', 'Offline'),
('Comp02', N'VIP', 'Offline'),
('Comp03', N'VIP', 'Offline'),
('Comp04', N'Gaming', 'Offline'),
('Comp05', N'Tiêu chuẩn', 'Offline'),
('Comp06', N'VIP', 'Offline'),
('Comp07', N'Gaming', 'Offline')

-- Thêm lần lượt trigger
CREATE TRIGGER trg_UpdateWalletID
ON Wallet
AFTER INSERT
AS
BEGIN
    -- Cập nhật WalletID trong bảng Users
    UPDATE Users
    SET WalletID = inserted.WalletID
    FROM Users
    INNER JOIN inserted ON Users.UserID = inserted.UserID;
END;


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

-- DROP TRIGGER trg_UpdateWalletID;
-- DROP TRIGGER trg_UpdateCardID;

-- Thêm lần lượt
--1
INSERT INTO Users(FullName, username, Pass,	Point)
VALUES
(N'LmaoLmaoLmao', N'Nhonnn', '1234567', '0'),
(N'Bình 2 hòn', N'binhdz', '1234567', '1000'),
(N'Tín succc', N'tingay', '1234567', '1000'),
(N'Phương zũ', N'Cuctavang', '1234567', '1000'),
(N'Tỷ Phú', N'ITBOY', '1234567', '1000'),
(N'Nhờn', N'Lmao', '1234567', '0'),
(N'Dương404', N'Duongg', '1234567', '0')

--2
INSERT INTO Cards(UserID, CardType)
VALUES
('2', N'VIP'),
('1', N'Thành viên'),
('4', N'VIP'),
('3', N'VIP'),
('6', N'Thành viên'),
('5', N'VIP'),
('7', N'Thành viên')

--3
INSERT INTO Wallet(UserID, Stas, Balance)
VALUES
('2', N'Đang hoạt động' ,'200.000'),
('1', N'Đã khóa', '0'),
('4', N'Đã khóa', '0'),
('3', N'Đang hoạt động', '0'),
('6', N'Đã khóa', '0'),
('5', N'Đang hoạt động' ,'200.000'),
('7', N'Đang hoạt động', '200.000')

