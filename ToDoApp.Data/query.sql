-- CREATE TABLE ToDoList (
--     Id INTEGER PRIMARY KEY AUTOINCREMENT,
--     Title TEXT NOT NULL,
--     CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
--     DueDate TEXT,
--     IsCompleted INTEGER DEFAULT 0
-- );

-- INSERT INTO ToDoList (Title, DueDate) VALUES ('Buy groceries', '2024-07-01');
-- INSERT INTO ToDoList (Title, DueDate) VALUES ('Finish project report', '2024-07-05');
-- INSERT INTO ToDoList (Title, DueDate) VALUES ('Call the bank', '2024-06-30');

-- SELECT * FROM ToDoList WHERE IsCompleted = 0 ORDER BY DueDate ASC;