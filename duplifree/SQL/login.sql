
/*Login*/

CREATE TABLE Login (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL
);
INSERT INTO Login (Username, Password) 
VALUES ('Anu', 'anu1@2024'),
       ('Krithika', 'krithika1@2024'),
       ('Tejaswi', 'teju1@2024');

	   drop table Login;

/*Register*/
