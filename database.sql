CREATE DATABASE IF NOT EXISTS UserDb;
USE UserDb;

CREATE TABLE IF NOT EXISTS Users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Users (Name, Email) VALUES 
('Nguyễn Văn A', 'nguyenvana@email.com'),
('Trần Thị B', 'tranthib@email.com'),
('Lê Văn C', 'levanc@email.com'),
('Phạm Thị D', 'phamthid@email.com'),
('Hoàng Văn E', 'hoangvane@email.com'),
('Đỗ Thị F', 'dothif@email.com'),
('Bùi Văn G', 'buivang@email.com'),
('Vũ Thị H', 'vuthih@email.com'),
('Ngô Văn I', 'ngovani@email.com'),
('Đặng Thị K', 'dangthik@email.com'),
('Nguyễn Văn L', 'nguyenvana@email.com'),
('Trần Thị M', 'tranthib@email.com'),
('Lê Văn N', 'levanc@email.com'),
('Phạm Thị O', 'phamthid@email.com'),
('Hoàng Văn P', 'hoangvane@email.com');