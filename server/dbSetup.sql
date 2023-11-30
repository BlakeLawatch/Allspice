CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        title CHAR(225) NOT NULL,
        instructions VARCHAR(1000) NOT NULL,
        img VARCHAR(1000) NOT NULL,
        category CHAR(225) NOT NULL,
        creatorId CHAR(225) NOT NULL
    ) default charset utf8 COMMENT '';

-- INSERT INTO

--     recipes(

--         title,

--         instructions,

--         img,

--         category,

--         creatorId

--     )

-- VALUES

-- (

--         "Burrito",

--         "Make Burrito",

--         "https://images.unsplash.com/photo-1562059390-a761a084768e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8YnVycml0b3xlbnwwfHwwfHx8MA%3D%3D",

--         "favorites",

--         "1234"

--     );

-- SELECT rec.*, acc.*

-- FROM recipes rec

--     JOIN accounts acc ON rec.creatorId = acc.id

-- WHERE

--     rec.id = LAST_INSERT_ID()

CREATE TABLE
    IF NOT EXISTS ingredients(
        Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
        name CHAR(255) NOT NULL,
        quantity INT NOT NULL,
        recipeId INT NOT NULL,
        creatorId INT NOT NULL,
        FOREIGN KEY(recipeId) REFERENCES recipe(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';